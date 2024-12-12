using System;
using System.Collections.Generic;

namespace Fitness_EF.Tables;

public partial class Food
{
    public long foodID { get; set; }

    public string Foodname { get; set; } = null!;

    public DateTime Createtime { get; set; }

    public double Amount { get; set; }

    public double Weight { get; set; }

    public double Calorie { get; set; }

    public double? Protein { get; set; }

    public double? Fat { get; set; }

    public double? Carbon { get; set; }

    public string? unit { get; set; }

    public long CreateUser { get; set; }

    public virtual ICollection<Diary> Diary { get; set; } = new List<Diary>();
}
