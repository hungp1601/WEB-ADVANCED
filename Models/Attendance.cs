using System;
using System.Collections.Generic;

namespace btl_web.Models;

public partial class Attendance
{
    public int Id { get; set; }

    public int LessonId { get; set; }

    public int UserId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime AttendanceTime { get; set; }

    public DateTime DueTime { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
