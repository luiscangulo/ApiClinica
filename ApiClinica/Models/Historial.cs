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
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClinica.Models
{
    public class Historial
    {
        [Key]
        public int idHistorial { get; set; }
        public string alergia { get; set; }
        public string enfermedad { get; set; }
        public string tratamiento { get; set; }
        public string medicacion { get; set; }
        public string prescripcion { get; set; }
        public int Paciente_idPaciente { get; set; }

        [NotMapped]
        public virtual Paciente Paciente { get; set; }


       // public virtual Paciente Paciente_idPacienteNavigation { get; set; }
    }
}
