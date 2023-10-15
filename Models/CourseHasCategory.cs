using System;
using System.Collections.Generic;

namespace btl_web.Models;

public partial class CourseHasCategory
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int CategorieId { get; set; }

    public virtual CourseCategory Categorie { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;
}
