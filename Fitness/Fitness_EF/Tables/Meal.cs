using System;
using System.Collections.Generic;

namespace Fitness_EF.Tables;

public partial class Meal
{
    public long timeID { get; set; }

    public string Mealname { get; set; } = null!;

    public virtual ICollection<Diary> Diary { get; set; } = new List<Diary>();
}
