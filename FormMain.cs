using SurveyConfiguratorApp.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyConfiguratorApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new FormQuestion();
            form.ShowDialog();
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
