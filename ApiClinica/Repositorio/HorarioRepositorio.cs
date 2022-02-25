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
    public class HorarioRepositorio : IHorarioRepositorio
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        public HorarioRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<HorarioDto>> GetHorarios()
        {
            List<Horario> lista = await _db.Horarios.ToListAsync();

            return _mapper.Map<List<HorarioDto>>(lista);
        }

        public async Task<HorarioDto> GetHorarioById(int id)
        {
            Horario horario = await _db.Horarios.FindAsync(id);

            return _mapper.Map<HorarioDto>(horario);
        }

    }
}
