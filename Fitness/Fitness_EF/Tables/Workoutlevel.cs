using System;
using System.Collections.Generic;

namespace Fitness_EF.Tables;

public partial class Workoutlevel
{
    public long levelID { get; set; }

    public string Level { get; set; } = null!;

    public virtual ICollection<Bodydata> Bodydata { get; set; } = new List<Bodydata>();
}
