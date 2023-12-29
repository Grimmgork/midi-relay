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
        serialPortComboBox = new ComboBox();
        loadDataButton = new Button();
        editButton = new Button();
        buttonOverviewListBox = new ListBox();
        clearCommandButton = new Button();
        statusStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // statusStrip1
        // 
        statusStrip1.ImageScalingSize = new Size(24, 24);
        statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
        statusStrip1.Location = new Point(0, 262);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Size = new Size(478, 32);
        statusStrip1.SizingGrip = false;
        statusStrip1.TabIndex = 7;
        statusStrip1.Text = "statusStrip1";
        // 
        // toolStripStatusLabel
        // 
        toolStripStatusLabel.Name = "toolStripStatusLabel";
        toolStripStatusLabel.Size = new Size(169, 25);
        toolStripStatusLabel.Text = "toolStripStatusLabel";
        // 
        // serialPortComboBox
        // 
        serialPortComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        serialPortComboBox.FormattingEnabled = true;
        serialPortComboBox.Location = new Point(12, 12);
        serialPortComboBox.Name = "serialPortComboBox";
        serialPortComboBox.Size = new Size(182, 33);
        serialPortComboBox.TabIndex = 22;
        // 
        // loadDataButton
        // 
        loadDataButton.Location = new Point(200, 12);
        loadDataButton.Name = "loadDataButton";
        loadDataButton.RightToLeft = RightToLeft.No;
        loadDataButton.Size = new Size(86, 34);
        loadDataButton.TabIndex = 23;
        loadDataButton.Text = "load";
        loadDataButton.UseVisualStyleBackColor = true;
        loadDataButton.Click += loadDataButton_Click;
        // 
        // editButton
        // 
        editButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        editButton.Location = new Point(354, 92);
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
        buttonOverviewListBox.Location = new Point(12, 52);
        buttonOverviewListBox.Name = "buttonOverviewListBox";
        buttonOverviewListBox.Size = new Size(336, 167);
        buttonOverviewListBox.TabIndex = 19;
        // 
        // clearCommandButton
        // 
        clearCommandButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        clearCommandButton.Location = new Point(354, 52);
        clearCommandButton.Name = "clearCommandButton";
        clearCommandButton.Size = new Size(112, 34);
        clearCommandButton.TabIndex = 24;
        clearCommandButton.Text = "Clear";
        clearCommandButton.UseVisualStyleBackColor = true;
        clearCommandButton.Click += clearCommandButton_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(478, 294);
        Controls.Add(clearCommandButton);
        Controls.Add(editButton);
        Controls.Add(buttonOverviewListBox);
        Controls.Add(loadDataButton);
        Controls.Add(serialPortComboBox);
        Controls.Add(statusStrip1);
        MaximizeBox = false;
        MinimumSize = new Size(500, 350);
        Name = "Form1";
        Text = "MIDI-Relay";
        Load += Form1_Load;
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
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
    private Button loadDataButton;
    private Button editButton;
    private ListBox buttonOverviewListBox;
    private Button clearCommandButton;
}
