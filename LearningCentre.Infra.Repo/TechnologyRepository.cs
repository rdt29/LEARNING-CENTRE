using LearningCentre.Infra.Contract;
using LearningCentre.Infra.Domain;
using LearningCentre.Infra.Domain.Entities;
using LearningCentre.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Infra.Repo
{
    public class TechnologyRepository: ITechnologyRepository
    {
        private readonly LearningCentreContext _context;
        public TechnologyRepository(LearningCentreContext context)
        {
            _context = context;
        }
        public async Task<int> AddTechnology(Technology technology)
        {
           _context.Technologies.AddAsync(technology);
           return  await _context.SaveChangesAsync();
            
        }


        //public async Task<List<Technology>> GetTechnology()
        //{
        //    var tech =await _context.Technologies.ToListAsync();
        //    return tech;
        //}

        public async Task<PagedList<Technology>> GetTechnology(int page=1,int pageSize=25)
        {
            try
            {
                var technology = _context.Technologies.AsQueryable();
                var count = await technology.LongCountAsync();
                var pagedList= technology.ToPagedList(page,pageSize,count);
                return pagedList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Technology> GetTechnologyById(int Id)
        {
            var technology = await _context.Technologies.FirstOrDefaultAsync(x => x.Id == Id);
            return technology;
        }

        public async Task<int> UpdateTechnology(int Id, Technology technology)
        {
            _context.Technologies.Update(technology);
            return await _context.SaveChangesAsync();
        }


        public async Task<int> DeleteTechnology(int Id, Technology technology)
        {
            _context.Technologies.Remove(technology);
            return await _context.SaveChangesAsync();
        }
    }
}
