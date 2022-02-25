using ApiClinica.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiClinica.Repositorio
{
    public interface IHorarioRepositorio
    {
        Task<List<HorarioDto>> GetHorarios();
        Task<HorarioDto> GetHorarioById(int id);
    }
}
