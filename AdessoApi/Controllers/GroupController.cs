using AdessoApi.Data.DTOs.Request;
using AdessoApi.Data.DTOs.Request.Country;
using AdessoApi.Data.DTOs.Response.Shared;
using AdessoApi.Entities;
using AdessoApi.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdessoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public GroupController(IServiceManager serviceManager) 
        {
            _serviceManager = serviceManager;
        }
    }
}
