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
    public class Usuario
    {
        public Usuario()
        {
            this.Doctors = new HashSet<Doctor>();
            this.Pacientes = new HashSet<Paciente>();
        }


        [Key]
        public int idUsuario { get; set; }

        public string userName { get; set; }
        
        public byte[] PasswordHash {  get; set; }

        public byte[] PasswordSalt {  get; set; }


        [NotMapped]
        public virtual ICollection<Doctor> Doctors { get; set; }
        [NotMapped]
        public virtual ICollection<Paciente> Pacientes { get; set; }

    }
}
