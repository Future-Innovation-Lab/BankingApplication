using System.Net.Http;

namespace BankingAppMobile.Services.Interfaces
{
    public interface IHttpNativeHandler
    {
        HttpClientHandler GetHttpClientHandler();
    }
}