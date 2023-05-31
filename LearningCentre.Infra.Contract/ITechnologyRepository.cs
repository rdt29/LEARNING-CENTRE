using LearningCentre.Infra.Domain.Entities;
using LearningCentre.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Infra.Contract
{
    public interface ITechnologyRepository
    {
        Task<int> AddTechnology(Technology technology);
        // Task<List<Technology>> GetTechnology();
        Task<PagedList<Technology>> GetTechnology(int page = 1, int pageSize = 25);
        Task<Technology> GetTechnologyById(int Id);
        Task<int> UpdateTechnology(int Id, Technology technology);
        Task<int> DeleteTechnology(int Id, Technology technology);
    }
}
