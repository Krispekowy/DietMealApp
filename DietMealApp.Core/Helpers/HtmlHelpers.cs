using System;
using System.Collections.Generic;
using System.Text;

namespace MealApp.Models.Helpers
{
    public static class HtmlHelpers<T>
    {
        public static string GetTableFromList(List<T> list, params Func<T, object>[] fxns)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<TABLE>\n");
            foreach (var item in list)
            {
                sb.Append("<TR>\n");
                foreach (var fxn in fxns)
                {
                    sb.Append("<TD>");
                    sb.Append(fxn(item));
                    sb.Append("</TD>");
                }
                sb.Append("</TR>\n");
            }
            sb.Append("</TABLE>");

            return sb.ToString();
        }
    }
}
