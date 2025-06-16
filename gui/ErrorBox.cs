using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui
{
    public partial class ErrorBox : Form
    {
        public ErrorBox(Exception exception)
        {
            InitializeComponent();
            messageTextBox.Text = exception.Message;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
