using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IP.Application.Interfaces.Application.UseCases.Image;
using IP.Application.UseCases.Image.Commands.Models;
using IP.Application.UseCases.Image.Commands.ProcessCommands;
using IP.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageProcessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IGetImageQuery _getImageQuery;

        public ImageController(IGetImageQuery getImageQuery)
        {
            _getImageQuery = getImageQuery;
        }

        // POST: api/Image
        [HttpPost]
        public void Process([FromBody] Dictionary<int, List<EffectModel>> images)
        {
            IBaseImageProcessCommand imageProcessor = null;

            for (int i = 0; i < images.Count; i++)
            {
                foreach (var effect in images[i])
                {
                    switch (effect.EffectType)
                    {
                        case EffectType.Resize:
                            imageProcessor = new ResizeImageProcessCommand(effect as ResizeEffectModel);
                            break;
                        case EffectType.Blur:
                            imageProcessor = new BlurImageProcessCommand(effect as BlurEffectModel);
                            break;
                        case EffectType.Crop:
                            //imageProcessor = new ...(effect);
                            break;
                        case EffectType.Filter:
                            //imageProcessor = new ...(effect);
                            break;
                    }

                    var existingImage = _getImageQuery.Execute(i);

                    // Mapping from query model to Image Model 
                    var image = new ImageModel
                    {
                        Id = existingImage.Id,
                        Name = existingImage.Name,
                        Height = existingImage.Height,
                        Width = existingImage.Width,
                        ImageType = existingImage.ImageType,
                    };

                    imageProcessor.Process(image);
                }
            }
        }
    }
}
