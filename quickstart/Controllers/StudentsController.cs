using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quickstart.Models;

namespace quickstart.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return new Student
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
            };
        }
    }
}
