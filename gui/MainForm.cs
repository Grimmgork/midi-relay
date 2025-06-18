using gui.Midi;
using gui.Model;
using System.ComponentModel;
using System.Runtime.Versioning;

namespace gui;

[RequiresPreviewFeatures]
public partial class MainForm : Form
{
    private readonly string windowTitle = "EC5 MIDI Controller";
    private readonly string version = "v1.1";

    private MainModel model;
    private MainController controller;

    public MainForm()
    {
        InitializeComponent();
        Text = $"{windowTitle} - {version}";

        model = new MainModel();
        controller = new MainController(model, "settings.json");

        model.PropertyChanged += ViewModel_PropertyChanged;
        controller.Initialize();

        programChangeComboBox.SelectedValueChanged += ProgramChangeInput_ValueChanged;
        programChangeComboBox.DisplayMember = "Name";

        removeProgramChangeButton.Click += RemoveProgramChangeButton_Click; ;
        buttonOverviewListBox.SelectedIndexChanged += ButtonOverviewListBox_SelectedIndexChanged;
        model.Device.PropertyChanged += Device_PropertyChanged;

        Binding controlChannelBinding = new Binding("Value", model.Device, "ControlChannel");
        controlChannelBinding.Format += ControlChannelBind_Format;
        controlChannelBinding.Parse += ControlChannelBind_Parse;
        controlChannelInput.DataBindings.Add(controlChannelBinding);

        controlChannelInput.Leave += ControlChannelInput_Leave;

        FormClosing += MainForm_FormClosing;
        HelpButtonClicked += MainForm_HelpRequested;

        controller.SelectButton(-1);
        controller.SelectDevice(null);

        RefreshProgramChangeComboBoxItems();
    }

    private void MainForm_HelpRequested(object? sender, EventArgs hlpevent)
    {
        HelpBox dialog = new HelpBox();
        dialog.ShowDialog();
    }

    private void RemoveProgramChangeButton_Click(object? sender, EventArgs e)
    {
        if (model.SelectedButton != null)
        {
            model.SelectedButton.Enabled = false;
            removeProgramChangeButton.Enabled = false;
            programChangeComboBox.SelectedIndex = -1;
            RefreshButtonOverviewItem(buttonOverviewListBox.SelectedIndex);
        }
    }

