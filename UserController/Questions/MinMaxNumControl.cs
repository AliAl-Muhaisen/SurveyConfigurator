using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.UserController.Questions
{
    public partial class MinMaxNumControl : UserControl
    {
        public decimal StartNumMin
        {
            get
            {
                return numericUpDownStart.Minimum;
            }
            set { numericUpDownStart.Minimum = value; }

        }

        public decimal StartNumMax
        {
            get
            {
                return numericUpDownEnd.Maximum;
            }
            set { numericUpDownStart.Maximum = value; }

        }

        public decimal EndNumMin
        {
            get
            {
                return numericUpDownEnd.Minimum;
            }
            set { numericUpDownEnd.Minimum = value; }

        }

        public decimal EndNumMax
        {
            get
            {
                return numericUpDownEnd.Maximum;
            }
            set { numericUpDownEnd.Maximum = value; }

        }

        public MinMaxNumControl()
        {
            InitializeComponent();
            customLabelControlMax.changeText("Max");
            customLabelControlMin.changeText("Min");
        }


        public void setLabelTitleText(string title)
        {
            customLabelControlTitle.changeText(title);
        }

        




    }
}
