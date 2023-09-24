using URLShortener.IRepository;
using URLShortener.Models;
using URLShortener.UnitOfWorks;

namespace URLShortener.Services
{
    public class UrlService : Service<UrlManagement>, IUrlService
    {
        private readonly IUrlRepository _urlRepository;
        public UrlService(IGenericRepository<UrlManagement> repository, IUnitOfWork unitOfWork, IUrlRepository urlRepository) : base(unitOfWork, repository)
        {
            _urlRepository = urlRepository;
        }
        public async Task<UrlManagement> GetCurrentUrlByShortUrl(string shortUrl)
        {
            return await _urlRepository.GetShortUrl(shortUrl);
        }

        public async Task<UrlManagement> GetShortUrl(string shortUrl)
        {
            return await _urlRepository.GetShortUrl(shortUrl);
        }
    }
}
