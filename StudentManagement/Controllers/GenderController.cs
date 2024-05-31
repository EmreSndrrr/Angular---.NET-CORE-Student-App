using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.DomainModels;
using StudentManagement.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Controllers
{
    [ApiController]
    public class GenderController : Controller
       {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        public GenderController(IStudentRepository studentRepository, IMapper mapper) {

            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllGenderAsync()
        {
            var genderList = await studentRepository.GetGenderAsync();
            if(genderList == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<List<Gender>>(genderList));
        }

    }
}
