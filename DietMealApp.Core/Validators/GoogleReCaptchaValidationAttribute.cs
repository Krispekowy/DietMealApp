using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.Validators
{
    public class GoogleReCaptchaValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                value = "";
            }
            IConfiguration configuration = (IConfiguration)validationContext.GetService(typeof(IConfiguration));
            string reCaptchResponse = value.ToString();
            string reCaptchaSecret = configuration.GetValue<string>("GoogleReCaptcha:SecretKey");
            var payload = $"&secret={reCaptchaSecret}&remoteip={""}&response={reCaptchResponse}";
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://www.google.com");
            var request = new HttpRequestMessage(HttpMethod.Post, "/recaptcha/api/siteverify");
            request.Content = new StringContent(payload, Encoding.UTF8, "application/x-www-form-urlencoded");
            var httpResponse = httpClient.SendAsync(request).Result;
            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                return new ValidationResult("Wystąpił błąd podczas przetwarzanie Google reCaptcha");
            }

            string jsonResponse = httpResponse.Content.ReadAsStringAsync().Result;
            dynamic jsonData = JObject.Parse(jsonResponse);
            if (jsonData.success != true.ToString().ToLower())
            {
                return new ValidationResult("Musisz przejść przez weryfikacje reCaptcha");
            }

            return ValidationResult.Success;
        }
    }
}
