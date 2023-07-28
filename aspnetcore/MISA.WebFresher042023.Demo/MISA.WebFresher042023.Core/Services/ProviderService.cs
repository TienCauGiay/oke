using AutoMapper;
using Microsoft.AspNetCore.Http;
using MISA.WebFresher042023.Core.DTO.Accounts;
using MISA.WebFresher042023.Core.DTO.Employees;
using MISA.WebFresher042023.Core.DTO.Providers;
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
    public class ProviderService : BaseService<Provider, ProviderDto, ProviderCreateDto, ProviderUpdateDto>, IProviderService
    {
        private readonly IProviderRepository _providerRepository;

        private readonly IMapper _mapper;
        public ProviderService(IProviderRepository providerRepository, IMapper mapper) : base(providerRepository, mapper)
        {
            _providerRepository = providerRepository;
            _mapper = mapper;
        }

        public async Task<FilterProviderDto?> GetFilterAsync(int pageSize, int pageNumber, string? textSearch)
        {
            var filterProvider = await _providerRepository.GetFilterAsync(pageSize, pageNumber, textSearch);
            if (filterProvider?.Data != null)
            {
                var filterProviderDto = _mapper.Map<FilterProviderDto>(filterProvider);
                return filterProviderDto;
            }
            return null;
        }

        public async Task<string?> GetByCodeMaxAsync()
        {
            var codeMax = await _providerRepository.GetByCodeMaxAsync();
            if (codeMax != null)
            {
                var maxLength = codeMax.Length - 4;
                var maxProviderCode = int.Parse(codeMax.Substring(4)) + 1;
                var newProviderCode = $"NCC-{maxProviderCode.ToString().PadLeft(maxLength, '0')}";
                return newProviderCode;
            }
            return "";
        }

        public override async Task<int> InsertAsync(ProviderCreateDto providerCreateDto)
        {
            // Kiểm tra mã nhà cung cấp đã tồn tại hay chưa
            var checkDuplicateCode = await _providerRepository.GetByCodeAsync(providerCreateDto.ProviderCode);
            if (checkDuplicateCode != null)
            {
                throw new ValidateException(errorCode: StatusCodes.Status400BadRequest, Resources.ResourceVN.Validate_User_Input_Error, new Dictionary<string, string> { { "ProviderCode", ProviderVN.ErrorLogic_Exist_ProviderCode } });
            }

            var provider = _mapper.Map<Provider>(providerCreateDto);

            // Thêm nhà cung cấp 
            var res = await _providerRepository.InsertAsync(provider, providerCreateDto.GroupIds);
            return res;
        }

        public override async Task<int> UpdateAsync(ProviderUpdateDto providerUpdateDto, Guid id)
        {
            // Kiểm tra id đang được sửa có trùng khớp không
            if (providerUpdateDto.ProviderId != id)
            {
                throw new ValidateException(StatusCodes.Status400BadRequest, Resources.ResourceVN.Validate_NotMatch, null);
            }

            // Kiểm tra mã nhà cung cấp đã tồn tại hay chưa
            var checkDuplicateCode = await _providerRepository.GetByCodeAsync(providerUpdateDto.ProviderCode);
            if (checkDuplicateCode != null)
            {
                // Nếu tồn tại nhưng khác với mã nhà cung cấp của nhà cung cấp đang sửa
                if (checkDuplicateCode.ProviderCode != (await _providerRepository.GetByIdAsync(id))?.ProviderCode)
                {
                    throw new ValidateException(errorCode: StatusCodes.Status400BadRequest, Resources.ResourceVN.Validate_User_Input_Error, new Dictionary<string, string> { { "ProviderCode", ProviderVN.ErrorLogic_Exist_ProviderCode } });
                }
            }

            var provider = _mapper.Map<Provider>(providerUpdateDto);

            // Cập nhật thông tin nhà cung cấp
            var res = await _providerRepository.UpdateAsync(provider, id, providerUpdateDto.GroupIds);
            return res;
        }
    }
}
