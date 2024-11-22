using System;
using System.Collections.Generic;

namespace Fitness.Models;

public partial class Diary
{
    public long diaryID { get; set; }

    public DateTime Createtime { get; set; }

    public long foodID { get; set; }

    public long CreateUser { get; set; }

    public long timeID { get; set; }

    public virtual Food food { get; set; }

    public virtual Meal time { get; set; }
}
