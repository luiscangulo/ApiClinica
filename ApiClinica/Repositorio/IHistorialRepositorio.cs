using ApiClinica.Models.Dto;
using System.Threading.Tasks;

namespace ApiClinica.Repositorio
{
    public interface IHistorialRepositorio
    {
        Task<HistorialDto> GetHistorialById(int id);
        Task<HistorialDto> CreateUpdate(HistorialDto historialDto);

        Task<bool> DeleteHistorial(int id);
    }
}
