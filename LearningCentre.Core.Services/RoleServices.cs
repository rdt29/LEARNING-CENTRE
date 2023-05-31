using AutoMapper;
using LearningCentre.Core.Contract;
using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Core.Domain.ResponseModel;
using LearningCentre.Core.Services.Helper.Interface;
using LearningCentre.Infra.Contract;
using LearningCentre.Infra.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

//using Task = LearningCentre.Infra.Domain.Entities.Task;

namespace LearningCentre.Core.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleServices(IRoleRepository roleRepository, IMapper mapper, IGenerateToken generateToken)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<RoleResponseMOdel> GetRoleAsync()
        {
            try
            {
                var role = await _roleRepository.GetRole();

                //var result = _mapper.Map<List<RoleResponseMOdel>>(role);
                //return result;

                RoleResponseMOdel obj = new RoleResponseMOdel()
                {
                    RoleMaping = role.Select(x => new RoleUserMappingResponseDTO()
                    {
                        roleName = x.Name,
                        roleId = x.Id,
                        RoleUserDetails = x.UserRoleMapping.Select(y => new RoleUserDetailsResponseDTO()
                        {
                            Name = y.User.FirstName + " " + y.User.LastName,
                            UserId = y.User.Id,
                            Email = y.User.Email,
                        })
                    })
                };

                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public async Task<PagedList<RoleResponseMOdel>> GetRoleAsync(int page=1,int pageSize=25)
        //{
        //    try
        //    {
        //        var role = await _roleRepository.GetRole(page, pageSize);
        //        var result = _mapper.Map<PagedList<RoleResponseMOdel>>(role);
        //        return result;
        //    }
        //    catch(Exception)
        //    {
        //        throw;
        //    }
        //}

        public async Task<Role> AddRoleAsync(RoleRequestModel roleRequestModel, int addedBy)
        {
            try
            {
                var data = _mapper.Map<Role>(roleRequestModel);
                data.CreatedBy = addedBy;
                data.CreatedOn = DateTime.Now;

                var role = await _roleRepository.AddRole(data);

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TeamSuperiorResponseDTO>> Team()
        {
            try
            {
                var team = await _roleRepository.TeamList();

                var TeamNotNull = team.Where(x => x.SuperiorId != null).ToList();
                var grouplist = TeamNotNull.GroupBy(x => x.SuperiorId).ToList();

                var fres = new List<TeamSuperiorResponseDTO>();
                foreach (var group in grouplist)
                {
                    var resv = new TeamSuperiorResponseDTO();
                    resv.SuperiorId = group.Key;
                    resv.SuperiorName = team.FirstOrDefault(x => x.Id == group.Key).FirstName;
                    // resv.SuperiorName = group.val]
                    IList<TeamUserResponseDTO> list = new List<TeamUserResponseDTO>();
                    foreach (var item in group)
                    {
                        var res2 = new TeamUserResponseDTO();
                        res2.UserId = item.Id;
                        res2.Name = item.FirstName;
                        res2.Email = item.Email;

                        list.Add(res2);
                    }
                    resv.UsersDetails = list;
                    fres.Add(resv);
                }
                // var u = res.Where(x => x.UsersDetails.ToList().Count != 0);
                return fres;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<string> AssignTeamAsync(int SuperiorId, int TranieeId)
        {
            try
            {
                return _roleRepository.AssignTeams(SuperiorId, TranieeId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}