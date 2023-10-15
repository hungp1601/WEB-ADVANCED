using System;
using System.Collections.Generic;

namespace btl_web.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int TeacherId { get; set; }

    public bool Visible { get; set; }

    public virtual ICollection<CourseHasCategory> CourseHasCategories { get; set; } = new List<CourseHasCategory>();

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual User Teacher { get; set; } = null!;

    public virtual ICollection<UserHasCourse> UserHasCourses { get; set; } = new List<UserHasCourse>();
}
