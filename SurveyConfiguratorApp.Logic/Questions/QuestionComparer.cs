using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Helper;
using System;
using System.Collections.Generic;

namespace SurveyConfiguratorApp.Logic.Questions
{
    public class QuestionComparer : IComparer<Question>
    {
        private readonly string sortColumn;
        private enum SortOrderType
        {
            Descending,
            Ascending
        };

        private readonly string currentSortType;
        public QuestionComparer(string sortColumn, string sortOrder)
        {
            try
            {
                this.sortColumn = sortColumn;
                this.currentSortType = sortOrder;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        public int Compare(Question x, Question y)
        {
            try
            {
                // Implement the comparison logic based on the selected column
                switch (sortColumn)
                {
                    case "Text":
                        return currentSortType == (SortOrderType.Ascending).ToString()
                            ? string.Compare(x.Text, y.Text)//It returns a negative value if x.Text is less than y.Text
                            : string.Compare(y.Text, x.Text);
                    case "TypeName":
                        return currentSortType == (SortOrderType.Ascending).ToString()
                            ? string.Compare(x.TypeName, y.TypeName)
                            : string.Compare(y.TypeName, x.TypeName);

                    case "Order":
                        return currentSortType == (SortOrderType.Ascending).ToString()
                             ? x.Order.CompareTo(y.Order)//The CompareTo method returns a negative value if x.Order is less than y.Order
                            : y.Order.CompareTo(x.Order);

                    default:
                        return 0;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
            return 0;

        }

       
    }

}
