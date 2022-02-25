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
    public class HistorialRepositorio : IHistorialRepositorio
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        public HistorialRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<HistorialDto> CreateUpdate(HistorialDto historialDto)
        {
            Historial historial = _mapper.Map<HistorialDto, Historial>(historialDto);
            if (historial.idHistorial > 0)
            {
                _db.Historials.Update(historial);
            }
            else
            {
                await _db.Historials.AddAsync(historial);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Historial, HistorialDto>(historial);
        }

        public async Task<bool> DeleteHistorial(int id)
        {
            try
            {
                Historial historial = await _db.Historials.FindAsync(id);
                if (historial == null)
                {
                    return false;
                }
                _db.Historials.Remove(historial);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<HistorialDto> GetHistorialById(int id)
        {
            Historial historial = await _db.Historials.FindAsync(id);

            return _mapper.Map<HistorialDto>(historial);
        }

    }
}
