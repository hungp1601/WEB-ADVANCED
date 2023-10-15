using System;
using System.Collections.Generic;

namespace btl_web.Models;

public partial class UserHasCourse
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int UserId { get; set; }

    public bool? Status { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
