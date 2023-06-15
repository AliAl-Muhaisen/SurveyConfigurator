using SurveyConfiguratorApp.Forms.Questions;
using SurveyConfiguratorApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.Forms
{
    public partial class FormQuestion : Form
    {
        private Button currentButton;
   
        public FormQuestion()
        {
            InitializeComponent();
            layoutControl1.changeTitle("Questions");
            layoutControl1.addToPanelSideBar(panelSideBarChild);
            panelSideBarChild.BackColor = layoutControl1.PanelSideBarColor;
           // panelSideBarChild.Dock = DockStyle.Top;
            panelSideBarChild.Padding = new Padding(5,0,0,0);
            currentButton = buttonStarsQuestion;


        }
  

        private void FormQuestion_Load(object sender, EventArgs e)
        {
          
        }

       
        private void layoutControl1_Load(object sender, EventArgs e)
        {
            layoutControl1.OpenChildForm(new FormStarsQuestion());
        }

        private void buttonSmileyQuestion_Click(object sender, EventArgs e)
        {
            
            
            if(sender!=null && (Button)sender!=currentButton)
                layoutControl1.OpenChildForm(new FormFacesQuestion());

            currentButton = (Button)sender;
        }

        private void buttonStarsQuestion_Click(object sender, EventArgs e)
        {
            if (sender != null  && (Button)sender != currentButton)
                layoutControl1.OpenChildForm(new FormStarsQuestion());
           
            currentButton = (Button)sender;
        }

        private void buttonSliderQuestion_Click(object sender, EventArgs e)
        {
            if (sender != null && (Button)sender != currentButton)
                layoutControl1.OpenChildForm(new FormSliderQuestion());

            currentButton = (Button)sender;
        }
    }
}
