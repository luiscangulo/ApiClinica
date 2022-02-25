using ApiClinica.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ApiClinica.Data;
using AutoMapper;
using ApiClinica.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiClinica.Repositorio
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        public PacienteRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<PacienteDto> CreateUpdate(PacienteDto pacienteDto)
        {
            Paciente paciente = _mapper.Map<PacienteDto, Paciente>(pacienteDto);
            if (paciente.Id > 0)
            {
                _db.Pacientes.Update(paciente);
            }
            else
            {
                await _db.Pacientes.AddAsync(paciente);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Paciente, PacienteDto> (paciente);
        }

        public async Task<bool> DeletePaciente(int id)
        {
            try
            {
                Paciente paciente = await _db.Pacientes.FindAsync(id);
                if (paciente == null)
                {
                    return false;
                }
                _db.Pacientes.Remove(paciente);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<PacienteDto> GetPacienteById(int id)
        {
            Paciente paciente = await _db.Pacientes.FindAsync(id);

            return _mapper.Map<PacienteDto>(paciente);
        }

        public async Task<List<PacienteDto>> GetPacientes()
        {
            List<Paciente> lista = await _db.Pacientes.ToListAsync();

            return _mapper.Map<List<PacienteDto>>(lista);
        }
    }
}
