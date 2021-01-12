using quickstart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quickstart.Controllers.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ClassId { get; set; }

        public int TeacherId { get; set; }

        public int SchoolId { get; set; }
    }
}
