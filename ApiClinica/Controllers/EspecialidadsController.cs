using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiClinica.Data;
using ApiClinica.Models;
using Microsoft.OpenApi.Models;
using ApiClinica.Repositorio;
using ApiClinica.Models.Dto;
using Microsoft.AspNetCore.Authorization;


namespace ApiClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EspecialidadsController : ControllerBase
    {
        private readonly IEspecialidadRepositorio _especialidadRepositorio;
        protected ResponseDto _response;

        public EspecialidadsController(IEspecialidadRepositorio especialidadRepositorio)
        {
            _especialidadRepositorio = especialidadRepositorio;
            _response = new ResponseDto();
        }


        // GET: api/Especialidads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Especialidad>> GetEspecialidad(int id)
        {
            var especialidad = await _especialidadRepositorio.GetEspecialidadById(id);
            if (especialidad == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "La especialidad no existe";
                return NotFound(_response);
            }
            _response.Result = especialidad;
            _response.DisplayMessage = "Informacion";
            return Ok(_response);
        }


    }
}
