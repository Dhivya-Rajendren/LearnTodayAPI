using System.ComponentModel.DataAnnotations;

namespace LearnTodayAPI.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage ="Course Name Cannot be Null or Empty")]
        [StringLength(200,MinimumLength =10,ErrorMessage ="Course Name length should be Greater than 10 and Lesser than 201")]
        public string CourseName { get; set; }
        [Required(ErrorMessage ="Course Technology is manadatory for saving the details")]
        public string Technology { get; set; }
        [Required(ErrorMessage ="Number of Hours should be included")]
        [Range(15,20)]
        public int DurationInHours { get; set; }
        [Required]
        public int Price { get; set; }

        [RegularExpression("^.*\\.(jpg|JPG|GIF|gif)$",ErrorMessage ="Upload only image file with extensions as .jpg or .gif")]
        public string CourseImg { get; set; }
    }
}
