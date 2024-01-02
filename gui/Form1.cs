using gui.MIDI;
using System.Data;
using System.Diagnostics;
using System.IO.Ports;
using System.Text;

namespace gui;

public partial class Form1 : Form
{
    private string? selectedPort = null;

    string? errormsg = null;
    bool busy = false;
    bool error = false;

    public Form1()
    {
        InitializeComponent();
        deviceToolStripMenuItem.DropDownOpening += DeviceToolStripMenuItem_DropDownOpening;
    }

    private void DeviceToolStripMenuItem_DropDownOpening(object? sender, EventArgs e)
    {
        PopulateDeviceDropdown();
    }

    private void StateHasChanged()
    {
        toolStripStatusLabel.Text = busy ? "busy" : error ? "error" : "done";
        toolStripStatusLabel.ToolTipText = errormsg;
        clearCommandButton.Enabled = (!busy);
        serialPortStatusLabel.Text = selectedPort;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        StateHasChanged();
    }

    private bool Busy(Action action)
    {
        error = false;
        errormsg = null;
        busy = true;
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
        StateHasChanged();
        try
        {
            action.Invoke();
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex.Message);
            errormsg = ex.Message;
            error = true;
        }
        busy = false;
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
        StateHasChanged();
        if (error)
            return false;
        return true;
    }

    private void editButton_Click(object sender, EventArgs e)
    {
        int buttonIndex = buttonOverviewListBox.SelectedIndex;
        if (buttonIndex < 0)
            return;

        if (selectedPort == null)
            return;

        UpdateCommandDialog dialog = new UpdateCommandDialog(((ButtonConfiguration)buttonOverviewListBox.Items[buttonIndex]).ParseCommand());
        DialogResult result = dialog.ShowDialog();
        if (result != DialogResult.OK)
            return;

        IMidiCommand updatedCommand = dialog.AppliedCommand!;

        Protocol p = new Protocol(selectedPort);
        Busy(() =>
        {
            p.Start();
            Message res = p.Command(new Message(0x30, updatedCommand.GetSequence().Prepend((byte)buttonOverviewListBox.SelectedIndex).ToArray()));
            if (res.Command != 0x06)
                throw new Exception();
        });
        p.Dispose();

        if (!error)
            LoadConfiguration();
    }

    private void PopulateDeviceDropdown()
    {
        deviceToolStripMenuItem.DropDown.Items.Clear();
        string[] names = SerialPort.GetPortNames();
        deviceToolStripMenuItem.DropDown.Items.Add("find", null, (object? sender, EventArgs e) =>
        {
            Busy(() =>
            {
                selectedPort = null;
                foreach (string name in names)
                {
                    try
                    {
                        Protocol p = new Protocol(name, 500);
                        p.Start();
                        p.Ping();
                        p.Dispose();
                        selectedPort = name;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                if (selectedPort == null)
                    throw new Exception("could not find a suitable device!");

                LoadConfiguration();
            });
            if (error)
                selectedPort = null;
            StateHasChanged();
        });
        foreach(string name in names)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(name);
            if (selectedPort == name)
                item.Checked = true;
            item.Click += (object? sender, EventArgs e) => 
            {
                selectedPort = name;
                LoadConfiguration();
                if (error)
                    selectedPort = null;
                StateHasChanged();
            };
            deviceToolStripMenuItem.DropDown.Items.Add(item);
        }
    }

    private void LoadConfiguration()
    {
        buttonOverviewListBox.Items.Clear();
        buttonOverviewListBox.SelectedIndex = -1;
        if (selectedPort == null)
            return;

        Protocol p = new Protocol(selectedPort);
        Busy(() =>
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
        });

        p.Dispose();

        if (!error)
        {
            if(buttonOverviewListBox.Items.Count > 0)
                buttonOverviewListBox.SelectedIndex = 0;
        }
    }

    private void clearCommandButton_Click(object sender, EventArgs e)
    {
        if (selectedPort == null)
            return;

        Protocol p = new Protocol(selectedPort);
        Busy(() => 
        {
            p.Start();
            Message res = p.Command(new Message(0x30, (byte)buttonOverviewListBox.SelectedIndex));
            if (res.Command != 0x06)
                throw new Exception();
        });
        p.Dispose();
        if (!error)
            LoadConfiguration();
    }

}