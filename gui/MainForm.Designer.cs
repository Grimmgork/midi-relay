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
        closeButton = new Button();
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
        statusStrip1.Location = new Point(0, 474);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Padding = new Padding(1, 0, 18, 0);
        statusStrip1.ShowItemToolTips = true;
        statusStrip1.Size = new Size(742, 42);
        statusStrip1.SizingGrip = false;
        statusStrip1.TabIndex = 7;
        statusStrip1.Text = "statusStrip1";
        // 
        // toolStripStatusLabel
        // 
        toolStripStatusLabel.AutoToolTip = true;
        toolStripStatusLabel.Name = "toolStripStatusLabel";
        toolStripStatusLabel.Size = new Size(70, 32);
        toolStripStatusLabel.Text = "Hello";
        toolStripStatusLabel.ToolTipText = "Error occured";
        // 
        // serialPortStatusLabel
        // 
        serialPortStatusLabel.Name = "serialPortStatusLabel";
        serialPortStatusLabel.Size = new Size(0, 32);
        // 
        // selectedButtonStatusLabel
        // 
        selectedButtonStatusLabel.Name = "selectedButtonStatusLabel";
        selectedButtonStatusLabel.Size = new Size(0, 32);
        // 
        // menuStrip1
        // 
        menuStrip1.ImageScalingSize = new Size(24, 24);
        menuStrip1.Items.AddRange(new ToolStripItem[] { deviceToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Padding = new Padding(8, 3, 0, 3);
        menuStrip1.Size = new Size(742, 42);
        menuStrip1.TabIndex = 26;
        menuStrip1.Text = "menuStrip1";
        // 
        // deviceToolStripMenuItem
        // 
        deviceToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { findToolStripMenuItem, asdToolStripMenuItem, adawdToolStripMenuItem });
        deviceToolStripMenuItem.Name = "deviceToolStripMenuItem";
        deviceToolStripMenuItem.Size = new Size(106, 36);
        deviceToolStripMenuItem.Text = "Device";
        // 
        // findToolStripMenuItem
        // 
        findToolStripMenuItem.Name = "findToolStripMenuItem";
        findToolStripMenuItem.Size = new Size(216, 44);
        findToolStripMenuItem.Text = "find";
        // 
        // asdToolStripMenuItem
        // 
        asdToolStripMenuItem.Name = "asdToolStripMenuItem";
        asdToolStripMenuItem.Size = new Size(216, 44);
        asdToolStripMenuItem.Text = "asd";
        // 
        // adawdToolStripMenuItem
        // 
        adawdToolStripMenuItem.Checked = true;
        adawdToolStripMenuItem.CheckState = CheckState.Checked;
        adawdToolStripMenuItem.Name = "adawdToolStripMenuItem";
        adawdToolStripMenuItem.Size = new Size(216, 44);
        adawdToolStripMenuItem.Text = "adawd";
        // 
        // splitter1
        // 
        splitter1.Location = new Point(0, 42);
        splitter1.Margin = new Padding(4);
        splitter1.Name = "splitter1";
        splitter1.Size = new Size(5, 432);
        splitter1.TabIndex = 27;
        splitter1.TabStop = false;
        // 
        // controlChannelInput
        // 
        controlChannelInput.Location = new Point(118, 64);
        controlChannelInput.Margin = new Padding(4);
        controlChannelInput.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
        controlChannelInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        controlChannelInput.Name = "controlChannelInput";
        controlChannelInput.Size = new Size(248, 39);
        controlChannelInput.TabIndex = 28;
        controlChannelInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(13, 67);
        label1.Margin = new Padding(4, 0, 4, 0);
        label1.Name = "label1";
        label1.Size = new Size(102, 32);
        label1.TabIndex = 29;
        label1.Text = "Channel";
        // 
        // groupBox4
        // 
        groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupBox4.Controls.Add(buttonEnabledCheckBox);
        groupBox4.Controls.Add(label5);
        groupBox4.Controls.Add(buttonProgramChangeInput);
        groupBox4.Location = new Point(374, 132);
        groupBox4.Margin = new Padding(4);
        groupBox4.Name = "groupBox4";
        groupBox4.Padding = new Padding(4);
        groupBox4.Size = new Size(352, 270);
        groupBox4.TabIndex = 43;
        groupBox4.TabStop = false;
        groupBox4.Text = "Button";
        // 
        // buttonEnabledCheckBox
        // 
        buttonEnabledCheckBox.AutoSize = true;
        buttonEnabledCheckBox.Location = new Point(21, 47);
        buttonEnabledCheckBox.Margin = new Padding(4);
        buttonEnabledCheckBox.Name = "buttonEnabledCheckBox";
        buttonEnabledCheckBox.Size = new Size(131, 36);
        buttonEnabledCheckBox.TabIndex = 41;
        buttonEnabledCheckBox.Text = "Enabled";
        buttonEnabledCheckBox.UseVisualStyleBackColor = true;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(21, 101);
        label5.Margin = new Padding(4, 0, 4, 0);
        label5.Name = "label5";
        label5.Size = new Size(193, 32);
        label5.TabIndex = 39;
        label5.Text = "Program Change";
        // 
        // buttonProgramChangeInput
        // 
        buttonProgramChangeInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        buttonProgramChangeInput.Location = new Point(21, 137);
        buttonProgramChangeInput.Margin = new Padding(4);
        buttonProgramChangeInput.Maximum = new decimal(new int[] { 127, 0, 0, 0 });
        buttonProgramChangeInput.Name = "buttonProgramChangeInput";
        buttonProgramChangeInput.Size = new Size(309, 39);
        buttonProgramChangeInput.TabIndex = 37;
        // 
        // buttonOverviewListBox
        // 
        buttonOverviewListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        buttonOverviewListBox.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
        buttonOverviewListBox.FormattingEnabled = true;
        buttonOverviewListBox.IntegralHeight = false;
        buttonOverviewListBox.ItemHeight = 28;
        buttonOverviewListBox.Location = new Point(16, 132);
        buttonOverviewListBox.Margin = new Padding(4);
        buttonOverviewListBox.Name = "buttonOverviewListBox";
        buttonOverviewListBox.Size = new Size(350, 269);
        buttonOverviewListBox.TabIndex = 44;
        // 
        // submitButton
        // 
        submitButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        submitButton.Location = new Point(563, 423);
        submitButton.Margin = new Padding(4);
        submitButton.Name = "submitButton";
        submitButton.Size = new Size(163, 47);
        submitButton.TabIndex = 46;
        submitButton.Text = "Write";
        submitButton.UseVisualStyleBackColor = true;
        submitButton.Click += submitButton_Click;
        // 
        // closeButton
        // 
        closeButton.Location = new Point(406, 424);
        closeButton.Name = "closeButton";
        closeButton.Size = new Size(150, 46);
        closeButton.TabIndex = 47;
        closeButton.Text = "Close";
        closeButton.UseVisualStyleBackColor = true;
        closeButton.Click += closeButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(13F, 32F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(742, 516);
        Controls.Add(closeButton);
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
        Margin = new Padding(4);
        MaximizeBox = false;
        MinimumSize = new Size(642, 428);
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
    private Button closeButton;
}
