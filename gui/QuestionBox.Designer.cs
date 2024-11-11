namespace gui
{
    partial class QuestionBox
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
            messageText = new Label();
            noButton = new Button();
            yesButton = new Button();
            SuspendLayout();
            // 
            // messageText
            // 
            messageText.AutoSize = true;
            messageText.Location = new Point(12, 9);
            messageText.Name = "messageText";
            messageText.Size = new Size(220, 25);
            messageText.TabIndex = 0;
            messageText.Text = "Discard unsaved changes?";
            // 
            // noButton
            // 
            noButton.Location = new Point(267, 87);
            noButton.Name = "noButton";
            noButton.Size = new Size(112, 34);
            noButton.TabIndex = 1;
            noButton.Text = "No";
            noButton.UseVisualStyleBackColor = true;
            noButton.Click += noButton_Click;
            // 
            // yesButton
            // 
            yesButton.Location = new Point(149, 87);
            yesButton.Name = "yesButton";
            yesButton.Size = new Size(112, 34);
            yesButton.TabIndex = 2;
            yesButton.Text = "Yes";
            yesButton.UseVisualStyleBackColor = true;
            yesButton.Click += yesButton_Click;
            // 
            // QuestionBox
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(391, 132);
            Controls.Add(yesButton);
            Controls.Add(noButton);
            Controls.Add(messageText);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "QuestionBox";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Are you sure?";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label messageText;
        private Button noButton;
        private Button yesButton;
    }
}