using System;
using System.Collections.Generic;

namespace Fitness.Models;

public partial class Bodydata
{
    public long dataID { get; set; }

    public DateTime Createtime { get; set; }

    public double Weight { get; set; }

    public double? MuscleMass { get; set; }

    public double? BodyFat { get; set; }

    public double? BMR { get; set; }

    public double? TDEE { get; set; }

    public long CreateUser { get; set; }

    public long levelID { get; set; }

    public virtual Workoutlevel level { get; set; }
}
