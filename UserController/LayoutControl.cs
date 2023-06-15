using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.UserController
{
    public partial class LayoutControl : UserControl
    {
        private Form activeForm;
        public LayoutControl()
        {
            InitializeComponent();
        }

        

        private void LayoutControl_Load(object sender, EventArgs e)
        {

        }

        private void labelMainBarTitle_Click(object sender, EventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        public void changeTitle(string title)
        {
            labelMainBarTitle.Text = title;
        }

        public void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();

            }
            if (childForm == activeForm)
                return;

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        public void addToPanelSideBar(Control control)
        {
            if (control == null)
                return;

            panelSideBar.Controls.Add(control);
        }

        public Color PanelSideBarColor { 
            get {
                return panelSideBar.BackColor;
            }
        }
    }
}
