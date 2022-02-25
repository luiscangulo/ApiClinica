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
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRepositorio _doctorRepositorio;
        protected ResponseDto _response;

        public DoctorsController(IDoctorRepositorio doctorRepositorio)
        {
            _doctorRepositorio = doctorRepositorio;
            _response = new ResponseDto();
        }

        // GET: api/Doctors
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctores()
        {
            try
            {
                var lista = await _doctorRepositorio.GetDoctores();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Doctores";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }


        // GET: api/Doctors/5
        [HttpGet("{id}")]


        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var doctor = await _doctorRepositorio.GetDoctorById(id);
            if (doctor == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "El doctor no existe";
                return NotFound(_response);
            }
            _response.Result = doctor;
            _response.DisplayMessage = "Informacion del Doctor";
            return Ok(_response);
        }


        // PUT: api/Doctors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]


        public async Task<IActionResult> PutDoctor(int id, DoctorDto doctorDto)
        {
            try
            {
                DoctorDto model = await _doctorRepositorio.CreateUpdate(doctorDto);
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


        // POST: api/Doctors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]



        public async Task<ActionResult<Doctor>> PostDoctor(DoctorDto doctorDto)
        {
            try
            {
                DoctorDto model = await _doctorRepositorio.CreateUpdate(doctorDto);
                _response.Result = model;
                return CreatedAtAction("GetDoctor", new { id = model.idDoctor }, _response);
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al Grabar el Resgistro";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }


        }



        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]


        public async Task<ActionResult<Doctor>> DeleteDoctor(int id)
        {
            try
            {
                bool estaEliminado = await _doctorRepositorio.DeleteDoctor(id);
                if (estaEliminado)
                {
                    _response.Result = estaEliminado;
                    _response.DisplayMessage = "Doctor Eliminador con Exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al Eliminar Doctor";
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
