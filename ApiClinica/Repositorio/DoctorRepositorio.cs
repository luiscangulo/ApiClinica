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
    public class DoctorRepositorio : IDoctorRepositorio
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        public DoctorRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<DoctorDto> CreateUpdate(DoctorDto doctorDto)
        {
            Doctor doctor = _mapper.Map<DoctorDto, Doctor>(doctorDto);
            if (doctor.idDoctor > 0)
            {
                _db.Doctors.Update(doctor);
            }
            else
            {
                await _db.Doctors.AddAsync(doctor);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Doctor, DoctorDto>(doctor);
        }

        public async Task<bool> DeleteDoctor(int id)
        {
            try
            {
                Doctor doctor = await _db.Doctors.FindAsync(id);
                if (doctor == null)
                {
                    return false;
                }
                _db.Doctors.Remove(doctor);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<DoctorDto> GetDoctorById(int id)
        {
            Doctor doctor = await _db.Doctors.FindAsync(id);

            return _mapper.Map<DoctorDto>(doctor);
        }

        public async Task<List<DoctorDto>> GetDoctores()
        {
            List<Doctor> lista = await _db.Doctors.ToListAsync();

            return _mapper.Map<List<DoctorDto>>(lista);
        }
    }
}
