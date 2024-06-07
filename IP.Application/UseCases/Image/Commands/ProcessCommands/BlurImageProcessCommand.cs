using IP.Application.UseCases.Image.Commands.Models;

namespace IP.Application.UseCases.Image.Commands.ProcessCommands
{
    public class BlurImageProcessCommand : BaseImageProcessCommand
    {
        public BlurImageProcessCommand(BlurEffectModel blurEffect)
                                               : base(blurEffect)
        {

        }
        public override void Process(ImageModel image)
        {
            // implements blur effect
        }
    }
}
