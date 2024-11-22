using System;
using System.Collections.Generic;

namespace Fitness.Models;

public partial class Meal
{
    public long timeID { get; set; }

    public string Mealname { get; set; }

    public virtual ICollection<Diary> Diary { get; set; } = new List<Diary>();
}
