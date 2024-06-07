using IP.Domain.Enums;

namespace IP.Application.UseCases.Image.Commands.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public ImageType ImageType { get; set; }
    }
}
