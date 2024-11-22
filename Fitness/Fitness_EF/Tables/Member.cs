using System;
using System.Collections.Generic;

namespace Fitness_EF.Tables;

public partial class Member
{
    /// <summary>
    ///  會員編號
    /// </summary>
    public long memberID { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 照片
    /// </summary>
    public string? Photo { get; set; }

    /// <summary>
    /// 建立日期
    /// </summary>
    public DateTime Createtime { get; set; }

    /// <summary>
    /// 帳號
    /// </summary>
    public string Account { get; set; } = null!;

    /// <summary>
    /// 密碼
    /// </summary>
    public string Password { get; set; } = null!;

    /// <summary>
    /// 生日
    /// </summary>
    public DateTime Birthday { get; set; }

    /// <summary>
    /// 年齡
    /// </summary>
    public int? Age { get; set; }

    /// <summary>
    /// 身高
    /// </summary>
    public decimal Height { get; set; }

    /// <summary>
    /// 性別
    /// </summary>
    public bool Gender { get; set; }

    /// <summary>
    /// 目標體重
    /// </summary>
    public decimal Target_Weight { get; set; }

    /// <summary>
    /// 目標日期
    /// </summary>
    public DateTime Target_Date { get; set; }

    /// <summary>
    /// 封鎖
    /// </summary>
    public string Block { get; set; } = null!;
}
