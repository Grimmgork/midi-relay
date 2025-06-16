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
        selectedTargetStatusLabel = new ToolStripStatusLabel();
        spacerStatusLabel = new ToolStripStatusLabel();
        menuStrip1 = new MenuStrip();
        deviceToolStripMenuItem = new ToolStripMenuItem();
        findToolStripMenuItem = new ToolStripMenuItem();
        asdToolStripMenuItem = new ToolStripMenuItem();
        adawdToolStripMenuItem = new ToolStripMenuItem();
        targetToolStripMenuItem = new ToolStripMenuItem();
        splitter1 = new Splitter();
        controlChannelInput = new NumericUpDown();
        label1 = new Label();
        label2 = new Label();
        programChangeComboBox = new ComboBox();
        buttonOverviewListBox = new ListBox();
        submitButton = new Button();
        closeButton = new Button();
        removeProgramChangeButton = new Button();
        statusStrip1.SuspendLayout();
        menuStrip1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)controlChannelInput).BeginInit();
        SuspendLayout();
        // 
        // statusStrip1
        // 
        statusStrip1.ImageScalingSize = new Size(24, 24);
        statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel, serialPortStatusLabel, selectedTargetStatusLabel, spacerStatusLabel });
        statusStrip1.Location = new Point(0, 338);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.ShowItemToolTips = true;
        statusStrip1.Size = new Size(609, 32);
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
        serialPortStatusLabel.Size = new Size(65, 25);
        serialPortStatusLabel.Text = "adawd";
        // 
        // selectedTargetStatusLabel
        // 
        selectedTargetStatusLabel.Name = "selectedTargetStatusLabel";
        selectedTargetStatusLabel.RightToLeft = RightToLeft.No;
        selectedTargetStatusLabel.Size = new Size(50, 25);
        selectedTargetStatusLabel.Text = "pa5x";
        selectedTargetStatusLabel.ToolTipText = "Target";
        // 
        // spacerStatusLabel
        // 
        spacerStatusLabel.Name = "spacerStatusLabel";
        spacerStatusLabel.Size = new Size(426, 25);
        spacerStatusLabel.Spring = true;
        // 
        // menuStrip1
        // 
        menuStrip1.ImageScalingSize = new Size(24, 24);
        menuStrip1.Items.AddRange(new ToolStripItem[] { deviceToolStripMenuItem, targetToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(609, 33);
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
        // targetToolStripMenuItem
        // 
        targetToolStripMenuItem.Name = "targetToolStripMenuItem";
        targetToolStripMenuItem.Size = new Size(76, 29);
        targetToolStripMenuItem.Text = "Target";
        // 
        // splitter1
        // 
        splitter1.Location = new Point(0, 33);
        splitter1.Name = "splitter1";
        splitter1.Size = new Size(4, 305);
        splitter1.TabIndex = 27;
        splitter1.TabStop = false;
        // 
        // controlChannelInput
        // 
        controlChannelInput.CausesValidation = false;
        controlChannelInput.Location = new Point(113, 56);
        controlChannelInput.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
        controlChannelInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        controlChannelInput.Name = "controlChannelInput";
        controlChannelInput.Size = new Size(185, 31);
        controlChannelInput.TabIndex = 1;
        controlChannelInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 58);
        label1.Name = "label1";
        label1.Size = new Size(75, 25);
        label1.TabIndex = 29;
        label1.Text = "Channel";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(308, 101);
        label2.Name = "label2";
        label2.Size = new Size(141, 25);
        label2.TabIndex = 44;
        label2.Text = "ProgramChange";
        // 
        // programChangeComboBox
        // 
        programChangeComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        programChangeComboBox.DropDownHeight = 210;
        programChangeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        programChangeComboBox.FormattingEnabled = true;
        programChangeComboBox.IntegralHeight = false;
        programChangeComboBox.Location = new Point(304, 129);
        programChangeComboBox.Name = "programChangeComboBox";
        programChangeComboBox.Size = new Size(293, 33);
        programChangeComboBox.TabIndex = 3;
        programChangeComboBox.SelectedIndexChanged += programChangeComboBox_SelectedIndexChanged;
        // 
        // buttonOverviewListBox
        // 
        buttonOverviewListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        buttonOverviewListBox.Font = new Font("Consolas", 9F);
        buttonOverviewListBox.FormattingEnabled = true;
        buttonOverviewListBox.IntegralHeight = false;
        buttonOverviewListBox.ItemHeight = 22;
        buttonOverviewListBox.Location = new Point(12, 93);
        buttonOverviewListBox.Name = "buttonOverviewListBox";
        buttonOverviewListBox.Size = new Size(286, 180);
        buttonOverviewListBox.TabIndex = 2;
        // 
        // submitButton
        // 
        submitButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        submitButton.Location = new Point(454, 283);
        submitButton.Name = "submitButton";
        submitButton.Size = new Size(143, 37);
        submitButton.TabIndex = 46;
        submitButton.Text = "Write";
        submitButton.UseVisualStyleBackColor = true;
        submitButton.Click += submitButton_Click;
        // 
        // closeButton
        // 
        closeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        closeButton.Location = new Point(304, 283);
        closeButton.Margin = new Padding(2);
        closeButton.Name = "closeButton";
        closeButton.Size = new Size(145, 37);
        closeButton.TabIndex = 47;
        closeButton.Text = "Close";
        closeButton.UseVisualStyleBackColor = true;
        closeButton.Click += closeButton_Click;
        // 
        // removeProgramChangeButton
        // 
        removeProgramChangeButton.Location = new Point(485, 168);
        removeProgramChangeButton.Name = "removeProgramChangeButton";
        removeProgramChangeButton.Size = new Size(112, 34);
        removeProgramChangeButton.TabIndex = 4;
        removeProgramChangeButton.Text = "Remove";
        removeProgramChangeButton.UseVisualStyleBackColor = true;
        removeProgramChangeButton.Click += removeProgramChangeButton_Click_1;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(609, 370);
        Controls.Add(removeProgramChangeButton);
        Controls.Add(closeButton);
        Controls.Add(label2);
        Controls.Add(submitButton);
        Controls.Add(programChangeComboBox);
        Controls.Add(buttonOverviewListBox);
        Controls.Add(label1);
        Controls.Add(controlChannelInput);
        Controls.Add(splitter1);
        Controls.Add(statusStrip1);
        Controls.Add(menuStrip1);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MainMenuStrip = menuStrip1;
        MaximizeBox = false;
        MinimumSize = new Size(499, 347);
        Name = "MainForm";
        Text = "MIDI-Relay v0.1.2 pa5x";
        Load += MainForm_Load;
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)controlChannelInput).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel toolStripStatusLabel;
    private ComboBox programChangeComboBox;
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
    private ListBox buttonOverviewListBox;
    private Button submitButton;
    private Button closeButton;
    private ToolStripMenuItem targetToolStripMenuItem;
    private ToolStripStatusLabel selectedTargetStatusLabel;
    private ToolStripStatusLabel spacerStatusLabel;
    private Label label2;
    private Button removeProgramChangeButton;
}
