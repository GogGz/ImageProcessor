using IP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IP.Application.UseCases.Image.Queries.Models
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
