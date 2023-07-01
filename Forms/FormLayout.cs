using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Logic.Questions;
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
    public partial class FormLayout : Form
    {
        public IQuestionService questionService { get; set; }
        public FormLayout()
        {
            InitializeComponent();
        }

        private void labelMainBarTitle_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Question question=new Question(67,"ALI-----",1,46);
            questionService.add(question);
        }
    }
}
