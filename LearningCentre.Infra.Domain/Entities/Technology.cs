using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Infra.Domain.Entities
{
    public class Technology : Audit
    {
        public Technology(string name, string description)
        {
            Name = name;
            Description = description;
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }

        
        public ICollection<UserRoleMapping> userRoleMapping { get; set; }


        public Technology DeleteTechnology()
        {
          IsDeleted = true;
          return this;
        }

        public Technology UpdateTechnology(string name, string description)
        {
            Name = name;
            Description = description;
            return this;
        }
        // public UserRoleMapping userRoleMapping { get; set; }


        //  public ICollection<User> User { get; set; }
    }
}