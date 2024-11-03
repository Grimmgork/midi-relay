using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO.Ports;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Windows.Forms;

namespace gui;

[RequiresPreviewFeatures]
public partial class MainForm : Form
{
    private MainViewModel model;
    private MainController controller;

    public MainForm()
    {
        InitializeComponent();
        model = new MainViewModel();
        controller = new MainController(model);

        model.PropertyChanged += ViewModel_PropertyChanged;
        controller.FetchPorts();

        buttonOverviewListBox.SelectedIndexChanged += ButtonOverviewListBox_SelectedIndexChanged;
        model.Device.PropertyChanged += Device_PropertyChanged;

        controlChannelInput.DataBindings.Add("Value", model.Device, "ControlChannel");

        controlChannelInput.Leave += ControlChannelInput_Leave;
        buttonProgramChangeInput.Leave += ButtonProgramChangeInput_Leave;

        buttonEnabledCheckBox.CheckedChanged += ButtonEnabledCheckBox_CheckedChanged;
        buttonProgramChangeInput.ValueChanged += ButtonProgramChangeInput_ValueChanged;

        controller.SelectButton(-1);
        controller.SelectDevice(null);
    }

    private void Device_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(model.Device.Buttons))
        {
            RefreshButtonOverview();
        }
    }

    private void ButtonProgramChangeInput_ValueChanged(object? sender, EventArgs e)
    {
        if (model.SelectedButton != null)
        {
            model.SelectedButton.ProgramNumber = (byte)buttonProgramChangeInput.Value;
            RefreshButtonOverviewItem(buttonOverviewListBox.SelectedIndex);
        }
    }

    private void ButtonEnabledCheckBox_CheckedChanged(object? sender, EventArgs e)
    {
        if (model.SelectedButton != null)
        {
            model.SelectedButton.Enabled = buttonEnabledCheckBox.Checked;
            buttonProgramChangeInput.Enabled = buttonEnabledCheckBox.Checked;
            RefreshButtonOverviewItem(buttonOverviewListBox.SelectedIndex);
        }
    }

    private void ControlChannelInput_Leave(object? sender, EventArgs e)
    {
        controlChannelInput.DataBindings["Value"]?.WriteValue();
    }

    private void ButtonProgramChangeInput_Leave(object? sender, EventArgs e)
    {
        buttonProgramChangeInput.DataBindings["Value"]?.WriteValue();
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

    private void RefreshButtonOverview()
    {
        buttonOverviewListBox.Items.Clear();
        foreach (ButtonConfigurationModel button in model.Device.Buttons)
        {
            buttonOverviewListBox.Items.Add(RenderButtonConfigAsString(button));
        }
    }

    private void RefreshButtonOverviewItem(int index)
    {
        if (index == -1)
            return;

        buttonOverviewListBox.SelectedIndexChanged -= ButtonOverviewListBox_SelectedIndexChanged;
        ButtonConfigurationModel button = model.Device.Buttons[index];
        buttonOverviewListBox.Items[index] = RenderButtonConfigAsString(button);
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
        }
        else if (e.PropertyName == nameof(model.SelectedButton))
        {
            if (model.SelectedButton == null)
            {
                buttonEnabledCheckBox.Checked = false;
                buttonEnabledCheckBox.Enabled = false;
                buttonProgramChangeInput.Value = 0;
                buttonProgramChangeInput.Enabled = false;
                selectedButtonStatusLabel.Text = "";
                controlChannelInput.Enabled = false;
            }
            else
            {
                buttonEnabledCheckBox.Checked = model.SelectedButton.Enabled;
                buttonEnabledCheckBox.Enabled = true;
                buttonProgramChangeInput.Value = model.SelectedButton.ProgramNumber;
                buttonProgramChangeInput.Enabled = model.SelectedButton.Enabled;

                selectedButtonStatusLabel.Text = RenderButtonConfigName(model.SelectedButton.Index);
                buttonOverviewListBox.SelectedIndexChanged -= ButtonOverviewListBox_SelectedIndexChanged;
                buttonOverviewListBox.SelectedIndex = model.SelectedButton.Index;
                buttonOverviewListBox.SelectedIndexChanged += ButtonOverviewListBox_SelectedIndexChanged;
            }
        }

        Refresh();
    }

    private static string RenderButtonConfigName(int index) => $"{(char)(65 + index)}";

    private static string RenderButtonConfigAsString(ButtonConfigurationModel button)
    {
        string name = RenderButtonConfigName(button.Index);
        if (button.Enabled)
        {
            return $"{name} PC {button.ProgramNumber}";
        }
        else
        {
            return $"{name} -";
        }   
    }

    private void OnSearchDevice_Clicked(object? sender, EventArgs args)
    {
        controller.DoBusyWork(() =>
            controller.SearchForDevice());
    }

    private void OnSelectDevice_Clicked(object? sender, EventArgs args)
    {
        if (sender is ToolStripItem item)
        {
            controller.DoBusyWork(() => 
                controller.SelectDevice(item.Text));
        }
    }

    private void submitButton_Click(object sender, EventArgs e)
    {
        controller.DoBusyWork(() => 
            controller.WriteConfigurationToDevice());
    }
}