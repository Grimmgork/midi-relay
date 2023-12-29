namespace gui
{
    partial class MidiControlChangeControl
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 16);
            label1.Name = "label1";
            label1.Size = new Size(75, 25);
            label1.TabIndex = 0;
            label1.Text = "Channel";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(140, 16);
            numericUpDown1.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(149, 31);
            numericUpDown1.TabIndex = 1;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(140, 53);
            numericUpDown2.Maximum = new decimal(new int[] { 127, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(149, 31);
            numericUpDown2.TabIndex = 2;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(140, 90);
            numericUpDown3.Maximum = new decimal(new int[] { 127, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(149, 31);
            numericUpDown3.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 55);
            label2.Name = "label2";
            label2.Size = new Size(90, 25);
            label2.TabIndex = 4;
            label2.Text = "Controller";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 90);
            label3.Name = "label3";
            label3.Size = new Size(54, 25);
            label3.TabIndex = 5;
            label3.Text = "Value";
            // 
            // MidiControlChangeControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(numericUpDown3);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(label1);
            Name = "MidiControlChangeControl";
            Size = new Size(304, 135);
            Load += ControlChangeControl_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
        private Label label2;
        private Label label3;
    }
}
