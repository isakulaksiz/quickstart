using Microsoft.AspNetCore.Mvc;
using quickstart.Controllers.DTOs;
using quickstart.Models;

namespace quickstart.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet("{id}")]
        public StudentDTO Get(int id)
        {
            return ToDTO(new Student
            {
                Id = id,
                Name = "isa kulaksız",
                Class = new Class
                {
                    Id = 1,
                    Name = "Master of Science",
                    Teacher = new Teacher
                    {
                        Id = 1,
                        Name = "Umit Atila",
                        School = new School
                        {
                            Id = 1,
                            Name = "Karabuk University",
                            City = "Karabuk",
                            State = "100.yıl"
                        }
                    }
                }
            });
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
