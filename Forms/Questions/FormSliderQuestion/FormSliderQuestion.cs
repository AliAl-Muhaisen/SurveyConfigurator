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

namespace SurveyConfiguratorApp.Forms.Questions
{
    public partial class FormSliderQuestion : Form
    {
        public FormSliderQuestion()
        {
            InitializeComponent();
            minMaxNumControl1.setLabelTitleText("Slider Values");
            customLabelControlTitleCaption.changeText("Captions");
            customLabelControlMin.changeText("Min");
            customLabelControlMax.changeText("Max");
        }
    }
}
