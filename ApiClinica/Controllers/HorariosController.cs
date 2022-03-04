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
    
    public class HorariosController : ControllerBase
    {
        private readonly IHorarioRepositorio _horarioRepositorio;
        protected ResponseDto _response;

        public HorariosController(IHorarioRepositorio horarioRepositorio)
        {
            _horarioRepositorio = horarioRepositorio;
            _response = new ResponseDto();
        }



        // GET: api/Horarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Horario>>> GetHorarios()
        {
            try
            {
                var lista = await _horarioRepositorio.GetHorarios();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Horarios";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }


        // GET: api/Horarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Horario>> GetHorario(int id)
        {
            var horario = await _horarioRepositorio.GetHorarioById(id);
            if (horario == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "El horario no existe";
                return NotFound(_response);
            }
            _response.Result = horario;
            _response.DisplayMessage = "Informacion";
            return Ok(_response);
        }

    }
}