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

    public override string ToString()
    {
        string line = @"|";
        line += Name.PadLeft(35) + " |";
        if (Lecturer == null || Lecturer.Name == null)
        {
            line += "N/A".PadLeft(22) + " |";
        }else
        {
            line += Lecturer.Name.PadLeft(22) + " |";
        }
        line += CourseMembers.Count().ToString().PadLeft(5) + " |";

        return line;
    }
}
