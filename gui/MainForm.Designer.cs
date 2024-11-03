namespace gui;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        statusStrip1 = new StatusStrip();
        toolStripStatusLabel = new ToolStripStatusLabel();
        serialPortStatusLabel = new ToolStripStatusLabel();
        selectedButtonStatusLabel = new ToolStripStatusLabel();
        menuStrip1 = new MenuStrip();
        deviceToolStripMenuItem = new ToolStripMenuItem();
        findToolStripMenuItem = new ToolStripMenuItem();
        asdToolStripMenuItem = new ToolStripMenuItem();
        adawdToolStripMenuItem = new ToolStripMenuItem();
        splitter1 = new Splitter();
        controlChannelInput = new NumericUpDown();
        label1 = new Label();
        groupBox4 = new GroupBox();
        buttonEnabledCheckBox = new CheckBox();
        label5 = new Label();
        buttonProgramChangeInput = new NumericUpDown();
        buttonOverviewListBox = new ListBox();
        submitButton = new Button();
        statusStrip1.SuspendLayout();
        menuStrip1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)controlChannelInput).BeginInit();
        groupBox4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)buttonProgramChangeInput).BeginInit();
        SuspendLayout();
        // 
        // statusStrip1
        // 
        statusStrip1.ImageScalingSize = new Size(24, 24);
        statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel, serialPortStatusLabel, selectedButtonStatusLabel });
        statusStrip1.Location = new Point(0, 371);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.ShowItemToolTips = true;
        statusStrip1.Size = new Size(571, 32);
        statusStrip1.SizingGrip = false;
        statusStrip1.TabIndex = 7;
        statusStrip1.Text = "statusStrip1";
        // 
        // toolStripStatusLabel
        // 
        toolStripStatusLabel.AutoToolTip = true;
        toolStripStatusLabel.Name = "toolStripStatusLabel";
        toolStripStatusLabel.Size = new Size(53, 25);
        toolStripStatusLabel.Text = "Hello";
        toolStripStatusLabel.ToolTipText = "Error occured";
        // 
        // serialPortStatusLabel
        // 
        serialPortStatusLabel.Name = "serialPortStatusLabel";
        serialPortStatusLabel.Size = new Size(0, 25);
        // 
        // selectedButtonStatusLabel
        // 
        selectedButtonStatusLabel.Name = "selectedButtonStatusLabel";
        selectedButtonStatusLabel.Size = new Size(0, 25);
        // 
        // menuStrip1
        // 
        menuStrip1.ImageScalingSize = new Size(24, 24);
        menuStrip1.Items.AddRange(new ToolStripItem[] { deviceToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(571, 33);
        menuStrip1.TabIndex = 26;
        menuStrip1.Text = "menuStrip1";
        // 
        // deviceToolStripMenuItem
        // 
        deviceToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { findToolStripMenuItem, asdToolStripMenuItem, adawdToolStripMenuItem });
        deviceToolStripMenuItem.Name = "deviceToolStripMenuItem";
        deviceToolStripMenuItem.Size = new Size(80, 29);
        deviceToolStripMenuItem.Text = "Device";
        // 
        // findToolStripMenuItem
        // 
        findToolStripMenuItem.Name = "findToolStripMenuItem";
        findToolStripMenuItem.Size = new Size(167, 34);
        findToolStripMenuItem.Text = "find";
        // 
        // asdToolStripMenuItem
        // 
        asdToolStripMenuItem.Name = "asdToolStripMenuItem";
        asdToolStripMenuItem.Size = new Size(167, 34);
        asdToolStripMenuItem.Text = "asd";
        // 
        // adawdToolStripMenuItem
        // 
        adawdToolStripMenuItem.Checked = true;
        adawdToolStripMenuItem.CheckState = CheckState.Checked;
        adawdToolStripMenuItem.Name = "adawdToolStripMenuItem";
        adawdToolStripMenuItem.Size = new Size(167, 34);
        adawdToolStripMenuItem.Text = "adawd";
        // 
        // splitter1
        // 
        splitter1.Location = new Point(0, 33);
        splitter1.Name = "splitter1";
        splitter1.Size = new Size(4, 338);
        splitter1.TabIndex = 27;
        splitter1.TabStop = false;
        // 
        // controlChannelInput
        // 
        controlChannelInput.Location = new Point(91, 50);
        controlChannelInput.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
        controlChannelInput.Name = "controlChannelInput";
        controlChannelInput.Size = new Size(191, 31);
        controlChannelInput.TabIndex = 28;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(10, 52);
        label1.Name = "label1";
        label1.Size = new Size(75, 25);
        label1.TabIndex = 29;
        label1.Text = "Channel";
        // 
        // groupBox4
        // 
        groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupBox4.Controls.Add(buttonEnabledCheckBox);
        groupBox4.Controls.Add(label5);
        groupBox4.Controls.Add(buttonProgramChangeInput);
        groupBox4.Location = new Point(288, 103);
        groupBox4.Name = "groupBox4";
        groupBox4.Size = new Size(271, 211);
        groupBox4.TabIndex = 43;
        groupBox4.TabStop = false;
        groupBox4.Text = "Button";
        // 
        // buttonEnabledCheckBox
        // 
        buttonEnabledCheckBox.AutoSize = true;
        buttonEnabledCheckBox.Location = new Point(16, 37);
        buttonEnabledCheckBox.Name = "buttonEnabledCheckBox";
        buttonEnabledCheckBox.Size = new Size(101, 29);
        buttonEnabledCheckBox.TabIndex = 41;
        buttonEnabledCheckBox.Text = "Enabled";
        buttonEnabledCheckBox.UseVisualStyleBackColor = true;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(16, 79);
        label5.Name = "label5";
        label5.Size = new Size(146, 25);
        label5.TabIndex = 39;
        label5.Text = "Program Change";
        // 
        // buttonProgramChangeInput
        // 
        buttonProgramChangeInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        buttonProgramChangeInput.Location = new Point(16, 107);
        buttonProgramChangeInput.Maximum = new decimal(new int[] { 127, 0, 0, 0 });
        buttonProgramChangeInput.Name = "buttonProgramChangeInput";
        buttonProgramChangeInput.Size = new Size(238, 31);
        buttonProgramChangeInput.TabIndex = 37;
        // 
        // buttonOverviewListBox
        // 
        buttonOverviewListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        buttonOverviewListBox.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
        buttonOverviewListBox.FormattingEnabled = true;
        buttonOverviewListBox.IntegralHeight = false;
        buttonOverviewListBox.ItemHeight = 22;
        buttonOverviewListBox.Location = new Point(12, 103);
        buttonOverviewListBox.Name = "buttonOverviewListBox";
        buttonOverviewListBox.Size = new Size(270, 211);
        buttonOverviewListBox.TabIndex = 44;
        // 
        // submitButton
        // 
        submitButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        submitButton.Location = new Point(421, 334);
        submitButton.Name = "submitButton";
        submitButton.Size = new Size(138, 34);
        submitButton.TabIndex = 46;
        submitButton.Text = "Write";
        submitButton.UseVisualStyleBackColor = true;
        submitButton.Click += submitButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(571, 403);
        Controls.Add(submitButton);
        Controls.Add(buttonOverviewListBox);
        Controls.Add(groupBox4);
        Controls.Add(label1);
        Controls.Add(controlChannelInput);
        Controls.Add(splitter1);
        Controls.Add(statusStrip1);
        Controls.Add(menuStrip1);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MainMenuStrip = menuStrip1;
        MaximizeBox = false;
        MinimumSize = new Size(500, 350);
        Name = "MainForm";
        Text = "MIDI-Relay";
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)controlChannelInput).EndInit();
        groupBox4.ResumeLayout(false);
        groupBox4.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)buttonProgramChangeInput).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel toolStripStatusLabel;
    private ComboBox comboBox2;
    private ToolStripComboBox toolStripComboBox2;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem deviceToolStripMenuItem;
    private ToolStripMenuItem asdToolStripMenuItem;
    private ToolStripMenuItem adawdToolStripMenuItem;
    private Splitter splitter1;
    private ToolStripMenuItem findToolStripMenuItem;
    private ToolStripStatusLabel serialPortStatusLabel;
    private NumericUpDown controlChannelInput;
    private Label label1;
    private GroupBox groupBox4;
    private Label label5;
    private NumericUpDown buttonProgramChangeInput;
    private CheckBox buttonEnabledCheckBox;
    private ListBox buttonOverviewListBox;
    private Button submitButton;
    private ToolStripStatusLabel selectedButtonStatusLabel;
}
