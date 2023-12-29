namespace gui
{
    partial class UpdateCommandDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            commandTypeComboBox = new ComboBox();
            label1 = new Label();
            button1 = new Button();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // commandTypeComboBox
            // 
            commandTypeComboBox.FormattingEnabled = true;
            commandTypeComboBox.Location = new Point(68, 12);
            commandTypeComboBox.Name = "commandTypeComboBox";
            commandTypeComboBox.Size = new Size(182, 33);
            commandTypeComboBox.TabIndex = 0;
            commandTypeComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 15);
            label1.Name = "label1";
            label1.Size = new Size(51, 25);
            label1.TabIndex = 2;
            label1.Text = "MIDI";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(267, 326);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 3;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(12, 51);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(367, 269);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Arguments";
            // 
            // UpdateCommandDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(391, 372);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(commandTypeComboBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "UpdateCommandDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "UpdateCommandDialog";
            Load += UpdateCommandDialog_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox commandTypeComboBox;
        private Label label1;
        private Button button1;
        private GroupBox groupBox1;
    }
}