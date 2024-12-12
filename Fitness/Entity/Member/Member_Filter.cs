using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entity.Member;

public partial class Member_Filter
{
    /// <summary>
    ///  會員編號
    /// </summary>
    [DisplayName("會員編號")]
    public long memberID { get; set; }

    /// <summary>
    /// 帳號
    /// </summary>
    [DisplayName("帳號")]
    [Required(ErrorMessage = "請填寫帳號")]
    [StringLength(30, ErrorMessage = "帳號不得超過30字")]
    public string Account { get; set; }

    /// <summary>
    /// 密碼
    /// </summary>
    [DisplayName("密碼")]
    [Required(ErrorMessage = "請填寫密碼")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "密碼最少6碼")]
    [MaxLength(30, ErrorMessage = "密碼最多30碼")]
    public string Password { get; set; }

}
