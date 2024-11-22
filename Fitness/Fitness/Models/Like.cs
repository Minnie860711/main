using System;
using System.Collections.Generic;

namespace Fitness.Models;

public partial class Like
{
    public long likeID { get; set; }

    public long postID { get; set; }

    public long CreateUser { get; set; }

    public DateTime CreateTime { get; set; }

    public virtual Post post { get; set; }
}
