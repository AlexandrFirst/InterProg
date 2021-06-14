using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InterProgApi.Data
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<User> Users {get;set;} = new HashSet<User>();
        public virtual ICollection<Problem> Problems {get;set;} = new HashSet<Problem>();
    }
}