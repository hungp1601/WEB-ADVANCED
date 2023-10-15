using System;
using System.Collections.Generic;

namespace btl_web.Models;

public partial class CourseCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<CourseHasCategory> CourseHasCategories { get; set; } = new List<CourseHasCategory>();
}
