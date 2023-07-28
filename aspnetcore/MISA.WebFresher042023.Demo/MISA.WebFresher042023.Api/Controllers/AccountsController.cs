using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher042023.Core.DTO.Accounts;
using MISA.WebFresher042023.Core.Interfaces.Services;
using MISA.WebFresher042023.Core.Services;

namespace MISA.WebFresher042023.Api.Controllers
{
    /// <summary>
    /// Controller triển khai các phương thức của entities account
    /// </summary>
    /// Created By: BNTIEN (19/07/2023)
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<AccountDto, AccountCreateDto, AccountUpdateDto>
    {
        private readonly IAccountService _accountService;
        public AccountsController(IAccountService accountService) : base(accountService)
        {
            _accountService = accountService;
        }
        #region API riêng (Account)

        /// <summary>
        /// Tìm kiếm và phân trang trên giao diện
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="textSearch"></param>
        /// <param name="isRoot"></param>
        /// <param name="grade"></param>
        /// <param name="accountNumber"></param>
        /// <returns>Danh sách tài khoản theo tìm kiếm, phân trang</returns>
        /// Created By: BNTIEN (19/07/2023)
        [HttpGet("filter")]
        public async Task<IActionResult> GetFilter(int pageSize, int pageNumber, string? textSearch, bool isRoot, int grade, string? accountNumber)
        {
            var root = isRoot == true ? 1 : 0;
            var res = await _accountService.GetFilterAsync(pageSize, pageNumber, textSearch, root, grade, accountNumber);
            return Ok(res);
        }

        /// <summary>
        /// Lấy danh sách tất cả các con của tài khoản có số tài khoản là tham số truyền vào
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        /// Created By: BNTIEN (26/07/2023)
        [HttpGet("children")]
        public async Task<IActionResult> GetAllChildren(string accountNumber)
        {
            var res = await _accountService.GetAllChildrenAsync(accountNumber);
            return Ok(res);
        }

        [HttpPut("state")]
        public async Task<IActionResult> UpdateState(AccountUpdateDto account, int state, int isUpdateChildren)
        {
            var res = await _accountService.UpdateStateAsync(account.AccountNumber, state, isUpdateChildren);
            return Ok(res);
        }
        #endregion
    }
}
