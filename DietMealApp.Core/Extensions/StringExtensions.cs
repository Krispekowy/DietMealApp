using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;

namespace DietMealApp.Core.Extensions
{
    public static class StringExtensions
    {
        public static string Base64ForUrlEncode(this string str)
        {
            byte[] encbuff = Encoding.UTF8.GetBytes(str);
            return System.Web.HttpUtility.UrlEncode(encbuff);
        }

        public static string Base64ForUrlDecode(this string str)
        {
            byte[] decbuff = System.Web.HttpUtility.UrlDecodeToBytes(str);
            return Encoding.UTF8.GetString(decbuff);
        }
    }
}
