using ApiClinica.Models.Dto;
using System.Threading.Tasks;

namespace ApiClinica.Repositorio
{
    public interface ICitaRepositorio
    {
        Task<CitaDto> GetCitaById(int id);
        Task<CitaDto> CreateUpdate(CitaDto citaDto);

        Task<bool> DeleteCita(int id);
    }
}
