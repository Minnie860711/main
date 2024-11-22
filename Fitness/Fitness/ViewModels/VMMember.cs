using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fitness.ViewModels;

public partial class VMMember
{
    /// <summary>
    ///  會員編號
    /// </summary>
    [DisplayName("會員編號")]
    public long memberID { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    [DisplayName("姓名")]
    [Required(ErrorMessage = "請填寫會員姓名")]
    [StringLength(30, ErrorMessage = "會員姓名不得超過30字")]
    public string Name { get; set; }

    /// <summary>
    /// 照片
    /// </summary>
    [DisplayName("照片")]
    public string Photo { get; set; }

    /// <summary>
    /// 建立日期
    /// </summary>
    [DisplayName("建立日期")]
    public DateTime Createtime { get; set; }

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

    [DisplayName("確認密碼")]
    [Required(ErrorMessage = "請再填寫一次密碼")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "密碼最少6碼")]
    [MaxLength(30, ErrorMessage = "密碼最多30碼")]
    [Compare("Password", ErrorMessage = "兩次輸入不同")]
    public string ConfirmPassword { get; set; }
        
    /// <summary>
    /// 生日
    /// </summary>
    [DisplayName("生日")]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "請填寫生日")]
    public DateTime Birthday { get; set; }

    /// <summary>
    /// 身高
    /// </summary>
    [DisplayName("身高")]
    [Required(ErrorMessage = "請填寫身高")]
    public decimal Height { get; set; }

    /// <summary>
    /// 性別
    /// </summary>
    [DisplayName("生理性別")]
    [Required(ErrorMessage = "請填寫生理性別")]
    public bool Gender { get; set; }

    /// <summary>
    /// 目標體重
    /// </summary>
    [DisplayName("目標體重")]
    [Required(ErrorMessage = "請填寫目標體重")]
    public decimal Target_Weight { get; set; }

    /// <summary>
    /// 目標日期
    /// </summary>
    [DisplayName("預計達成日")]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
    [Required(ErrorMessage = "請填寫預計達成日")]
    [DataType(DataType.Date)]
    public DateTime Target_Date { get; set; }

    /// <summary>
    /// 封鎖
    /// </summary>
    [DisplayName("封鎖")]
    public bool Block { get; set; }
}
