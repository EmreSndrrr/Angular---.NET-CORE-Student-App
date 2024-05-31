﻿using Microsoft.EntityFrameworkCore;
using StudentManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Repositories
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly StudentAdminContext context;
        public SqlStudentRepository(StudentAdminContext context)
        {
            this.context = context;
        }

       

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }
        public async Task<Student> GetStudentAsync(Guid studentId)
        {
            return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).FirstOrDefaultAsync(x => x.Id == studentId);
        }

        public async Task<List<Gender>> GetGenderAsync()
        {
            return await context.Gender.ToListAsync();

        }

        public async Task<bool> Exists(Guid studentId)
        {
            return  await context.Student.AnyAsync(x => x.Id == studentId);
        }

        public async Task<Student> UpdateStudent(Guid studentId, Student request)
        {
            var existingStudent = await GetStudentAsync(studentId);
            if(existingStudent != null)
            {
                existingStudent.FirstName = request.FirstName;
                existingStudent.LastName = request.LastName;
                existingStudent.DateOfBirth = request.DateOfBirth;
                existingStudent.Email = request.Email;
                existingStudent.Mobile = request.Mobile;
                existingStudent.GenderId = request.GenderId;
                existingStudent.Address.PhysicalAdress = request.Address.PhysicalAdress;
                existingStudent.Address.PostalAdress = request.Address.PostalAdress;

                await context.SaveChangesAsync();
                return existingStudent;
            }
            return null;
        }
    }
}
