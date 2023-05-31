using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningCentre.Infra.Domain.Entities
{
    public class User : Audit
    {
        [Key]
        public int Id { get; set; }

        // public int RoleId { get; set; }
        // public int TechnologyId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        //public int SuperiorId { get; set; }
        public ICollection<UserRoleMapping> UserRoleMapping { get; set; }

        //public ICollection<User> SuperiorId { get; set; }
        public int? SuperiorId { get; set; }

        [ForeignKey(nameof(SuperiorId))]
        public User? users { get; set; }

        public virtual ICollection<AssignTask> AssignTasks { get; set; } = new List<AssignTask>();

        public User UpdateUser(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;

            return this;
        }
    }
}