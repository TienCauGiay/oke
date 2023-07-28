using AutoMapper;
using Microsoft.AspNetCore.Http;
using MISA.WebFresher042023.Core.DTO.Accounts;
using MISA.WebFresher042023.Core.DTO.Employees;
using MISA.WebFresher042023.Core.Entities;
using MISA.WebFresher042023.Core.Exceptions;
using MISA.WebFresher042023.Core.Interfaces.Infrastructures;
using MISA.WebFresher042023.Core.Interfaces.Services;
using MISA.WebFresher042023.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher042023.Core.Services
{
    /// <summary>
    /// Class triển khai các phương thức của entities account
    /// </summary>
    /// Created By: BNTIEN (19/07/2023)
    public class AccountService
        : BaseService<Account, AccountDto, AccountCreateDto, AccountUpdateDto>, IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository, IMapper mapper) : base(accountRepository, mapper)
        {
            _accountRepository = accountRepository;
        }

        #region Method riêng (Employee)

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
        public async Task<FilterAccountDto?> GetFilterAsync(int pageSize, int pageNumber, string? textSearch, int isRoot, int grade, string? accountNumber)
        {
            var filterAccount = await _accountRepository.GetFilterAsync(pageSize, pageNumber, textSearch, isRoot, grade, accountNumber);
            if (filterAccount?.Data != null)
            {
                var filterAccountDto = _mapper.Map<FilterAccountDto>(filterAccount);
                return filterAccountDto;
            }
            return null;
        }

        /// <summary>
        /// Thêm 1 tài khoản mới
        /// </summary>
        /// <param name="accountCreateDto"></param>
        /// <returns>Số hàng ảnh hưởng sau khi thêm</returns>
        /// <exception cref="ValidateException">Bắn ra lỗi nếu dữ liệu đầu vào không hợp lệ</exception>
        /// Created By: BNTIEN (20/07/2023)
        public override async Task<int> InsertAsync(AccountCreateDto accountCreateDto)
        {
            // Kiểm tra số tài khoản đã tồn tại hay chưa
            var checkDuplicateAccountNumber = await _accountRepository.GetByCodeAsync(accountCreateDto.AccountNumber);
            if (checkDuplicateAccountNumber != null)
            {
                throw new ValidateException(errorCode: StatusCodes.Status400BadRequest, Resources.ResourceVN.Validate_User_Input_Error, new Dictionary<string, string> { { "AccountNumber", AccountVN.ErrorLogic_Exist_AccountNumber } });

            }

            // Kiểm tra xem cha của số tài khoản đã tồn tại hay chưa
            var accountNumberParent = accountCreateDto.AccountNumber.Trim().Substring(0, accountCreateDto.AccountNumber.Trim().Length - 1);
            var checkParentExist = await _accountRepository.GetByCodeAsync(accountNumberParent);

            // Nếu chưa tồn tại, tài khoản được thêm mới sẽ là gốc
            if(checkParentExist == null)
            {
                accountCreateDto.Grade = 1;
                accountCreateDto.IsRoot = 1;
                accountCreateDto.ParentId = "";
            }
            else
            {
                if (string.IsNullOrEmpty(accountCreateDto.ParentId))
                {
                    throw new ValidateException(errorCode: StatusCodes.Status400BadRequest, Resources.ResourceVN.Validate_User_Input_Error, new Dictionary<string, string> { { "ParentId", AccountVN.Required_ParentId } });
                }

                // Nếu tài khoản tồng hợp (tức AccountNumber) khác AccountNumber của tài khoản cha 
                if (accountCreateDto.ParentId.Trim() != checkParentExist.AccountId.ToString().Trim())
                {
                    throw new ValidateException(errorCode: StatusCodes.Status400BadRequest, Resources.ResourceVN.Validate_User_Input_Error, new Dictionary<string, string> { { "AccountNumber", AccountVN.InValid_ParentId } });
                }
                accountCreateDto.Grade = checkParentExist.Grade + 1;
                accountCreateDto.IsRoot = 0;

                // Cập nhật cho node cha trạng thái IsParent
                if(checkParentExist.IsParent != 1)
                {
                    checkParentExist.IsParent = 1;
                    await _accountRepository.UpdateAsync(checkParentExist, checkParentExist.AccountId);
                }
            }

            accountCreateDto.IsParent = 0;
            accountCreateDto.State = 1;

            var res = await base.InsertAsync(accountCreateDto);
            return res;
        }

        public override async Task<int> UpdateAsync(AccountUpdateDto accountUpdateDto, Guid id)
        {
            if(accountUpdateDto.AccountId != id)
            {
                throw new ValidateException(StatusCodes.Status400BadRequest, Resources.ResourceVN.Validate_NotMatch, null);
            }

            // Kiểm tra số tài khoản đã tồn tại hay chưa
            var checkDuplicateAccountNumber = await _accountRepository.GetByCodeAsync(accountUpdateDto.AccountNumber);
            if (checkDuplicateAccountNumber != null)
            {
                // Nếu tồn tại nhưng khác với số tài khoản của tài khoản đang sửa
                if (checkDuplicateAccountNumber.AccountNumber != (await _accountRepository.GetByIdAsync(id))?.AccountNumber)
                {
                    throw new ValidateException(errorCode: StatusCodes.Status400BadRequest, Resources.ResourceVN.Validate_User_Input_Error, new Dictionary<string, string> { { "AccountNumber", AccountVN.ErrorLogic_Exist_AccountNumber } });
                }
            }

            // Nếu tài khoản được sửa đang là cha thì không cho sửa
            if(accountUpdateDto.IsParent == 1)
            {
                throw new ValidateException(errorCode: StatusCodes.Status400BadRequest, Resources.ResourceVN.Validate_User_Input_Error, new Dictionary<string, string> { { "AccountNumber", AccountVN.ErrorLogic_Constraint_AccountNumber } });
            }

            // Kiểm tra xem cha của số tài khoản đã tồn tại hay chưa
            var accountNumberParent = accountUpdateDto.AccountNumber.Trim().Substring(0, accountUpdateDto.AccountNumber.Trim().Length - 1);
            var checkParentExist = await _accountRepository.GetByCodeAsync(accountNumberParent);

            // Nếu chưa tồn tại, tài khoản được thêm mới sẽ là gốc
            if (checkParentExist == null)
            {
                accountUpdateDto.Grade = 1;
                accountUpdateDto.IsRoot = 1;
                accountUpdateDto.IsParent = 0;
            }
            else
            {
                // Nếu tài khoản tổng hợp rỗng
                if (string.IsNullOrEmpty(accountUpdateDto.ParentId))
                {
                    throw new ValidateException(errorCode: StatusCodes.Status400BadRequest, Resources.ResourceVN.Validate_User_Input_Error, new Dictionary<string, string> { { "ParentId", AccountVN.Required_ParentId } });

                }

                // Nếu tài khoản tồng hợp (tức AccountNumber) khác AccountNumber của tài khoản cha 
                if (accountUpdateDto.ParentId.Trim() != checkParentExist.AccountId.ToString().Trim())
                {
                    throw new ValidateException(errorCode: StatusCodes.Status400BadRequest, Resources.ResourceVN.Validate_User_Input_Error, new Dictionary<string, string> { { "AccountNumber", AccountVN.InValid_ParentId } });

                }
                accountUpdateDto.Grade = checkParentExist.Grade + 1;
                accountUpdateDto.IsRoot = 0;
                accountUpdateDto.IsParent = 0;

                // Cập nhật cho node cha mà thằng update chuyển đến trạng thái IsParent
                if (checkParentExist.IsParent != 1)
                {
                    checkParentExist.IsParent = 1;
                    await _accountRepository.UpdateAsync(checkParentExist, checkParentExist.AccountId);
                }

                // Cập nhật trạng thái IsParent cho node cha mà thằng update rời đi
                var accountUpdateBefore = await _accountRepository.GetByIdAsync(id);
                var (parentAccount, countChildren) = await _accountRepository.GetCountChildren(accountUpdateBefore.AccountNumber.Substring(0, accountUpdateBefore.AccountNumber.Length - 1));
                if(countChildren < 2 && parentAccount != null && parentAccount.AccountNumber != accountUpdateDto.AccountNumber.Substring(0, accountUpdateBefore.AccountNumber.Length - 1))
                {
                    parentAccount.IsParent = 0;
                    await _accountRepository.UpdateAsync(parentAccount, parentAccount.AccountId);
                }
            }

            var res = await base.UpdateAsync(accountUpdateDto, id);
            return res;
        }

        public override async Task<int> DeleteAsync(Guid id)
        {
            // Kiểm tra nếu tài khoản là cha thì không cho xóa
            var accountDelete = await _accountRepository.GetByIdAsync(id);
            if(accountDelete?.IsParent == 1)
            {
                throw new ValidateException(StatusCodes.Status400BadRequest, Resources.ResourceVN.Validate_User_Input_Error, new Dictionary<string, string> { { "IsParent", "Không thể xóa danh mục cha nếu chưa xóa danh mục con" } });
            }

            // Cập nhật trạng thái IsParent cho node cha có thằng con bị xóa
            var (parentAccount, countChildren) = await _accountRepository.GetCountChildren(accountDelete.AccountNumber.Substring(0, accountDelete.AccountNumber.Length - 1));
            if (countChildren < 2 && parentAccount != null)
            {
                parentAccount.IsParent = 0;
                await _accountRepository.UpdateAsync(parentAccount, parentAccount.AccountId);
            }

            var res = await base.DeleteAsync(id);
            return res;
        }

        /// <summary>
        /// Lấy danh sách tất cả các con của tài khoản có số tài khoản là tham số truyền vào
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        /// Created By: BNTIEN (26/07/2023)
        public async Task<List<AccountDto>?> GetAllChildrenAsync(string accountNumber)
        {
            var accountChildrens = await _accountRepository.GetAllChildrenAsync(accountNumber);
            if(accountChildrens != null)
            {
                var accountChildrensDto = _mapper.Map<List<AccountDto>>(accountChildrens);
                return accountChildrensDto;
            }
            return null;
        }

        /// <summary>
        /// Cập nhật trạng thái tài khoản
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="state"></param>
        /// <param name="isUpdateChildren"></param>
        /// <returns></returns>
        /// Created By: BNTIEN (26/07/2023)
        public async Task<int> UpdateStateAsync(string accountNumber, int state, int isUpdateChildren)
        {
            var res = await _accountRepository.UpdateStateAsync(accountNumber, state, isUpdateChildren);
            return res;
        }
        #endregion
    }
}
