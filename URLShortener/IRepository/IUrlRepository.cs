using URLShortener.Models;
using URLShortener.Repositories;

namespace URLShortener.IRepository
{
    public interface IUrlRepository : IGenericRepository<UrlManagement>
    {


        public Task<UrlManagement> GetShortUrl(string shortUrl);




        public Task<UrlManagement> GetCurrentUrlByShortUrl(string shortUrl);




    }
}
