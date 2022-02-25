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
    public class Usuario
    {
        public Usuario()
        {
            Doctor = new HashSet<Doctor>();
            Paciente = new HashSet<Paciente>();
        }


        [Key]
        public int idUsuario { get; set; }

        public string userName { get; set; }
        
        public byte[] PasswordHash {  get; set; }

        public byte[] PasswordSalt {  get; set; }   


        public virtual ICollection<Doctor> Doctor { get; set; }
        public virtual ICollection<Paciente> Paciente { get; set; }

    }
}
