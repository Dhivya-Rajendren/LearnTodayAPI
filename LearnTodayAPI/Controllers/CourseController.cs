using LearnTodayAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LearnTodayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly LearnTodayDbContext dbContext;

        //dependency injection in constructor 
        public CourseController(LearnTodayDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

    public IActionResult GetAllCourses()
        {

         List<Course> courses=   dbContext.Courses.ToList();
            return Ok(courses);


        }

        [HttpGet("{courseId}")]
        public IActionResult GetCourse(int courseId)
        {
            Course course = dbContext.Courses.Find(courseId);// Find method will equate the passed value with a primary key of a table
            if (course==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(course);
            }

        }

        [HttpPost]
        public IActionResult Post(Course course)
        {


         if (ModelState.IsValid)
            {
                dbContext.Courses.Add(course);
                dbContext.SaveChanges();// Permantely saving the changes
                return Created("", course);
            }
            else
            {
                var errors= new List<string>();
                foreach (var item in ModelState)
                {
                    foreach (var error in item.Value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }

                return BadRequest(errors);
            }
        }



    }
}
