using SurveyConfiguratorApp.Domain.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Logic.Questions
{
    public class QuestionComparer : IComparer<Question>
    {
        //private readonly string sortColumn;
        //private readonly SortOrder sortOrder;

        //public QuestionComparer(string sortColumn, SortOrder sortOrder)
        //{
        //    this.sortColumn = sortColumn;
        //    this.sortOrder = sortOrder;
        //}

        //public int Compare(Question x, Question y)
        //{
        //    // Implement the comparison logic based on the selected column
        //    switch (sortColumn)
        //    {
        //        case "Text":
        //            return sortOrder == SortOrder.Ascending
        //                ? string.Compare(x.Text, y.Text)
        //                : string.Compare(y.Text, x.Text);
        //        case "TypeName":
        //            return sortOrder == SortOrder.Ascending
        //                ? string.Compare(x.TypeName, y.TypeName)
        //                : string.Compare(y.TypeName, x.TypeName);
        //        // Add more cases for other columns as needed
        //        default:
        //            return 0;
        //    }
        //}
        public int Compare(Question x, Question y)
        {
            throw new NotImplementedException();
        }
    }

}
