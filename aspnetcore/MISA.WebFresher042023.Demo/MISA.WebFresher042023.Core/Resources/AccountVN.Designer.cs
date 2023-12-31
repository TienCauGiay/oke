﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MISA.WebFresher042023.Core.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class AccountVN {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal AccountVN() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MISA.WebFresher042023.Core.Resources.AccountVN", typeof(AccountVN).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tài khoản này có ràng buộc với các tài khoản khác, không được sửa.
        /// </summary>
        public static string ErrorLogic_Constraint_AccountNumber {
            get {
                return ResourceManager.GetString("ErrorLogic_Constraint_AccountNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Số tài khoản đã tồn tại trong hệ thống.
        /// </summary>
        public static string ErrorLogic_Exist_AccountNumber {
            get {
                return ResourceManager.GetString("ErrorLogic_Exist_AccountNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tài khoản tổng hợp không hợp lệ, Tài khoản chi tiết phải bắt đầu từ tài khoản tổng hợp.
        /// </summary>
        public static string InValid_ParentId {
            get {
                return ResourceManager.GetString("InValid_ParentId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Phải điền thông tin tài khoản tổng hợp.
        /// </summary>
        public static string Required_ParentId {
            get {
                return ResourceManager.GetString("Required_ParentId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tên tiếng anh tối đa 255 kí tự.
        /// </summary>
        public static string Validate_MaxLength_AccountEnglishName {
            get {
                return ResourceManager.GetString("Validate_MaxLength_AccountEnglishName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tên tài khoản tối đa 255 kí tự.
        /// </summary>
        public static string Validate_MaxLength_AccountName {
            get {
                return ResourceManager.GetString("Validate_MaxLength_AccountName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Số tài khoản tối đa 50 kí tự.
        /// </summary>
        public static string Validate_MaxLength_AccountNumber {
            get {
                return ResourceManager.GetString("Validate_MaxLength_AccountNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tính chất tối đa 255 kí tự.
        /// </summary>
        public static string Validate_MaxLength_Nature {
            get {
                return ResourceManager.GetString("Validate_MaxLength_Nature", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tài khoản tổng hợp tối đa 36 kí tự.
        /// </summary>
        public static string Validate_MaxLength_ParentId {
            get {
                return ResourceManager.GetString("Validate_MaxLength_ParentId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Số tài khoản tối thiểu 3 kí tự.
        /// </summary>
        public static string Validate_MinLength_AccountNumber {
            get {
                return ResourceManager.GetString("Validate_MinLength_AccountNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tên tài khoản không được để trống.
        /// </summary>
        public static string Validate_NotNull_AccountName {
            get {
                return ResourceManager.GetString("Validate_NotNull_AccountName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Số tài khoản không được để trống.
        /// </summary>
        public static string Validate_NotNull_AccountNumber {
            get {
                return ResourceManager.GetString("Validate_NotNull_AccountNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tính chất không được để trống.
        /// </summary>
        public static string Validate_NotNull_Nature {
            get {
                return ResourceManager.GetString("Validate_NotNull_Nature", resourceCulture);
            }
        }
    }
}
