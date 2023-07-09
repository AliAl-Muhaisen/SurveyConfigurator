using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Helper;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.Logic.Questions
{
    public class QuestionListComparer : IComparer
    {
        private readonly int sortColumn;
        private enum SortOrderType
        {
            Descending,
            Ascending
        };

        private readonly string currentSortType;
        public QuestionListComparer(int sortColumn, string sortOrder)
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

      
        public int Compare(object x, object y)
        {
            int result = 0;
            try
            {
                if (x == null || y == null)
                    return result;

                if (x is ListViewItem && y is ListViewItem)
                {
                    ListViewItem itemX = (ListViewItem)x;
                    ListViewItem itemY = (ListViewItem)y;

                    if (itemX.Tag is Question questionX && itemY.Tag is Question questionY)
                    {
                        switch (sortColumn)
                        {
                            case 2:
                                return currentSortType == SortOrderType.Ascending.ToString()
                                    ? string.Compare(questionX.Text, questionY.Text)
                                    : string.Compare(questionY.Text, questionX.Text);
                            case 1:
                                return currentSortType == SortOrderType.Ascending.ToString()
                                    ? string.Compare(questionX.TypeName, questionY.TypeName)
                                    : string.Compare(questionY.TypeName, questionX.TypeName);
                            case 0:
                                return currentSortType == SortOrderType.Ascending.ToString()
                                    ? questionX.Order.CompareTo(questionY.Order)
                                    : questionY.Order.CompareTo(questionX.Order);
                            default:
                                return 0;
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return result;
        }
    }

}
