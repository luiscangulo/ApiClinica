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
    public class CitaRepositorio : ICitaRepositorio
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        public CitaRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CitaDto> CreateUpdate(CitaDto citaDto)
        {
            Cita cita = _mapper.Map<CitaDto, Cita>(citaDto);
            if (cita.idCita > 0)
            {
                _db.Citas.Update(cita);
            }
            else
            {
                await _db.Citas.AddAsync(cita);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Cita, CitaDto>(cita);
        }

        public async Task<bool> DeleteCita(int id)
        {
            try
            {
                Cita cita = await _db.Citas.FindAsync(id);
                if (cita == null)
                {
                    return false;
                }
                _db.Citas.Remove(cita);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<CitaDto> GetCitaById(int id)
        {
            Cita cita = await _db.Citas.FindAsync(id);

            return _mapper.Map<CitaDto>(cita);
        }

    }
}
