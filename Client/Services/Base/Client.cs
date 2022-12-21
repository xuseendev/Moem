namespace MoeSystem.Client.Services.Base
{
    public partial class Client : IClient
    {


        public HttpClient Http
        {
            get
            {
                return _httpClient;
            }
        }

    }
}
