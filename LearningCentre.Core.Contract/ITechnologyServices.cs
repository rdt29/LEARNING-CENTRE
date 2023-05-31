using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Core.Domain.ResponseModel;
using LearningCentre.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Contract
{
    public interface ITechnologyServices
    {
        Task AddTechnologyAsync(TechnologyRequestModel technologyRequestModel);
        //Task<List<TechnologyResponseModel>> GetTechnologyAsync();
        Task<PagedList<TechnologyResponseModel>> GetTechnologyAsync(int page = 1, int pageSize = 25);
        Task<TechnologyResponseModel> GetTechnologyByIdAsync(int Id);
        Task DeleteTechnologyAsync(int Id, TechnologyRequestModel technologyRequestModel);
        Task UpdateTechnologyAsync(int Id, TechnologyUpdateRequestModel technologyUpdateRequestModel);
    }
}
