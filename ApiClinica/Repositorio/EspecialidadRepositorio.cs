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
    public class EspecialidadRepositorio : IEspecialidadRepositorio
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        public EspecialidadRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<EspecialidadDto> GetEspecialidadById(int id)
        {
            Especialidad especialidad = await _db.Especialidads.FindAsync(id);

            return _mapper.Map<EspecialidadDto>(especialidad);
        }

    }
}
