using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LearningCentre.Infra.Domain.Entities
{
    public class SubmittedTasks : Audit
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int AssignTaskId { get; set; }

        [ForeignKey(nameof(AssignTaskId))]
        public string Status { get; set; }

        public string? DocumentURL { get; set; }
        public DateTimeOffset Submission { get; set; }
        public string? Comments { get; set; }
        public AssignTask AssignTask { get; set; }
        public TaskEvaluation TaskEvaluation { get; set; }

        public ICollection<Documents> Documents { get; set; }

        public SubmittedTasks DeleteSubmitTask()
        {
            IsDeleted = true;
            return this;
        }

        public SubmittedTasks UpdateSubmitTask(int userId, string status, DateTimeOffset submission, int assignTaskId, string comments, List<IFormFile> files)
        {
            UserId = userId;
            Status = status;
            Submission = submission;
            Comments = comments;
            AssignTaskId = assignTaskId;

            return this;
        }
    }
}