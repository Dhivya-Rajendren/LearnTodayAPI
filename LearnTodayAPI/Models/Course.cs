namespace LearnTodayAPI.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public string Technology { get; set; }
        public int DurationInHours { get; set; }
        public int Price { get; set; }
        public string CourseImg { get; set; }
    }
}
