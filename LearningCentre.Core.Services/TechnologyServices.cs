using AutoMapper;
using LearningCentre.Core.Builder;
using LearningCentre.Core.Contract;
using LearningCentre.Core.Domain.Exceptions;
using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Core.Domain.ResponseModel;
using LearningCentre.Infra.Contract;
using LearningCentre.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Services
{
    public class TechnologyServices:ITechnologyServices
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;
        public TechnologyServices(ITechnologyRepository technologyRepository,IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;   
        }

        public async Task AddTechnologyAsync(TechnologyRequestModel technologyRequestModel)
        {
            try
            { 
                var technology = TechnologyBuilder.Build(technologyRequestModel);
                technology.CreatedOn = DateTime.Now;
                var count = await _technologyRepository.AddTechnology(technology);
                if(count==0)
                {
                    throw new BadRequestException("Technology not created successfully.");
                }
               
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public async Task<List<TechnologyResponseModel>> GetTechnologyAsync()
        //{
        //    try
        //    {
        //        var tech = await _technologyRepository.GetTechnology();
        //        var result = _mapper.Map<List<TechnologyResponseModel>>(tech);
        //        return result;
        //    }
        //    catch(Exception)
        //    {
        //        throw;
        //    }
        //}
        public async Task<PagedList<TechnologyResponseModel>> GetTechnologyAsync(int page=1,int pageSize=25)
        {
            try
            {
                var technology = await _technologyRepository.GetTechnology(page, pageSize);
                var result = _mapper.Map<PagedList<TechnologyResponseModel>>(technology);
                return result;
            }
            catch(Exception)
            {
                throw;
            }
        }
       

        public async Task<TechnologyResponseModel> GetTechnologyByIdAsync(int Id)
        {
            try
            {
                var technology = await _technologyRepository.GetTechnologyById(Id);
                var result = _mapper.Map<TechnologyResponseModel>(technology);
                return result;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task DeleteTechnologyAsync(int Id,TechnologyRequestModel technologyRequestModel)
        {
            try
            {
                var technology = await  _technologyRepository.GetTechnologyById(Id);
                if (technology == null)
                {
                    throw new NotFoundException($"{Id} is not found");
                }
                technology.DeleteTechnology();
                var count = await _technologyRepository.DeleteTechnology(Id, technology);
                if (count == 0)
                {
                    throw new BadRequestException("Technology not deleted successfully.");
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task UpdateTechnologyAsync(int Id,TechnologyUpdateRequestModel technologyUpdateRequestModel)
        {
            try
            {
                var technology = await _technologyRepository.GetTechnologyById(Id);
                technology.UpdatedOn = DateTimeOffset.Now;
                if (technology == null)
                {
                    throw new NotFoundException($"{Id} is not found");
                }
                technology.UpdateTechnology(technologyUpdateRequestModel.Name, technologyUpdateRequestModel.Description);
                var count = await _technologyRepository.UpdateTechnology(Id, technology);
                if (count == 0)
                {
                    throw new BadRequestException("Technology is not updated successfully.");
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
