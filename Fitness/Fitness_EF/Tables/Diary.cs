using System;
using System.Collections.Generic;

namespace Fitness_EF.Tables;

public partial class Diary
{
    public long diaryID { get; set; }

    public DateTime Createtime { get; set; }

    public long foodID { get; set; }

    public long CreateUser { get; set; }

    public long timeID { get; set; }

    public virtual Food food { get; set; } = null!;

    public virtual Meal time { get; set; } = null!;
}
