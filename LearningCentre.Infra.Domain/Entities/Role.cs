using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Infra.Domain.Entities
{
    public class Role : Audit
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<UserRoleMapping> UserRoleMapping { get; set; }

    }
}