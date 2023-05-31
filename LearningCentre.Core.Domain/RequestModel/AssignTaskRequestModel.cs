namespace LearningCentre.Core.Domain.RequestModel
{
    public class AssignTaskRequestModel
    {
      
        public int TraineeId { get; set; }
        public int TaskId { get; set; }
        public DateTime? DeadLine { get; set; }
    }
}
