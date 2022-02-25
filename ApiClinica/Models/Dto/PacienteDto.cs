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

namespace ApiClinica.Models.Dto
{
    public class PacienteDto
    {
        public int Id { get; set; }

        public string nombres { get; set; }

        public string apellidoPaterno { get; set; }

        public string apellidoMaterno { get; set; }

        public string edad { get; set; }

        public string ci { get; set; }

        public string celular { get; set; }

        public string telefono { get; set; }

        public string email { get; set; }

        public string direccion { get; set; }

        public int Usuario_idUsuario { get; set; }


    }
}
