namespace gui;

partial class Form1
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
        serialPortComboBox = new ComboBox();
        editButton = new Button();
        buttonOverviewListBox = new ListBox();
        clearCommandButton = new Button();
        menuStrip1 = new MenuStrip();
        deviceToolStripMenuItem = new ToolStripMenuItem();
        findToolStripMenuItem = new ToolStripMenuItem();
        asdToolStripMenuItem = new ToolStripMenuItem();
        adawdToolStripMenuItem = new ToolStripMenuItem();
        splitter1 = new Splitter();
        statusStrip1.SuspendLayout();
        menuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // statusStrip1
        // 
        statusStrip1.ImageScalingSize = new Size(24, 24);
        statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel, serialPortStatusLabel });
        statusStrip1.Location = new Point(0, 340);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.ShowItemToolTips = true;
        statusStrip1.Size = new Size(568, 32);
        statusStrip1.SizingGrip = false;
        statusStrip1.TabIndex = 7;
        statusStrip1.Text = "statusStrip1";
        // 
        // toolStripStatusLabel
        // 
        toolStripStatusLabel.AutoToolTip = true;
        toolStripStatusLabel.Name = "toolStripStatusLabel";
        toolStripStatusLabel.Size = new Size(169, 25);
        toolStripStatusLabel.Text = "toolStripStatusLabel";
        toolStripStatusLabel.ToolTipText = "Error occured";
        // 
        // serialPortStatusLabel
        // 
        serialPortStatusLabel.Name = "serialPortStatusLabel";
        serialPortStatusLabel.Size = new Size(173, 25);
        serialPortStatusLabel.Text = "serialPortStatusLabel";
        // 
        // serialPortComboBox
        // 
        serialPortComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        serialPortComboBox.FormattingEnabled = true;
        serialPortComboBox.Location = new Point(131, 118);
        serialPortComboBox.Name = "serialPortComboBox";
        serialPortComboBox.Size = new Size(182, 33);
        serialPortComboBox.TabIndex = 22;
        // 
        // editButton
        // 
        editButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        editButton.Location = new Point(444, 85);
        editButton.Name = "editButton";
        editButton.Size = new Size(112, 34);
        editButton.TabIndex = 11;
        editButton.Text = "Update";
        editButton.UseVisualStyleBackColor = true;
        editButton.Click += editButton_Click;
        // 
        // buttonOverviewListBox
        // 
        buttonOverviewListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        buttonOverviewListBox.BackColor = SystemColors.ButtonHighlight;
        buttonOverviewListBox.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
        buttonOverviewListBox.FormattingEnabled = true;
        buttonOverviewListBox.IntegralHeight = false;
        buttonOverviewListBox.ItemHeight = 22;
        buttonOverviewListBox.Location = new Point(12, 45);
        buttonOverviewListBox.Name = "buttonOverviewListBox";
        buttonOverviewListBox.Size = new Size(426, 286);
        buttonOverviewListBox.TabIndex = 19;
        // 
        // clearCommandButton
        // 
        clearCommandButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        clearCommandButton.Location = new Point(444, 45);
        clearCommandButton.Name = "clearCommandButton";
        clearCommandButton.Size = new Size(112, 34);
        clearCommandButton.TabIndex = 24;
        clearCommandButton.Text = "Clear";
        clearCommandButton.UseVisualStyleBackColor = true;
        clearCommandButton.Click += clearCommandButton_Click;
        // 
        // menuStrip1
        // 
        menuStrip1.ImageScalingSize = new Size(24, 24);
        menuStrip1.Items.AddRange(new ToolStripItem[] { deviceToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(568, 33);
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
        findToolStripMenuItem.Size = new Size(270, 34);
        findToolStripMenuItem.Text = "find";
        // 
        // asdToolStripMenuItem
        // 
        asdToolStripMenuItem.Name = "asdToolStripMenuItem";
        asdToolStripMenuItem.Size = new Size(270, 34);
        asdToolStripMenuItem.Text = "asd";
        // 
        // adawdToolStripMenuItem
        // 
        adawdToolStripMenuItem.Checked = true;
        adawdToolStripMenuItem.CheckState = CheckState.Checked;
        adawdToolStripMenuItem.Name = "adawdToolStripMenuItem";
        adawdToolStripMenuItem.Size = new Size(270, 34);
        adawdToolStripMenuItem.Text = "adawd";
        // 
        // splitter1
        // 
        splitter1.Location = new Point(0, 33);
        splitter1.Name = "splitter1";
        splitter1.Size = new Size(4, 307);
        splitter1.TabIndex = 27;
        splitter1.TabStop = false;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(568, 372);
        Controls.Add(splitter1);
        Controls.Add(clearCommandButton);
        Controls.Add(editButton);
        Controls.Add(buttonOverviewListBox);
        Controls.Add(serialPortComboBox);
        Controls.Add(statusStrip1);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        MaximizeBox = false;
        MinimumSize = new Size(500, 350);
        Name = "Form1";
        Text = "MIDI-Relay";
        Load += Form1_Load;
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel toolStripStatusLabel;
    private ComboBox comboBox2;
    private Label label3;
    private ToolStripComboBox toolStripComboBox2;
    private Label label4;
    private ComboBox serialPortComboBox;
    private Button editButton;
    private ListBox buttonOverviewListBox;
    private Button clearCommandButton;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem deviceToolStripMenuItem;
    private ToolStripMenuItem asdToolStripMenuItem;
    private ToolStripMenuItem adawdToolStripMenuItem;
    private Splitter splitter1;
    private ToolStripMenuItem findToolStripMenuItem;
    private ToolStripStatusLabel serialPortStatusLabel;
}
