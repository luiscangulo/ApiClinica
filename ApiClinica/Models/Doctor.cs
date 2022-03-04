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
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClinica.Models
{
    public class Doctor
    {
        public Doctor()
        { 
            this.Citas = new HashSet<Cita>();
        }
        [Key]
        public int idDoctor { get; set; }
        public string ciDoctor { get; set; }
        public string nombreDoctor { get; set; }
        public string apellidosDoctor { get; set; }
        public string celularDoctor { get; set; }
        public int Usuario_idUsuario { get; set; }
        public int Especialidad_idEspecialidad { get; set; }

        [NotMapped]
        public virtual Usuario Usuario { get; set; }
        [NotMapped]
        public virtual Especialidad Especialidad { get; set; }
        [NotMapped]
        public virtual ICollection<Cita> Citas { get; set; }
       //ublic virtual Usuario Usuario_idUsuarioNavigation { get; set; }
       //ublic virtual Especialidad Especialidad_idEspecialidadNavigation { get; set; }
       //ublic virtual Horario Horario_idHorarioNavigation { get; set; }
    }
}
