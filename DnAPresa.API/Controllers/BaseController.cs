using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Carter.HondaCrossdock.UI.Controllers
{
    public class BaseController : ApiController
    {
        public static HttpClient HttpClient = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true });
        public readonly ClaimsPrincipal _User;
        public readonly HttpContext _HttpContext;


        public BaseController()
        {
            IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
            _HttpContext = _httpContextAccessor.HttpContext;
            _User = _httpContextAccessor.HttpContext.User;

            if (string.IsNullOrEmpty(HttpClient.BaseAddress?.ToString()))
            {
                HttpClient.BaseAddress = new Uri("http://localhost:57547/");
            }

            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<HttpResponseMessage> SendAPIRequest(string endPoint, string payload, HttpMethod httpMethod = null)
        {
            try
            {
                HttpResponseMessage response = null;

                if (httpMethod == null)
                {
                    httpMethod = HttpMethod.Post;
                }

                HttpRequestMessage request = new HttpRequestMessage(httpMethod, endPoint)
                {
                    Content = new StringContent(payload,
                        Encoding.UTF8,
                        "application/json")
                };

                await HttpClient.SendAsync(request).ContinueWith(responseTask =>
                {
                    response = responseTask.Result;
                });

                return response;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}