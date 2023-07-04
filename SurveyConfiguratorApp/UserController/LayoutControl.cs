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

            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
            }
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

            try
            {
                labelMainBarTitle.Text = title;
            }
            catch (Exception ex)
            {
            }
        }

        public void OpenChildForm(Form childForm)
        {


            try
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
            catch (Exception ex)
            {
            }

        }

        public void addToPanelSideBar(Control control)
        {
            try
            {
                if (control == null)
                    return;

                panelSideBar.Controls.Add(control);
            }
            catch (Exception ex)
            {
            }

        }

        public Color PanelSideBarColor
        {
            get
            {
                return panelSideBar.BackColor;
            }
        }

       
    }
}
