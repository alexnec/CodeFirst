using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using CodeFirst1.Models.Annotations;

namespace CodeFirst1.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Minimum length 3, maximum length 50")]
        public string FirstMidName { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM.dd.yyyy}")]
        [RusDateFormat(ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [UIHint("_Datepicker")]
        public DateTime EnrollmentDate { get; set; }
        public virtual List<Post> Posts { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public Student()
        {
            Posts = new List<Post>();
            Posts.Add(new Post() { ID = 1, NamePost = "Trulala" });
            Posts.Add(new Post() { ID = 2, NamePost = "Qwerty" });
            Posts.Add(new Post() { ID = 3, NamePost = "1q2w3e" });
        }

    }
}
