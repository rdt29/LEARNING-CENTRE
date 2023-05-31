using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Infra.Domain.Entities
{
    public class AssignTask : Audit
    {
        public AssignTask(int userId, int taskId, DateTime? deadLine)
        {
            UserId = userId;
            TaskId = taskId;
            DeadLine = deadLine;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public DateTime? DeadLine { get; set; }
        //public TaskEvaluation TaskEvaluation { get; set; }
        public Task Task { get; set; }
        public SubmittedTasks SubmittedTasks { get; set; }

        public AssignTask DeleteAssignTask()
        {
            IsDeleted = true;
            return this;
        }

        public AssignTask UpdateAssignTask(int userId, int taskId, DateTime? deadLine)
        {
            UserId = userId;
            TaskId = taskId;
            DeadLine = deadLine;
            return this;
        }
    }
}