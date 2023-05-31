using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Domain.ResponseModel
{
    public class TranieeViewTaskDetailsResponseDTO
    {
        public int TaskId { get; set; }
        public string ? Status { get; set; }
        public string Details { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DeadLine { get; set; }
        public int MentorId { get; set; }
        public string FileUrl { get; set; }
    }
}