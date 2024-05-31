using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.DataModels;
using StudentManagement.DomainModels;
using StudentManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Controllers
{
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var students= await studentRepository.GetStudentsAsync();

            return Ok(mapper.Map<List<DataModels.Student>>(students));
        }


        [HttpGet]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> GetAllStudentAsync([FromRoute] Guid studentId)
        {
            var student = await studentRepository.GetStudentAsync(studentId);

            if(student == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<DataModels.Student>(student));
        }


        [HttpPut]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId, [FromBody] UpdateStudentRequest request)
        {
            if(await studentRepository.Exists(studentId))
            {
               var updatedStudent  = await studentRepository.UpdateStudent(studentId, mapper.Map<DataModels.Student>(request));
                if(updatedStudent != null)
                {
                    return Ok(mapper.Map<DataModels.Student>(updatedStudent));
                }
            }
            return NotFound();
        }
    }
}
