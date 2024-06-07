using IP.Application.UseCases.Image.Commands.Models;

namespace IP.Application.Interfaces.Application.UseCases.Image
{
    public interface IBaseImageProcessCommand
    {
        void Process(ImageModel image);
    }
}