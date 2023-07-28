using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher042023.Core.DTO.Accounts
{
    /// <summary>
    /// Lớp chuyển đổi đối tượng account, bỏ đi 1 số trường không cần thiết
    /// </summary>
    /// Created By: BNTIEN (19/07/2023)
    public class AccountDto
    {
        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid AccountId { get; set; }
        /// <summary>
        /// Số tài khoản
        /// </summary>
        public string AccountNumber { get; set; }
        /// <summary>
        /// Tên tài khoản
        /// </summary>
        public string AccountName { get; set; }
        /// <summary>
        /// Tên tiếng anh
        /// </summary>
        public string? AccountNameEnglish { get; set; }
        /// <summary>
        /// Tính chất
        /// </summary>
        public string Nature { get; set; }
        /// <summary>
        /// Diễn giải
        /// </summary>
        public string? Explain { get; set; }
        /// <summary>
        /// Cấp
        /// </summary>
        public int? Grade { get; set; }
        /// <summary>
        /// Id cha
        /// </summary>
        public string? ParentId { get; set; }
        /// <summary>
        /// Có là cha hay không
        /// </summary>
        public int? IsParent { get; set; }
        /// <summary>
        /// Có là gốc hay không
        /// </summary>
        public int? IsRoot { get; set; }
        /// <summary>
        /// Trạng thái
        /// </summary>
        public int? State { get; set; }
        /// <summary>
        /// Đối tượng người dùng
        /// </summary>
        public int? UserObject { get; set; }

        #endregion
    }
}
