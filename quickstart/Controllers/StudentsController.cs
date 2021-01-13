using Microsoft.AspNetCore.Mvc;
using quickstart.Controllers.DTOs;
using quickstart.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace quickstart.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly RosterDbContext _dbDbContext;

        public StudentsController(RosterDbContext dbDbContext)
        {
            _dbDbContext = dbDbContext;
        }


        //[HttpGet("{id}")]
        //public StudentDTO Get(int id)
        //{
        //    return ToDTO(new Student
        //    {
        //        Id = id,
        //        Name = "isa kulaksız",
        //        Class = new Class
        //        {
        //            Id = 1,
        //            Name = "Master of Science",
        //            Teacher = new Teacher
        //            {
        //                Id = 1,
        //                Name = "Umit Atila",
        //                School = new School
        //                {
        //                    Id = 1,
        //                    Name = "Karabuk University",
        //                    City = "Karabuk",
        //                    State = "100.yıl"
        //                }
        //            }
        //        }
        //    });
        //}

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StudentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var student = await _dbDbContext.Student.FindAsync(id);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(ToDTO(student));
        }
        private static StudentDTO ToDTO(Student student)
        {
            return new StudentDTO
            {
                Id = student.Id,
                Name = student.Name,
                ClassId = student.Class.Id,
                TeacherId = student.Class.Teacher.Id,
                SchoolId = student.Class.Teacher.School.Id
            };
        }
    }
}
