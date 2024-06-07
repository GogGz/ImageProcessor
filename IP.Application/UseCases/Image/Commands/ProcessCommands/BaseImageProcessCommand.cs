using IP.Application.Interfaces.Application.UseCases.Image;
using IP.Application.UseCases.Image.Commands.Models;

namespace IP.Application.UseCases.Image.Commands.ProcessCommands
{
    public abstract class BaseImageProcessCommand : IBaseImageProcessCommand
    {
        public EffectModel Effect { get; set; }
        public BaseImageProcessCommand(EffectModel effect)
        {
            Effect = effect;
        }
        public abstract void Process(ImageModel image);
    }
}
