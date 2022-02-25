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
    public class HistorialsController : ControllerBase
    {
        private readonly IHistorialRepositorio _historialRepositorio;
        protected ResponseDto _response;

        public HistorialsController(IHistorialRepositorio historialRepositorio)
        {
            _historialRepositorio = historialRepositorio;
            _response = new ResponseDto();
        }




        // GET: api/Historials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Historial>> GetHistorial(int id)
        {
            var historial = await _historialRepositorio.GetHistorialById(id);
            if (historial == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "El historial no existe";
                return NotFound(_response);
            }
            _response.Result = historial;
            _response.DisplayMessage = "Informacion del historial";
            return Ok(_response);
        }



        // PUT: api/Historials/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorial(int id, HistorialDto historialDto)
        {
            try
            {
                HistorialDto model = await _historialRepositorio.CreateUpdate(historialDto);
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









        // POST: api/Historials
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Historial>> PostHistorial(HistorialDto historialDto)
        {
            try
            {
                HistorialDto model = await _historialRepositorio.CreateUpdate(historialDto);
                _response.Result = model;
                return CreatedAtAction("GetHistorial", new { id = model.idHistorial }, _response);
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al Grabar el Resgistro";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }


        }

        // DELETE: api/Historials/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Historial>> DeleteHistorial(int id)
        {
            {
                try
                {
                    bool estaEliminado = await _historialRepositorio.DeleteHistorial(id);
                    if (estaEliminado)
                    {
                        _response.Result = estaEliminado;
                        _response.DisplayMessage = "Historial Eliminado con Exito";
                        return Ok(_response);
                    }
                    else
                    {
                        _response.IsSuccess = false;
                        _response.DisplayMessage = "Error al Eliminar Historial";
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
}