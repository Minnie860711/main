using System;
using System.Collections.Generic;

namespace Fitness.Models;

public partial class Workoutlevel
{
    public long levelID { get; set; }

    public string Level { get; set; }

    public virtual ICollection<Bodydata> Bodydata { get; set; } = new List<Bodydata>();
}
