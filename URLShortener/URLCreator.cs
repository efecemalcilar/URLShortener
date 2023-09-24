//using System;
//using URLShortener.Models;

//namespace URLShortener
//{
//    public class URLCreator
//    {
//        protected readonly ShortenerDbContext _db;
//        public UrlDto url = new UrlDto();
//        public HttpContext _ctx;
//        public  URLCreator()
//        {
//            var random = new Random();

//            const string chars = "ABCDEFGHIJKLMNOPRSTUVWXYZ1234567890";

//            var randomStr = new string(Enumerable.Repeat(chars, 6).Select(x => x[random.Next(x.Length)]).ToArray());

//            var sUrl = new UrlManagement()
//            {
//                Url = url.Url,
//                ShortUrl = randomStr
//            };

//            _db.Urls.Add(sUrl);
//            _db.SaveChanges();

//            var result = $"{_ctx.Request.Scheme}://{_ctx.Request.Host}/{sUrl.ShortUrl}";

//            return Results.Ok(new UrlShortResponseDto()
//            {
//                Url = result
//            });


//        }


        
//    }

//}
