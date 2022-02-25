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
using ApiClinica.Models;

namespace ApiClinica.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Task<string> Register(Usuario usuario, string password);
        Task<string> Login(string userName, string password);
        Task<bool> UserExiste(string username);
    }
}
