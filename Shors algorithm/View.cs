using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shors_algorithm
{
    public partial class View : Form
    {
        public event Action OnInput;

        public View()
        {
            InitializeComponent();
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e) => OnInput?.Invoke();

        public void ShowMessage(string s)
        {
            resultLabel.Text = s;
        }

        public void ChangeInputFieldBackgroundColor(Color color)
        {
            inputTextBox.BackColor = color;
        }

        public void SetVisualisationVisibility(bool isVisible)
        {
            pictureBox1.Visible = isVisible;
            label1.Visible = isVisible;
            label2.Visible = isVisible;
            label3.Visible = isVisible;
            label4.Visible = isVisible;
            label5.Visible = isVisible;
            label6.Visible = isVisible;
            label7.Visible = isVisible;
            label8.Visible = isVisible;
        }

        public void SetVisualisationProcessing(bool isProcessing)
        {
            pictureBox1.Enabled = isProcessing;
        }
    }
}
