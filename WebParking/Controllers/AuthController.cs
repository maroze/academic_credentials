using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebParking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService, SchoolContext context)
        {
            _courseService = courseService;
        }

        [HttpGet("GetCourses")]
        public IActionResult GetCourses()
        {
            try
            {
                return Ok(_courseService.GetAll());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("AddCourse")]
        public IActionResult AddCourse([FromBody] CourseViewModel course)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Invalid request data");

                var createdCourse = _courseService.Add(course);

                return Created($"/api/course/{createdCourse}", createdCourse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("UpdateCourse")]
        public IActionResult UpdateCourse([FromBody] CourseViewModel course)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Invalid request data");

                var updatedCourse = _courseService.Update(course);

                return Ok(updatedCourse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DeleteCourse")]
        public IActionResult DeleteCourse([FromRoute] int courseId)
        {
            try
            {
                _courseService.Delete(courseId);

                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
