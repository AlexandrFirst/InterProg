using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterProgApi.Data
{
    public class UserProblem
    {
        public int UserId { get; set; }
        public int ProblemId { get; set; }
        public User User { get; set; }
        public Problem Problem { get; set; }
        public bool IsSolved { get; set; }
    }
}