using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Policy;
using URLShortener.IRepository;
using URLShortener.Models;

namespace URLShortener.Repositories
{
    public class UrlRepository:GenericRepository<UrlManagement>, IUrlRepository
    {
        protected readonly ShortenerDbContext _db;

        public UrlRepository(ShortenerDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<UrlManagement> GetShortUrl(string shortUrl)
        {
            return await _db.Urls.Where(x => x.ShortUrl == shortUrl).FirstOrDefaultAsync();
        }

        

       
        public async Task<UrlManagement> CreateCustomShortUrl(string shortUrl)
        {

            return await _db.Urls.Where(x => x.ShortUrl == shortUrl).FirstOrDefaultAsync();
        }

        public async Task<UrlManagement> GetCurrentUrlByShortUrl(string url)
        {
            return await _db.Urls.Where(x => x.Url == url).FirstOrDefaultAsync();
        }


       
    }
}
