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
    
    public class CitasController : ControllerBase
    {
        private readonly ICitaRepositorio _citaRepositorio;
        protected ResponseDto _response;

        public CitasController(ICitaRepositorio citaRepositorio)
        {
            _citaRepositorio = citaRepositorio;
            _response = new ResponseDto();
        }


        // GET: api/Citas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cita>> GetCita(int id)
        {
            var cita = await _citaRepositorio.GetCitaById(id);
            if (cita == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "La cita no existe";
                return NotFound(_response);
            }
            _response.Result = cita;
            _response.DisplayMessage = "Informacion de cita";
            return Ok(_response);
        }

        // PUT: api/Citas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCita(int id, CitaDto citaDto)
        {
            try
            {
                CitaDto model = await _citaRepositorio.CreateUpdate(citaDto);
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

        // POST: api/Citas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cita>> PostCita(CitaDto citaDto)
        {
            try
            {
                CitaDto model = await _citaRepositorio.CreateUpdate(citaDto);
                _response.Result = model;
                return CreatedAtAction("GetCita", new { id = model.idCita }, _response);
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al Grabar el Resgistro";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }


        }

        // DELETE: api/Citas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cita>> DeleteCita(int id)
        {
            try
            {
                bool estaEliminado = await _citaRepositorio.DeleteCita(id);
                if (estaEliminado)
                {
                    _response.Result = estaEliminado;
                    _response.DisplayMessage = "Cita eliminada";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al Eliminar Cita";
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
