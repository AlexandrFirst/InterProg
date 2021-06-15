using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using InterProgApi.Models;

namespace InterProgApi.Data
{
    public class Problem
    {
        public int ProblemId { get; set; }
        public int CourseId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public TestInput TestJson { get; set; }

        public virtual ICollection<UserProblem> UserProblems { get; set; }

        public Course Course { get; set; }
    }
}