using System;
using System.Collections.Generic;

namespace Fitness_EF.Tables;

public partial class Post
{
    public long postID { get; set; }

    public string Photo { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime Posttime { get; set; }

    public long CreateUser { get; set; }

    public DateTime CreateTime { get; set; }

    public virtual ICollection<Comment> Comment { get; set; } = new List<Comment>();

    public virtual ICollection<Like> Like { get; set; } = new List<Like>();
}
