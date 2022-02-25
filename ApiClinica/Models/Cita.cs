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

namespace ApiClinica.Models
{
    public class Cita
    {
        [Key]
        public int idCita { get; set; }
        public DateTime fechaCita { get; set; }
        public DateTime horaCita { get; set; }
        public int Paciente_idPaciente { get; set; }
        public int Doctor_idDoctor { get; set; }

        public virtual Paciente Paciente_idPacienteNavigation { get; set; }
        public virtual Doctor Doctor_idDoctorNavigation { get; set; }
    }
}
