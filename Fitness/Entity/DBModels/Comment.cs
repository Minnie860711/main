using System;
using System.Collections.Generic;

namespace Fitness.Models;

public partial class Comment
{
    public long commentID { get; set; }

    public string Content { get; set; }

    public DateTime Posttime { get; set; }

    public long postID { get; set; }

    public long CreateUser { get; set; }

    public DateTime CreateTime { get; set; }

    public virtual Post post { get; set; }
}
