using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.OpenApi.Models;
using ApiClinica.Models.Dto;

namespace ApiClinica.Repositorio
{
    public interface IPacienteRepositorio
    {
        Task<List<PacienteDto>> GetPacientes();

        Task<PacienteDto> GetPacienteById(int id);

        Task<PacienteDto> CreateUpdate(PacienteDto pacienteDto);

        Task<bool> DeletePaciente(int id);

    }
}
