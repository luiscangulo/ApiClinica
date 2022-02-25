using ApiClinica.Models.Dto;
using System.Threading.Tasks;

namespace ApiClinica.Repositorio
{
    public interface IEspecialidadRepositorio
    {

        Task<EspecialidadDto> GetEspecialidadById(int id);

    }
}
