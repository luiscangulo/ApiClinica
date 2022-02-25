using ApiClinica.Models;
using ApiClinica.Models.Dto;
using AutoMapper;

namespace ApiClinica
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<PacienteDto, Paciente>();
                config.CreateMap<Paciente, PacienteDto>();

                config.CreateMap<CitaDto, Cita>();
                config.CreateMap<Cita, CitaDto>();

                config.CreateMap<DoctorDto, Doctor>();
                config.CreateMap<Doctor, DoctorDto>();

                config.CreateMap<EspecialidadDto, Especialidad>();
                config.CreateMap<Especialidad, EspecialidadDto>();

                config.CreateMap<HistorialDto, Historial>();
                config.CreateMap<Historial, HistorialDto>();

                config.CreateMap<HorarioDto, Horario>();
                config.CreateMap<Horario, HorarioDto>();

            });

            return mappingConfig;
        }
    }
}
