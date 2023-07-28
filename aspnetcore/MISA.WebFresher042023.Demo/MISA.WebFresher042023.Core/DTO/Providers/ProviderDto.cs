using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher042023.Core.DTO.Providers
{
    public class ProviderDto
    {
        public Guid ProviderId { get; set; }
        public string ProviderCode { get; set; }
        public string ProviderName { get; set; }
        public string? TaxCode { get; set; }
        public bool IsPersonal { get; set; }
        public bool IsCustomer { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Website { get; set; }
        public List<Guid>? GroupProviderIds { get; set; }
        public string? EmployeeId { get; set; }
        public string? InfoContact { get; set; }
        public string? TermPayment { get; set; }
        public string? AddressOther { get; set; }
        public string? Note { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