    private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        e.Cancel = !AskForUnsavedChanges();
    }

    private void ControlChannelBind_Parse(object? sender, ConvertEventArgs e)
    {
        byte channel = Convert.ToByte(e.Value!);
        e.Value = channel - 1;
    }

    private void ControlChannelBind_Format(object? sender, ConvertEventArgs e)
    {
        byte? channel = e.Value == null ? null : (byte)(e.Value);
        e.Value = channel == null ? null : channel + 1;
    }

    private void Device_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(model.Device.Buttons))
        {
            RefreshButtonOverview();
        }
    }

    private void ProgramChangeInput_ValueChanged(object? sender, EventArgs e)
    {
        if (sender is ComboBox comboBox && model.SelectedButton != null)
        {
            if (comboBox.SelectedItem != null)
            {
                model.SelectedButton.Enabled = true;
                model.SelectedButton.ProgramNumber = ((TargetProgramChangeItem)comboBox.SelectedItem).ProgramNumber;
                removeProgramChangeButton.Enabled = true;
            }

            RefreshButtonOverviewItem(buttonOverviewListBox.SelectedIndex);
        }
    }

    private void ControlChannelInput_Leave(object? sender, EventArgs e)
    {
        controlChannelInput.DataBindings["Value"]?.WriteValue();
    }

    private void ButtonOverviewListBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (sender is ListBox listBox)
        {
            controller.SelectButton(buttonOverviewListBox.SelectedIndex);
        }
    }

    private void RefreshDeviceSelectionDropdown()
    {
        deviceToolStripMenuItem.DropDown.Items.Clear();
        deviceToolStripMenuItem.DropDown.Items.Add("find", Icons.SearchList, OnSearchDevice_Clicked);
        foreach (string portName in model.Ports)
        {
            Image? icon = model.SelectedPort == portName ? Icons.Checkmark : null;
            deviceToolStripMenuItem.DropDown.Items.Add(portName, icon, OnSelectDevice_Clicked);
        }
    }

    private void RefreshTargetSelectionDropdown()
    {
        targetToolStripMenuItem.DropDown.Items.Clear();
        foreach (string target in model.Targets)
        {
            Image? icon = model.SelectedTarget == target ? Icons.Checkmark : null;
            targetToolStripMenuItem.DropDown.Items.Add(target, icon, OnSelectTarget_Clicked);
        }
    }

    private void RefreshProgramChangeComboBoxItems()
    {
        programChangeComboBox.Items.Clear();
        foreach (TargetProgramChangeItem item in model.ProgramChangeDictionary)
        {
            programChangeComboBox.Items.Add(item);
        }
    }

    private void RefreshButtonOverview()
    {
        int index = buttonOverviewListBox.SelectedIndex;
        buttonOverviewListBox.SelectedIndexChanged -= ButtonOverviewListBox_SelectedIndexChanged;
        buttonOverviewListBox.Items.Clear();
        foreach (ButtonConfigurationModel button in model.Device.Buttons)
        {
            buttonOverviewListBox.Items.Add(GetButtonOverviewItemText(button));
        }

        if (index >= buttonOverviewListBox.Items.Count)
        {
            index = -1;
        }

        buttonOverviewListBox.SelectedIndex = index;
        buttonOverviewListBox.SelectedIndexChanged += ButtonOverviewListBox_SelectedIndexChanged;
    }

    private void RefreshButtonOverviewItem(int index)
    {
        if (index == -1)
            return;

        buttonOverviewListBox.SelectedIndexChanged -= ButtonOverviewListBox_SelectedIndexChanged;
        ButtonConfigurationModel button = model.Device.Buttons[index];
        buttonOverviewListBox.Items[index] = GetButtonOverviewItemText(button);
        buttonOverviewListBox.SelectedIndexChanged += ButtonOverviewListBox_SelectedIndexChanged;
    }

    private void ViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(model.Ports))
        {
            RefreshDeviceSelectionDropdown();
        }
        else if (e.PropertyName == nameof(model.State))
        {
            toolStripStatusLabel.Text = model.State.ToString();
            if (model.State == ApplicationState.Busy)
            {
                Cursor.Current = Cursors.WaitCursor;
            }
            else
            {
                Cursor.Current = Cursors.Default;
            }
        }
        else if (e.PropertyName == nameof(model.SelectedPort))
        {
            RefreshDeviceSelectionDropdown();
            bool isSelected = model.SelectedPort != null;
            controlChannelInput.Enabled = isSelected;
            serialPortStatusLabel.Text = model.SelectedPort;
            submitButton.Enabled = isSelected;
            programChangeComboBox.Enabled = isSelected;
        }
        else if (e.PropertyName == nameof(model.SelectedTarget))
        {
            selectedTargetStatusLabel.Text = model.SelectedTarget;
            RefreshTargetSelectionDropdown();
            RefreshProgramChangeComboBoxItems();
            RefreshButtonOverview();
        }
        else if (e.PropertyName == nameof(model.SelectedButton))
        {
            if (model.SelectedButton == null)
            {
                // controlChannelInput.Enabled = false;

                removeProgramChangeButton.Enabled = false;
                programChangeComboBox.Enabled = false;
                programChangeComboBox.SelectedIndex = -1;
            }
            else
            {
                programChangeComboBox.Enabled = true;
                if (model.SelectedButton.Enabled)
                {
                    TargetProgramChangeItem? item = model.ProgramChangeDictionary.FirstOrDefault(i => i.ProgramNumber == model.SelectedButton.ProgramNumber);
                    if (item == null)
                    {
                        programChangeComboBox.SelectedIndex = -1;
                    }
                    else
                    {
                        programChangeComboBox.SelectedItem = item;
                    }
                }
                else
                {
                    programChangeComboBox.SelectedIndex = -1;
                }

                removeProgramChangeButton.Enabled = model.SelectedButton.Enabled;

                buttonOverviewListBox.SelectedIndexChanged -= ButtonOverviewListBox_SelectedIndexChanged;
                buttonOverviewListBox.SelectedIndex = model.SelectedButton.Index;
                buttonOverviewListBox.SelectedIndexChanged += ButtonOverviewListBox_SelectedIndexChanged;
            }
        }
    }

    private static string GetButtonName(int index) => $"{(char)(65 + index)}";

    private string GetButtonOverviewItemText(ButtonConfigurationModel button)
    {
        string buttonName = GetButtonName(button.Index);
        if (button.Enabled)
        {
            return $"{buttonName} {GetProgramChangeName(button.ProgramNumber) ?? "Unknown"}";
        }
        else
        {
            return $"{buttonName} -";
        }
    }

    private string? GetProgramChangeName(byte programNumber)
    {
        IMidiCommand command = new MidiProgramChange(model.Device.ControlChannel, programNumber);
        return controller.GetNameOfCommand(command);
    }

    private void OnSearchDevice_Clicked(object? sender, EventArgs args)
    {
        if (AskForUnsavedChanges())
        {
            controller.DoBusyWork(() =>
                controller.SearchForDevice());

            if (model.Exception != null)
            {
                ShowErrorMessage(model.Exception);
            }
        }
    }

    private void OnSelectDevice_Clicked(object? sender, EventArgs args)
    {
        if (sender is ToolStripItem item)
        {
            if (AskForUnsavedChanges())
            {
                controller.DoBusyWork(() =>
                    controller.SelectDevice(item.Text));

                if (model.Exception != null)
                {
                    ShowErrorMessage(model.Exception);
                }
            }
        }
    }

    private void OnSelectTarget_Clicked(object? sender, EventArgs args)
    {
        if (sender is ToolStripItem item)
        {
            controller.SelectTarget(item.Text ?? "");
            controller.SaveSettings();
        }
    }

    private void submitButton_Click(object sender, EventArgs e)
    {
        controller.DoBusyWork(() =>
            controller.WriteConfigurationToDevice());

        if (model.Exception != null)
        {
            ShowErrorMessage(model.Exception);
        }
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private bool AskForUnsavedChanges()
    {
        if (controller.HasUnsavedChanges())
        {
            QuestionBox box = new QuestionBox("Discard unsaved changes?");
            box.ShowDialog();
            return box.Result == DialogResult.Yes;
        }

        return true;
    }

    private void ShowErrorMessage(Exception exception)
    {
        ErrorBox box = new ErrorBox(exception);
        box.ShowDialog();
    }
}