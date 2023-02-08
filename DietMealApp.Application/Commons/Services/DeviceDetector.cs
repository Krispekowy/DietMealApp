using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Commons.Services
{
    public class DeviceDetector : IDeviceDetector
    {
        public bool isMobile(string userAgent)
        {
            var isMobile = false;
            if (!string.IsNullOrEmpty(userAgent))
            {
                var mobileKeywords = new[] { "android", "iphone", "ipad", "ipod", "blackberry", "windows phone", "mobile" };
                isMobile = mobileKeywords.Any(keyword => userAgent.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            return isMobile;
        }
    }
}
