using LearnTodayAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LearnTodayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        private static List<Course> courses = new List<Course>();

        public CourseController()
        {
            courses.Add(new Course() { CourseId = 1, CourseName = "Web Developer 2.0", Technology = "FrontEnd Development", Price = 9999, DurationInHours = 20 });
            courses.Add(new Course() { CourseId = 2, CourseName = ".Net Full Stack", Technology = "Full Stack Development", Price = 39999, DurationInHours = 100 });

            courses.Add(new Course() { CourseId = 3, CourseName = "Basics of ASP .Net", Technology = "ASp.Net Core", Price = 9999, DurationInHours = 20 });

            courses.Add(new Course() { CourseId = 4, CourseName = "Azure DevOps", Technology = "Cloud", Price = 11999, DurationInHours = 20 });

        }


        public ActionResult Get()
        {
          

                return StatusCode(201, courses);
         
        }

        [HttpGet("GetById/{id}")]
        public ActionResult GetById(int id)
        {
            Course course= courses.Find(x => x.CourseId == id);
            if (course==null)
            {
                return new NotFoundResult();
            }
            else
            {
                return StatusCode(200, course);
            }
        }
        [HttpGet("GetByName/{courseName}")]
        public ActionResult GetByName(string courseName)
        {
            if (string.IsNullOrEmpty(courseName))
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            else
            {
                Course course = courses.Find(x => x.CourseName.Equals(courseName,System.StringComparison.OrdinalIgnoreCase));
                if (course == null)
                {
                    return new NotFoundResult();
                }
                else
                {
                    return StatusCode(200, course);
                }
            }
        }

    }
}
