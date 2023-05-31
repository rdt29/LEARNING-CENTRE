using AutoMapper;
using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Core.Domain.ResponseModel;
using LearningCentre.Infra.Domain.Entities;
using LearningCentre.Shared;
using Task = LearningCentre.Infra.Domain.Entities.Task;


namespace LEARNING_CENTRE_PROJECT.Configuration
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {

            CreateMap<User, UserResponseMOdel>().ReverseMap();  
            CreateMap<User, UserRequestModel>().ReverseMap();
            CreateMap<User,UserLoginReqModel>().ReverseMap();


            CreateMap<PagedList<User>, PagedList<UserResponseMOdel>>();



            CreateMap<Technology, TechnologyRequestModel>().ReverseMap();
            CreateMap<Technology, TechnologyResponseModel>().ReverseMap();

            CreateMap<PagedList<Technology>,PagedList<TechnologyResponseModel>>();


            CreateMap<TaskEvaluation,TaskEvaluationRequestModel>().ReverseMap();
            CreateMap<TaskEvaluation,TaskEvaluationResponseModel>().ReverseMap();
            CreateMap<PagedList<TaskEvaluation>,PagedList<TaskEvaluationResponseModel>>();
            

            CreateMap<Role, RoleResponseMOdel>().ReverseMap();
            CreateMap<Role,RoleRequestModel>().ReverseMap();
            CreateMap<PagedList<Role>,PagedList<RoleResponseMOdel>>();

            CreateMap<Task, TaskRequestModelAdd>().ReverseMap();
            CreateMap<Task,TaskResponseModel>().ReverseMap();
            CreateMap<PagedList<Task>,PagedList<TaskResponseModel>>();  

            CreateMap<AssignTask, AssignTaskRequestModel>().ReverseMap();
            CreateMap<AssignTask,AssignTaskResponseModel>().ReverseMap();
            CreateMap<PagedList<AssignTask>,PagedList<AssignTaskResponseModel>>();  


            CreateMap<SubmittedTasks, SubmittedTaskResponseModel>().ReverseMap(); 
            CreateMap<SubmittedTasks,SubmittedTaskRequestModel>().ReverseMap(); 


        }
    }
}
