using System;
using System.Collections.Generic;

namespace Fitness_EF.Tables;

public partial class Admin
{
    public long adminID { get; set; }

    public DateTime Createtime { get; set; }

    public string Name { get; set; } = null!;

    public string Photo { get; set; } = null!;

    public string Account { get; set; } = null!;

    public string Password { get; set; } = null!;
}
