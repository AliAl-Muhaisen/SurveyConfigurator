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
    public partial class CustomForm : Form
    {
        public CustomForm()
        {
            InitializeComponent();
        }
        private const int WM_NCHITTEST = 0x0084;
        private const int HTCLIENT = 1;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST)
            {
                m.Result = (IntPtr)HTCLIENT;
            }
        }
    }
}
