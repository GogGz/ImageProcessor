using IP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IP.Domain.Domian
{
    public class Image : Entity<int>
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public ImageType ImageType { get; set; }
    }
}
