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
    public partial class LabelErrorControl : UserControl
    {
       
        public LabelErrorControl()
        {
            InitializeComponent();
          
        }

        public void setText(string text)
        {
            labelError.Text = text;
        }
        public void clearText()
        {
            labelError.Text = null;
        }
        
    }
}
