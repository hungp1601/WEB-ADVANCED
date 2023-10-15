using System;
using System.Collections.Generic;

namespace btl_web.Models;

public partial class Assign
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime DueDate { get; set; }

    public DateTime StartDate { get; set; }

    public int UserId { get; set; }

    public int LessonId { get; set; }

    public bool? IsHidden { get; set; }

    public string? Url { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
