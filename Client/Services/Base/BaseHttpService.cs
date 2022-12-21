﻿using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace MoeSystem.Client.Services.Base
{
    public class BaseHttpService
    {
        private readonly IClient client;
        private readonly ILocalStorageService localStorage;

        public BaseHttpService(IClient client, ILocalStorageService localStorage)
        {
            this.client = client;
            this.localStorage = localStorage;
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException apiException)
        {
            if (apiException.StatusCode == 400)
            {
                return new Response<Guid>() { Message = "Validation error have occured.", ValidationError = apiException.Message, Success = false };
            }
            if (apiException.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "The requested item could not be found", Success = false };
            }
            if (apiException.StatusCode >= 200 && apiException.StatusCode <= 299)
            {
                return new Response<Guid> { Message = "Operation Reported Success", Success = true };
            }

            return new Response<Guid>() { Message = "Something went wrong, please try again.", Success = false };
        }

        protected async Task GetBearerToken()
        {
            var token = await localStorage.GetItemAsync<string>("accessToken");
            if (token != null)
            {
                client.Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            }
        }
    }
}
