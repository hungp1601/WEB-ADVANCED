using System;
using System.Collections.Generic;

namespace btl_web.Models;

public partial class User
{
    public int Id { get; set; }

    public string Password { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual ICollection<Assign> Assigns { get; set; } = new List<Assign>();

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<UserHasCourse> UserHasCourses { get; set; } = new List<UserHasCourse>();
}
