using AutoMapper;
using LearningCentre.Core.Builder;
using LearningCentre.Core.Contract;
using LearningCentre.Core.Domain.Exceptions;
using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Core.Domain.ResponseModel;
using LearningCentre.Infra.Contract;
using LearningCentre.Infra.Domain.Entities;
using LearningCentre.Shared;
using Task = System.Threading.Tasks.Task;

namespace LearningCentre.Core.Services
{
    public class AssignTaskServices: IAssignTaskServices
    {
        private readonly IAssignTaskRepository _assignTaskRepository;
        private readonly IMapper _mapper;
        public AssignTaskServices(IAssignTaskRepository assignTaskRepository, IMapper mapper)
        {
            _assignTaskRepository = assignTaskRepository;
            _mapper = mapper;
        }

        public async Task AddAssignTaskAsync(AssignTaskRequestModel assignTaskRequestModel, int addedBy)
        {
            try
            {
                var assignTask = AssignTaskBuilder.Build(assignTaskRequestModel);
                assignTask.CreatedOn = DateTimeOffset.Now;
                assignTask.CreatedBy = addedBy;
                var count = await _assignTaskRepository.AddAssignTask(assignTask);
                if(count ==0)
                {
                    throw new BadRequestException("Task Not Assigned Maybe Task is not Present else User Is Already Assigned With Task ");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public async Task<List<AssignTaskResponseModel>> GetAssignTaskAsync()
        //{
        //    try
        //    {
        //        var assignTask = await _assignTaskRepository.GetAssignTask();
        //        var result = _mapper.Map<List<AssignTaskResponseModel>>(assignTask);
        //        return result;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}
        public async Task<PagedList<AssignTaskResponseModel>> GetAssignTaskAsync(int page=1,int pageSize=25)
        {
            try
            {
                var assignTask = await _assignTaskRepository.GetAssignTask(page, pageSize);
                var result = _mapper.Map<PagedList<AssignTaskResponseModel>>(assignTask);
                return result;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<List<AssignTaskResponseModel>> GetAssignTaskByIdAsync(int Id)
        {
            try
            {
                var assignTask = await _assignTaskRepository.GetAssignTaskById(Id);
                var result=_mapper.Map<List<AssignTaskResponseModel>>(assignTask);
                return result;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task DeleteAssignTaskAsync(int UserId,int TaskId)
        {
            try
            {
                var assignTask = _assignTaskRepository.DeleteAssignTask(UserId,TaskId);
              
              
              
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task UpdateAssignTaskAsync(AssignTaskRequestModel AssignTask)
        {
            var a = _mapper.Map<AssignTask>(AssignTask);
            var assignTask = await _assignTaskRepository.UpdateAssignTask(a);
      
        }


    }
}
