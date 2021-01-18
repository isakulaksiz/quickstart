# Asp.net Core Web Api QuickStart

ASP.NET Core 3.1 Web API application from the ground up.it a useful service modeling a real world scenario with a data store and integration tests.Inspired by [Dustin Wilcock](https://github.com/dustinwilcock)

## Usage

```c#
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

```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.
