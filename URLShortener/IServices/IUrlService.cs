using URLShortener.Models;

namespace URLShortener.Services
{
    public interface IUrlService :IService<UrlManagement>
    {
        Task<UrlManagement> GetShortUrl(string shortUrl);

        Task<UrlManagement> GetCurrentUrlByShortUrl(string shortUrl);


    }
}
