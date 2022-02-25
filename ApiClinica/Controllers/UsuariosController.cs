using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiClinica.Data;
using ApiClinica.Models;
using Microsoft.OpenApi.Models;
using ApiClinica.Repositorio;
using ApiClinica.Models.Dto;

namespace ApiClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        protected ResponseDto _response;

        public UsuariosController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _response = new ResponseDto();
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(UsuarioDto usuario)
        {
            var respuesta = await _usuarioRepositorio.Register(
                new Usuario
                {
                    userName = usuario.userName
                }, usuario.Password);

            if (respuesta == "existe")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Usuario ya Existe";
                return BadRequest(_response);

            }
            if (respuesta == "error")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al Crear el Usuario";
                return BadRequest(_response);

            }

            _response.DisplayMessage = "Usuario Creado con Exito";
            //_response.Result = respuesta;
            JwTPackage jtp = new JwTPackage();
            jtp.userName = usuario.userName;
            jtp.Token = respuesta;
            _response.Result = jtp;

            return Ok(_response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UsuarioDto usuario)
        {
            var respuesta = await _usuarioRepositorio.Login(usuario.userName, usuario.Password);

            if (respuesta == "nouser")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Usuario no Existe";
                return BadRequest(_response);
            }
            if (respuesta == "wrongpassword")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Password Incorrecta";
                return BadRequest(_response);
            }

            //_response.Result = respuesta;
            JwTPackage jtp = new JwTPackage();
            jtp.userName = usuario.userName;
            jtp.Token = respuesta;
            _response.Result = jtp;
            _response.DisplayMessage = "Usuario Conectado";
            return Ok(_response);
        }

    }

    public class JwTPackage
    {
        public string userName { get; set; }
        public string Token { get; set; }
    }
}