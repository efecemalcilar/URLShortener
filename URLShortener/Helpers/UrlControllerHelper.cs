using URLShortener.IHelpers;

namespace URLShortener.Helpers
{
    public class UrlControllerHelper : IUrlControllerHelper
    {
        public string CreateRandomShortUrl()
        {
            var randomUrl = Guid.NewGuid();
            return randomUrl.ToString()[..6];
        }
    }
}
