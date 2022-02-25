using ApiClinica.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiClinica.Repositorio
{
    public interface IDoctorRepositorio
    {

        Task<List<DoctorDto>> GetDoctores();

        Task<DoctorDto> GetDoctorById(int id);

        Task<DoctorDto> CreateUpdate(DoctorDto doctorDto);

        Task<bool> DeleteDoctor(int id);
    }
}
