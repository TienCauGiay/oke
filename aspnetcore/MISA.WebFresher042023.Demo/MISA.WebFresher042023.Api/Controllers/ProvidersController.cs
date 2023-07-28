using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher042023.Core.DTO.Providers;
using MISA.WebFresher042023.Core.Interfaces.Services;
using MISA.WebFresher042023.Core.Services;

namespace MISA.WebFresher042023.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProvidersController : BaseController<ProviderDto, ProviderCreateDto, ProviderUpdateDto>
    {
        private readonly IProviderService _providerService;
        public ProvidersController(IProviderService providerService) : base(providerService)
        {
            _providerService = providerService;
        }

        /// <summary>
        /// Tìm kiếm phân trang
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="textSearch"></param>
        /// <returns>Danh sách nhà cung cấp theo tìm kiếm phân trang</returns>
        /// Created By: BNTIEN (27/07/2023)
        [HttpGet("filter")]
        public async Task<IActionResult> GetFilter(int pageSize, int pageNumber, string? textSearch)
        {
            var res = await _providerService.GetFilterAsync(pageSize, pageNumber, textSearch);
            return Ok(res);
        }

        /// <summary>
        /// Lấy mã nhà cung cấp lớn nhất trong hệ thống
        /// </summary>
        /// <returns>mã nhà cung cấp lớn nhất (nếu có)</returns>
        /// Created By: BNTIEN (28/07/2023)
        [HttpGet("maxcode")]
        public async Task<IActionResult> GetByCodeMax()
        {
            var res = await _providerService.GetByCodeMaxAsync();
            return Ok(res);
        }
    }
}
