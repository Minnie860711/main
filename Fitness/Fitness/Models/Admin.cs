using System;
using System.Collections.Generic;

namespace Fitness.Models;

public partial class Admin
{
    public long adminID { get; set; }

    public DateTime Createtime { get; set; }

    public string Name { get; set; }

    public string Photo { get; set; }

    public string Account { get; set; }

    public string Password { get; set; }
}
