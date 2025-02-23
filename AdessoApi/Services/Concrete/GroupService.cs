using AdessoApi.Data;
using AdessoApi.Data.DTOs.Request;
using AdessoApi.Data.DTOs.Request.Team;
using AdessoApi.Data.DTOs.Response.Shared;
using AdessoApi.Entities;
using AdessoApi.Services.Abstract;
using System.Linq.Expressions;

namespace AdessoApi.Services.Concrete
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<Group?>> AddGroupAsync(AddGroupDto dto, string username)
        {
            try
            {

                Group group = new Group
                {
                    Name = dto.Name,
                    CreatedBy = username,
                    UpdatedBy = username
                };

                return await _unitOfWork.Groups.AddAsync(group);


            }
            catch (Exception ex)
            {
                return new ServiceResponse<Group?>().SetErrorAdd("Team", ex.Message);
            }
        }
    }
}
