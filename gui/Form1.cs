using gui.MIDI;
using System.Data;
using System.Diagnostics;
using System.IO.Ports;
using System.Text;

namespace gui;

public partial class Form1 : Form
{
    bool busy = false;
    bool error = false;

    public Form1()
    {
        InitializeComponent();
        serialPortComboBox.DropDown += SerialPortComboBox_DropDown;
    }

    private void SerialPortComboBox_DropDown(object? sender, EventArgs e)
    {
        int index = serialPortComboBox.SelectedIndex;
        serialPortComboBox.Items.Clear();
        serialPortComboBox.Items.AddRange(SerialPort.GetPortNames());
        if (index >= serialPortComboBox.Items.Count)
            serialPortComboBox.SelectedIndex = index;
        else
            serialPortComboBox.SelectedIndex = 0;
    }

    private void StateHasChanged()
    {
        toolStripStatusLabel.Text = busy ? "busy" : error ? "error" : "done";
        loadDataButton.Enabled = (!busy);
        clearCommandButton.Enabled = (!busy);
        Refresh();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        StateHasChanged();
    }

    private void loadDataButton_Click(object sender, EventArgs e)
    {
        LoadButtonData();
    }

    private void editButton_Click(object sender, EventArgs e)
    {
        int buttonIndex = buttonOverviewListBox.SelectedIndex;
        if (buttonIndex < 0)
            return;

        UpdateCommandDialog dialog = new UpdateCommandDialog(((ButtonConfiguration)buttonOverviewListBox.Items[buttonIndex]).ParseCommand());
        DialogResult result = dialog.ShowDialog();
        if(result != DialogResult.OK)
            return;

        IMidiCommand updatedCommand = dialog.AppliedCommand!;

        busy = true;
        StateHasChanged();
        Protocol p = new Protocol((string)serialPortComboBox.SelectedItem);
        try
        {
            p.Start();
            Message res = p.Command(new Message(0x30, updatedCommand.GetSequence().Prepend((byte)buttonOverviewListBox.SelectedIndex).ToArray() ));
            if (res.Command != 0x06)
                throw new Exception();
        }
        catch (Exception ex)
        {
            error = true;
        }
        p.Dispose();
        busy = false;
        StateHasChanged();

        if(!error)
            LoadButtonData();
    }

    private void LoadButtonData()
    {
        busy = true;
        error = false;

        buttonOverviewListBox.Items.Clear();
        buttonOverviewListBox.SelectedIndex = -1;
        StateHasChanged();

        Protocol p = new Protocol((string)serialPortComboBox.SelectedItem);
        try
        {
            p.Start();
            byte i = 0;
            for (; i < 255; i++)
            {
                Message res = p.Command(new Message(0x31, i));
                if (res.Command != 0x06)
                    break;

                buttonOverviewListBox.Items.Add(new ButtonConfiguration(i, res.Content));
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            p.Dispose();
            busy = false;
            error = true;
            StateHasChanged();
            return;
        }

        if (buttonOverviewListBox.SelectedIndex == -1 && buttonOverviewListBox.Items.Count > 0)
            buttonOverviewListBox.SelectedIndex = 0;

        if (buttonOverviewListBox.Items.Count > buttonOverviewListBox.SelectedIndex)
            buttonOverviewListBox.SelectedIndex = 0;

        p.Dispose();

        busy = false;
        StateHasChanged();
    }

    private void clearCommandButton_Click(object sender, EventArgs e)
    {
        error = false;
        busy = true;
        StateHasChanged();
        Protocol p = new Protocol((string)serialPortComboBox.SelectedItem);
        try
        {
            p.Start();
            Message res = p.Command(new Message(0x30, (byte)buttonOverviewListBox.SelectedIndex));
            if (res.Command != 0x06)
                throw new Exception();
        }
        catch(Exception ex)
        {
            error = true;
        }
        p.Dispose();
        busy = false;
        StateHasChanged();

        if(!error)
            LoadButtonData();
    }
}