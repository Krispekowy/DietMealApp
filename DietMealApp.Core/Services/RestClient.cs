using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.Services
{
	public class RestClient
	{
		/*private readonly IHttpContextAccessor _httpContextAccessor;
		public RestClient(IHttpContextAccessor httpContextAccessor) =>
			_httpContextAccessor = httpContextAccessor;*/

		private static readonly HttpClient _client = new HttpClient();
		private string _apiLink { get; set; }
		public RestClient(string apiLink) => _apiLink = apiLink;

		public string ResponseMessage { get; set; }
		public bool IsSuccessful { get; set; }
		public HttpResponseMessage Response { get; set; }


		/// <summary>
		/// Asynchroniczne wysłanie requestu do ApiLink(appsettings.json)/endpoint 
		/// </summary>
		/// <param name="endpoint"></param>
		/// <param name="method"></param>
		/// <param name="data">String do wysłania</param>
		/// <returns>Status</returns>
		public async Task<bool> RequestAsync(string endpoint, HttpMethod method, string data, string senderId)
			=> await makeRequest(endpoint, method, data, senderId);

		/// <summary>
		/// Asynchroniczne wysłanie requestu do ApiLink(appsettings.json)/endpoint 
		/// </summary>
		/// <param name="endpoint"></param>
		/// <param name="method"></param>
		/// <param name="data">Obiekt do wysłania</param>
		/// <returns>Status</returns>
		public async Task<bool> RequestAsync(string endpoint, HttpMethod method, object data, string senderId)
			=> await makeRequest(endpoint, method, data, senderId);

		/// <summary>
		/// Asynchroniczne wysłanie requestu do ApiLink(appsettings.json)/endpoint 
		/// </summary>
		/// <param name="endpoint"></param>
		/// <param name="method"></param>
		/// <param name="data">Obiekt do wysłania (zostanie zserializowany)</param>
		/// <returns>Status</returns>
		public async Task<bool> RequestAsync(string endpoint, HttpMethod method, MultipartFormDataContent data, string senderId)
			=> await makeRequest(endpoint, method, data, senderId);


		private async Task<bool> makeRequest(string endpoint, HttpMethod method, object data, string senderId)
		{
			if (data is string && data as string == "")
				data = null;
			ResponseMessage = null;
			Response = null;
			IsSuccessful = false;


			try
			{
				var uri = new Uri(_apiLink + endpoint);
				Console.WriteLine(uri.ToString());
				var request = new HttpRequestMessage(method, uri);

				//var senderId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
				request.Headers.Add("SenderId", senderId);
				if (data != null)
					if (data is string)
						request.Content = new StringContent(data as string, Encoding.UTF8, "application/json");
					else if (data is MultipartFormDataContent)
						request.Content = data as MultipartFormDataContent;
					else
						request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");


				Response = await _client.SendAsync(request);
				ResponseMessage = await Response.Content.ReadAsStringAsync();

				IsSuccessful = Response.IsSuccessStatusCode;

				return true;
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine(ex.InnerException.Message);
				Response = new HttpResponseMessage(System.Net.HttpStatusCode.ServiceUnavailable);
				ResponseMessage = ex.Message;
				return false;
			}
		}
	}
}
