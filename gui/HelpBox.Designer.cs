namespace gui
{
    partial class HelpBox
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
            closeButton = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // closeButton
            // 
            closeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            closeButton.Location = new Point(292, 287);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(112, 34);
            closeButton.TabIndex = 0;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(12, 12);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(392, 269);
            textBox1.TabIndex = 1;
            textBox1.Text = "(C) KEO Music 2025\r\n\r\nKarl Eike Oppermann\r\nUdenbörner Str. 2\r\n34582 Borken (Hessen)\r\nkarl-eike.oppermann@t-online.de\r\n\r\nDeveloper:\r\nEric Armbruster\r\nericarmbruster@gmx.de";
            // 
            // HelpBox
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 333);
            Controls.Add(textBox1);
            Controls.Add(closeButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "HelpBox";
            StartPosition = FormStartPosition.CenterParent;
            Text = "About";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button closeButton;
        private TextBox textBox1;
    }
}