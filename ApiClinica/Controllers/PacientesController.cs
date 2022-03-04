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
    
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteRepositorio _pacienteRepositorio;
        protected ResponseDto _response;

        public PacientesController(IPacienteRepositorio pacienteRepositorio)
        {
            _pacienteRepositorio = pacienteRepositorio;
            _response = new ResponseDto();
        }

        // GET: api/Pacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPacientes()
        {
            try
            {
                var lista = await _pacienteRepositorio.GetPacientes();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Pacientes";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

        // GET: api/Pacientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetPaciente(int id)
        {
            var paciente = await _pacienteRepositorio.GetPacienteById(id);
            if (paciente == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "El paciente no existe";
                return NotFound(_response);
            }
            _response.Result = paciente;
            _response.DisplayMessage = "Informacion del Paciente";
            return Ok(_response);
        }

        // PUT: api/Pacientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaciente(int id, PacienteDto pacienteDto)
        {
            try
            {
                PacienteDto model = await _pacienteRepositorio.CreateUpdate(pacienteDto);
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al Actualizar el Resgistro";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // POST: api/Pacientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Paciente>> PostPaciente(PacienteDto pacienteDto)
        {
            try
            {
                PacienteDto model = await _pacienteRepositorio.CreateUpdate(pacienteDto);
                _response.Result = model;
                return CreatedAtAction("GetPaciente", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al Grabar el Resgistro";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }


        }

        // DELETE: api/Pacientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Paciente>> DeletePaciente(int id)
        {
            try
            {
                bool estaEliminado = await _pacienteRepositorio.DeletePaciente(id);
                if (estaEliminado)
                {
                    _response.Result = estaEliminado;
                    _response.DisplayMessage = "Cliente Eliminador con Exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al Eliminar Paciente";
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
    }
}
