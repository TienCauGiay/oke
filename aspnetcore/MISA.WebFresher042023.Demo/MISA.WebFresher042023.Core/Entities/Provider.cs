using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher042023.Core.Entities
{
    /// <summary>
    /// Thực thể nhà cung cấp
    /// </summary>
    /// Created By: BNTIEN (27/07/2023)
    public class Provider : BaseEntity
    {
        /// <summary>
        /// Khai báo các Property của thực thể nhà cung cấp
        /// </summary>
        #region Property riêng (Provider)
        public Guid ProviderId { get; set; }
        public string ProviderCode { get; set; }
        public string ProviderName { get; set; }
        public string? TaxCode { get; set; }
        public bool IsPersonal { get; set; }
        public bool IsCustomer { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Website { get; set; }
        public string? EmployeeId { get; set; }
        public string? InfoContact { get; set; }
        public string? TermPayment { get; set; }
        public string? AddressOther { get; set; }
        public string? Note { get; set; }
        #endregion
    }
}
