using URLShortener.Models;

namespace URLShortener.Services
{
    public interface IUrlService :IService<UrlManagement>
    {
        Task<UrlManagement> GetShortUrl(string shortUrl);
        //public Task<UrlManagement> GetLongUrl(string longUrl);
        //public Task<UrlManagement> ExistShortUrl(string shortUrl);
        //public Task<UrlManagement> ExistLongUrl(string longUrl);
        //public Task<UrlManagement> AddShortenedUrl(string shortUrl, string url);

        Task<UrlManagement> GetCurrentUrlByShortUrl(string shortUrl);


    }
}
