using CommonCross.ServiceRegistrations.DependencyInjection;
using IP.Application.Interfaces.Application.UseCases.Image;
using IP.Application.Interfaces.Persistence;
using IP.Application.UseCases.Image.Queries.Models;

namespace IP.Application.UseCases.Image.Queries
{
    public class GetImageQuery : BaseQuery<Domain.Domian.Image>, IGetImageQuery, IScoped
    {
        public GetImageQuery(IRepository<Domain.Domian.Image> repository) : base(repository)
        {

        }

        public ImageModel Execute(int id)
        {
            var image = Repository.GetById(id);
            // AutoMapper can Be used 
            return new ImageModel
            {
                Id = image.Id,
                Name = image.Name,
                ImageType = image.ImageType,
                Height = image.Height,
                Width = image.Width
            };
        }
    }
}
