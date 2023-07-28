﻿using MISA.WebFresher042023.Core.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher042023.Core.DTO.Accounts
{
    /// <summary>
    /// Lớp chuyển đổi đối tượng account thêm mới, bỏ đi 1 số trường không cần thiết
    /// </summary>
    /// Created By: BNTIEN (20/07/2023)
    public class AccountCreateDto
    {
        #region Property
        /// <summary>
        /// Số tài khoản
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(AccountVN), ErrorMessageResourceName = nameof(AccountVN.Validate_NotNull_AccountNumber))]
        [MaxLength(50, ErrorMessageResourceType = typeof(AccountVN), ErrorMessageResourceName = nameof(AccountVN.Validate_MaxLength_AccountNumber))]
        [MinLength(3, ErrorMessageResourceType = typeof(AccountVN), ErrorMessageResourceName = nameof(AccountVN.Validate_MinLength_AccountNumber))]
        public string AccountNumber { get; set; }
        /// <summary>
        /// Tên tài khoản
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(AccountVN), ErrorMessageResourceName = nameof(AccountVN.Validate_NotNull_AccountName))]
        [MaxLength(255, ErrorMessageResourceType = typeof(AccountVN), ErrorMessageResourceName = nameof(AccountVN.Validate_MaxLength_AccountName))]
        public string AccountName { get; set; }
        /// <summary>
        /// Tên tiếng anh
        /// </summary>
        [MaxLength(255, ErrorMessageResourceType = typeof(AccountVN), ErrorMessageResourceName = nameof(AccountVN.Validate_MaxLength_AccountEnglishName))]
        public string? AccountNameEnglish { get; set; }
        /// <summary>
        /// Id cha
        /// </summary>
        [MaxLength(36, ErrorMessageResourceType = typeof(AccountVN), ErrorMessageResourceName = nameof(AccountVN.Validate_MaxLength_ParentId))]
        public string? ParentId { get; set; }
        /// <summary>
        /// Tính chất
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(AccountVN), ErrorMessageResourceName = nameof(AccountVN.Validate_NotNull_Nature))]
        [MaxLength(255, ErrorMessageResourceType = typeof(AccountVN), ErrorMessageResourceName = nameof(AccountVN.Validate_MaxLength_Nature))]
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
