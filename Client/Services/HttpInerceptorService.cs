using Microsoft.AspNetCore.Components;
using System.Net;
using Toolbelt.Blazor;

namespace MoeSystem.Client.Services
{
    public class HttpInerceptorService
    {
        private readonly HttpClientInterceptor _interceptor;
        private readonly NavigationManager _navManager;

        public HttpInerceptorService(HttpClientInterceptor interceptor, NavigationManager navManager)
        {
            _interceptor = interceptor;
            _navManager = navManager;

        }

        public void MonitorEvent() => _interceptor.AfterSend += InterceptResponse;

        private void InterceptResponse(object sender, HttpClientInterceptorEventArgs e)
        {
            var message = string.Empty;
            if (!e.Response.IsSuccessStatusCode)
            {
                var responseCode = e.Response.StatusCode;
                switch (responseCode)
                {
                    case HttpStatusCode.NotFound:
                        _navManager.NavigateTo("/404");
                        message = "The request resource was not found";
                        break;
                    case HttpStatusCode.Unauthorized:
                    case HttpStatusCode.Forbidden:
                        _navManager.NavigateTo("/unauthorized");
                        message = "You are not authorized to access this resource.";
                        break;


                    default:
                        _navManager.NavigateTo("/500");
                        message = "Something went wront, please contact Admin";
                        break;
                }
                throw new HttpRequestException(message);
            }
        }

        public void DisposeEvent() => _interceptor.AfterSend -= InterceptResponse;



    }
}
