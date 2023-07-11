using SurveyConfiguratorApp.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.UserController.Controllers
{
    public partial class CustomMessageBoxControl : UserControl
    {

        public CustomMessageBoxControl()
        {
            InitializeComponent();
        }
        public void StatusCodeMessage(StatusCode statusCode)
        {
            try
            {
                switch (statusCode)
                {
                    case StatusCode.ValidationError:
                        MessageBox.Show("Validation errors, Please check the inputs", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case StatusCode.Success:
                        MessageBox.Show("Completed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case StatusCode.Error:

                    default:
                        MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                }

            }
            catch (Exception ex) { Log.Error(ex); }
        }
        public void Add(bool result)
        {
            try
            {
                if (result)
                {
                    // Display success message to the user
                    MessageBox.Show("Record inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    // Display error message to the user
                    MessageBox.Show("An error occurred while inserting the record ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        public void Update(bool result)
        {
            try
            {
                if (result)
                {
                    // Display success message to the user
                    MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    // Display error message to the user
                    MessageBox.Show("No rows updated for Question ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        public void Delete(bool result)
        {
            try
            {
                if (result)
                {
                    // Display success message to the user
                    MessageBox.Show("Record Deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    // Display error message to the user
                    MessageBox.Show("No rows deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }
        public void NotExists()
        {
            try
            {
                MessageBox.Show("This Question does not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}
