using MISA.WebFresher042023.Core.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher042023.Core.DTO.Providers
{
    public class ProviderUpdateDto
    {
        public Guid ProviderId { get; set; }
        [Required(ErrorMessageResourceType = typeof(ProviderVN), ErrorMessageResourceName = nameof(ProviderVN.Validate_NotNull_ProviderCode))]
        [MaxLength(20, ErrorMessageResourceType = typeof(ProviderVN), ErrorMessageResourceName = nameof(ProviderVN.Validate_MaxLength_ProviderCode))]
        public string ProviderCode { get; set; }
        [Required(ErrorMessageResourceType = typeof(ProviderVN), ErrorMessageResourceName = nameof(ProviderVN.Validate_NotNull_ProviderName))]
        [MaxLength(255, ErrorMessageResourceType = typeof(ProviderVN), ErrorMessageResourceName = nameof(ProviderVN.Validate_MaxLength_ProviderName))]
        public string ProviderName { get; set; }
        [MaxLength(20, ErrorMessageResourceType = typeof(ProviderVN), ErrorMessageResourceName = nameof(ProviderVN.Validate_MaxLength_TaxCode))]
        public string? TaxCode { get; set; }
        public bool IsPersonal { get; set; }
        public bool IsCustomer { get; set; }
        [MaxLength(255, ErrorMessageResourceType = typeof(ProviderVN), ErrorMessageResourceName = nameof(ProviderVN.Validate_MaxLength_Address))]
        public string? Address { get; set; }
        [MaxLength(50, ErrorMessageResourceType = typeof(ProviderVN), ErrorMessageResourceName = nameof(ProviderVN.Validate_MaxLength_PhoneNumber))]
        public string? PhoneNumber { get; set; }
        [MaxLength(255, ErrorMessageResourceType = typeof(ProviderVN), ErrorMessageResourceName = nameof(ProviderVN.Validate_MaxLength_Website))]
        public string? Website { get; set; }
        public List<Guid>? GroupIds { get; set; }
        [MaxLength(36, ErrorMessageResourceType = typeof(ProviderVN), ErrorMessageResourceName = nameof(ProviderVN.Validate_MaxLength_EmployeeId))]
        public string? EmployeeId { get; set; }
        public string? InfoContact { get; set; }
        public string? TermPayment { get; set; }
        public string? AddressOther { get; set; }
        public string? Note { get; set; }
    }
}
