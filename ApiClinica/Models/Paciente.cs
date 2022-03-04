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
    public class Paciente
    {
       public Paciente()
        {
            this.Citas = new HashSet<Cita>();
            this.Historials = new HashSet<Historial>();
        }


        [Key]
        public int Id {  get; set; }
        [Required]
        public string nombres { get; set; }
        [Required]
        public string apellidoPaterno { get; set; }
        [Required]
        public string apellidoMaterno { get; set; }
        [Required]
        public string edad { get; set; }
        [Required]
        public string ci { get; set; }
        [Required]
        public string celular {  get; set; }
        [Required]
        public string telefono {  get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string direccion { get; set; }

        public int Usuario_idUsuario { get; set; }

        [NotMapped]
        public virtual Usuario Usuario { get; set; }



        //public virtual Usuario Usuario_idUsuarioNavigation { get; set; }
        [NotMapped]
        public virtual ICollection<Cita> Citas { get; set; }
        [NotMapped]
        public virtual ICollection<Historial> Historials { get; set; }

    }
}
