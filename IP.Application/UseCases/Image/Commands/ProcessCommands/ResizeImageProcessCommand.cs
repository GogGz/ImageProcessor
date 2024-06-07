using IP.Application.UseCases.Image.Commands.Models;
using System;

namespace IP.Application.UseCases.Image.Commands.ProcessCommands
{
    public class ResizeImageProcessCommand : BaseImageProcessCommand
    {
        public ResizeImageProcessCommand(ResizeEffectModel resizeEffect)
                                               : base(resizeEffect)
        {

        }
        public override void Process(ImageModel image)
        {
            throw new NotImplementedException();
        }
    }
}
