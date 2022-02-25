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
    public class Especialidad
    {
        public Especialidad()
        {   
            Doctor = new HashSet<Doctor>();
        }

        [Key]
        public int idEspecialidad { get; set; }
        public string nombreEspecialidad { get; set; }


        public virtual ICollection<Doctor> Doctor { get; set; }
    }
}
