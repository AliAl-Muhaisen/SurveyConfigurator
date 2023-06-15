using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace SurveyConfiguratorApp.UserController.Controllers
{
    public partial class CustomLabelControl : UserControl
    {
        public CustomLabelControl()
        {
            InitializeComponent();
        }

        public void changeText(string text)
        {
            labelText.Text = text;
        }

    }
}
