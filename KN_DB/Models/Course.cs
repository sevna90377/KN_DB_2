using System;
using System.Collections.Generic;

namespace KN_DB.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? LecturerId { get; set; }

    public virtual ICollection<CourseMember> CourseMembers { get; set; } = new List<CourseMember>();

    public virtual Member? Lecturer { get; set; }
}
