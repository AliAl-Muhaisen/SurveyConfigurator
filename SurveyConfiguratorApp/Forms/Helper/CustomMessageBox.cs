using SurveyConfiguratorApp.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.Forms.Helper
{
    public partial class CustomMessageBoxForm : CustomForm
    {
        public CustomMessageBoxForm()
        {
            try
            {
                InitializeComponent();
                this.Paint += MainForm_Paint;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        public static DialogResult Show(string title, string message, bool pDisableCancelButton = true, string pSaveBtnText=null)
        {
            try
            {
                using (var form = new CustomMessageBoxForm())
                {
                    form.Text = title;
                    form.button1.Visible = pDisableCancelButton;
                    form.button1.Text = pSaveBtnText ?? form.button1.Text;
                    form.messageLabel.Text = message;
                 //   form.messageLabel.MaximumSize = new Size(240, 0); // Limit the width, height will adjust automatically
                    return form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
            return DialogResult.Cancel;

        }
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            // Customize the form header color (non-client area)
            using (var brush = new SolidBrush(Color.Yellow)) // Set your desired header color here
            {
                e.Graphics.FillRectangle(brush, new Rectangle(0, 0, this.Width, SystemInformation.CaptionHeight));
            }
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        private void CustomMessageBoxForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }


}
