using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher042023.Core.DTO.GroupProviders;
using MISA.WebFresher042023.Core.Interfaces.Services;

namespace MISA.WebFresher042023.Api.Controllers
{
    /// <summary>
    /// Controller triển khai các phương thức của entities group provider
    /// </summary>
    /// Created By: BNTIEN (27/07/2023)
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GroupProvidersController : BaseController<GroupProviderDto, GroupProviderCreateDto, GroupProviderUpdateDto>
    {
        private readonly IGroupProviderService _groupProviderService;
        public GroupProvidersController(IGroupProviderService groupProviderService) : base(groupProviderService)
        {
            _groupProviderService = groupProviderService;
        }
    }
}
