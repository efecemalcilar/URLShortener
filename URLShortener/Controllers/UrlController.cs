using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using URLShortener.IHelpers;
using URLShortener.Models;
using URLShortener.Repositories;
using URLShortener.Services;

namespace URLShortener.Controllers
{
    public class UrlController : BaseController
    {
        private readonly IUrlService _urlService;
        private readonly IMapper _mapper;
        private readonly IUrlControllerHelper _urlControllerHelper;


        public UrlController(IUrlService urlService, IMapper mapper,IUrlControllerHelper urlControllerHelper)
        {
            _urlService = urlService;
            _mapper = mapper;
            _urlControllerHelper = urlControllerHelper;
        }

        //[HttpPost("Shortern")]
        //public async Task<IActionResult> SendUrl(SendUrlDto dto, string url)
        //{
        //    Uri validateUri;
        //    UrlManagement urlInfo;

        //    if (!Uri.TryCreate(url, UriKind.Absolute, out Uri validatedUri))
        //    {
        //        return (BadRequest("Invalid Url"));
        //    }

        //    var shortUrl = _urlControllerHelper.CreateRandomShortUrl();
        //    while (_urlService.Where(x => x.Url == url).Any())
        //    {
        //        shortUrl = _urlControllerHelper.CreateRandomShortUrl();
        //    }
        //    dto.Url = shortUrl;
        //    urlInfo = await _urlService.Addasync(_mapper.Map<UrlManagement>(dto));
        //    return CreateActionResult(ResultDto<SendUrlDto>.Success(201, _mapper.Map<SendUrlDto>(urlInfo)));
        //}

        [HttpPost("Shortern")]
        public async Task<IActionResult> SendUrl(UrlDto dto, string url)
        {
            Uri validateUri;
            UrlManagement urlInfo;

            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri validatedUri))
            {
                return (BadRequest("Invalid Url"));
            }

            var Url = _urlControllerHelper.CreateRandomShortUrl();
            while (_urlService.Where(x => x.ShortUrl == Url).Any())
            {
                Url = _urlControllerHelper.CreateRandomShortUrl();
            }
            dto.shortUrl = Url;
            urlInfo = await _urlService.Addasync(_mapper.Map<UrlManagement>(dto));
            return CreateActionResult(ResultDto<UrlDto>.Success(201, _mapper.Map<UrlDto>(urlInfo)));

        }


        [HttpPost("Custom")]
        public async Task<IActionResult> CustomUrl(UrlDto dto)
        {

            if (dto != null)
            {

                UrlManagement urlInfo;
                if (!string.IsNullOrEmpty(dto.shortUrl) && dto.shortUrl.Length <= 6)
                {
                    var existingUrl = await _urlService.GetCurrentUrlByShortUrl(dto.shortUrl);
                    if (existingUrl != null)
                    {
                        return CreateActionResult(ResultDto<UrlDto>.Success(201, _mapper.Map<UrlDto>(dto)));
                    }
                    urlInfo = await _urlService.Addasync(_mapper.Map<UrlManagement>(dto.Url));

                  
                }
                else
                {
                    var shortUrl = _urlControllerHelper.CreateRandomShortUrl();
                    while (_urlService.Where(x => x.ShortUrl == shortUrl).Any())
                    {
                        shortUrl = _urlControllerHelper.CreateRandomShortUrl();
                    }
                    dto.shortUrl = shortUrl;
                    urlInfo = await _urlService.Addasync(_mapper.Map<UrlManagement>(dto));
                }
                return CreateActionResult(ResultDto<UrlDto>.Success(201, _mapper.Map<UrlDto>(urlInfo)));
            }
            else
            {
                return BadRequest("Invalid Url");
            }

        }





        [HttpGet("CurrentUrlByShortUrl")]
        public async Task<IActionResult> GetUrlWithShortUrl(string shortUrl)
        {
            var urlInfo = await _urlService.GetCurrentUrlByShortUrl(shortUrl);
            return CreateActionResult(ResultDto<UrlDto>.Success(201, _mapper.Map<UrlDto>(urlInfo)));
        }

        //[HttpPost("shorten")]
        //public async Task<IActionResult> Shorten(UrlDto input)
        //{
        //    if (_urlService.ExistLongUrl(input.Url))
        //    {
        //        return Conflict(new ResultDto<string>()
        //        {
        //            IsSuccess = false,
        //            Error = "URL already exist"
        //        });
        //    }

        //    if (!Uri.IsWellFormedUriString(input.Url, UriKind.Absolute))
        //    {
        //        return BadRequest(new ResultDto<string>()
        //        {
        //            IsSuccess = false,
        //            Error = "Invalid Url"
        //        });
        //    }

        //    var shortUrl = Guid.NewGuid().ToString().Substring(0, 6);
        //    _urlRepository.AddShortenedUrl(shortUrl, input.Url);

        //    return Ok(new ResultDto<string>()
        //    {
        //        IsSuccess = true,
        //        Response = shortUrl
        //    });
        //}
        //[HttpPost("shorten/custom")]
        //public IActionResult CustomUrl(UrlShortCustomInput input)
        //{
        //    if (_urlRepository.ExistShortUrl(input.ShortUrl) || _urlRepository.ExistLongUrl(input.Url))
        //    {
        //        return Conflict(new ResultDto<string>()
        //        {IsSuccess=false,
        //        Error = "This record already exist"

        //        });
        //    }

        //    if (!Uri.IsWellFormedUriString(input.Url, UriKind.Absolute))
        //    {
        //        return BadRequest(new ResultDto<string>()
        //        {
        //            IsSuccess=false,
        //            Error= "Invalid Url Format"
        //        });
        //    }
        //    _urlRepository.AddShortenedUrl(input.ShortUrl, input.Url);

        //    return Ok(new ResultDto<string>()
        //    {
        //        IsSuccess=true,
        //        Response=input.ShortUrl
        //    });
        //}
        //[HttpGet("redirect/{shortUrl}")]
        //public IActionResult Redirect(string shortUrl)
        //{
        //    var shortnetedURL = _urlRepository.GetShortUrl(shortUrl);
        //    if (shortnetedURL == null)
        //    {
        //        return NotFound();
        //    }

        //    return RedirectPermanent(shortnetedURL.Url);
        //}
    }
}
