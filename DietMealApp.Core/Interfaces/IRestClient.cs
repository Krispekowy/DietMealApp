using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.Interfaces
{
    public interface IRestClient
    {
        Task<bool> RequestAsync(string endpoint, HttpMethod method, string data, string senderId);
        Task<bool> RequestAsync(string endpoint, HttpMethod method, object data, string senderId);
        Task<bool> RequestAsync(string endpoint, HttpMethod method, MultipartFormDataContent data, string senderId);
    }
}
