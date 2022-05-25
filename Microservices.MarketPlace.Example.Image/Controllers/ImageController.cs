using Microservices.MarketPlace.Example.CommonUses.Base;
using Microservices.MarketPlace.Example.CommonUses.Result;
using Microservices.MarketPlace.Example.Image.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Image.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : CustomBaseController
    {
        [HttpPost]
        public async Task<IActionResult> PhotoSave(IFormFile image, CancellationToken cancellationToken)
        {
            //CancellationToken : Kullanıcı kaydetme işlemini iptal ettiğinde burada da iptal edilsin.
            if (image != null && image.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", image.FileName);

                using var stream = new FileStream(path, FileMode.Create);
                await image.CopyToAsync(stream, cancellationToken);

                var returnPath = image.FileName;

                ImageDto imageDto = new() { Url = returnPath };

                return CreateActionResultInstance(Response<ImageDto>.Success(imageDto, StaticValue._successReturnModelId));
            }

            return CreateActionResultInstance(Response<ImageDto>.Fail(StaticValue._imageEmpty, StaticValue._badRequest));
        }


        [HttpDelete]
        public IActionResult PhotoDelete(string imageUrl)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageUrl);
            if (!System.IO.File.Exists(path))
            {
                return CreateActionResultInstance(Response<NoContent>.Fail(StaticValue._imageNotFound, StaticValue._notFoundId));
            }

            System.IO.File.Delete(path);

            return CreateActionResultInstance(Response<NoContent>.Success(StaticValue._successReturnNotModelId));
        }
    }
}
