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
    public class Especialidad
    {
        public Especialidad()
        {   
            this.Doctors = new HashSet<Doctor>();
        }

        [Key]
        public int idEspecialidad { get; set; }
        public string nombreEspecialidad { get; set; }

        [NotMapped]
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
