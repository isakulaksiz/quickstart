using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using quickstart.Controllers.DTOs;
using quickstart.Models;
using Xunit;

namespace quickstart.test
{
    [Collection("Integration Tests")]
    public class StudentsControllerTests
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private Student _modelStudent;

        public StudentsControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;

            var dbContext = _factory.Services.GetRequiredService<RosterDbContext>();

            var school = new School
            {
                Id = 1,
                Name = "Karabuk University",
                City = "Karabuk",
                State = "100.yıl"
            };

            dbContext.School.Add(school);

            var teacher = new Teacher
            {
                Id = 1,
                Name = "Umit Atila",
                School = school
            };

            dbContext.Teacher.Add(teacher);

            var @class = new Class
            {
                Id = 1,
                Name = "Master of Science",
                Teacher = teacher
            };

            dbContext.Class.Add(@class);

            _modelStudent = new Student
            {
                Id = 1,
                Name = "İsa Kulaksız",
                Class = @class
            };

            dbContext.Student.Add(_modelStudent);
            dbContext.SaveChanges();
        }

        [Fact]
        public async Task GetStudent_ReturnSuccessAndStudent()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/students/1");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response.Content);
            var responseStudent = JsonSerializer.Deserialize<StudentDTO>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            Assert.NotNull(responseStudent);
            Assert.Equal(_modelStudent.Id, responseStudent.Id);
            Assert.Equal(_modelStudent.Name, responseStudent.Name);
            Assert.Equal(_modelStudent.Class.Id, responseStudent.ClassId);
            Assert.Equal(_modelStudent.Class.Teacher.Id, responseStudent.TeacherId);
            Assert.Equal(_modelStudent.Class.Teacher.School.Id, responseStudent.SchoolId);
        }

    }
}
