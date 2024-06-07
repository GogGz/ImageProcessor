using IP.Application.UseCases.Image.Queries.Models;

namespace IP.Application.Interfaces.Application.UseCases.Image
{
    public interface IGetImageQuery
    {
        ImageModel Execute(int id);
    }
}