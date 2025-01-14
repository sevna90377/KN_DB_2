using System;
using System.Collections.Generic;

namespace KN_DB.Models;

/// <summary>
/// Currently registered members of the science circle
/// </summary>
public partial class Member
{
    public int MemberId { get; set; }

    public string? Name { get; set; }

    public string? DiscordName { get; set; }

    public DateOnly? JoinDate { get; set; }

    public bool? IsCouncilMember { get; set; }

    public virtual ICollection<CourseMember> CourseMembers { get; set; } = new List<CourseMember>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();

    public virtual ICollection<SectionMember> SectionMembers { get; set; } = new List<SectionMember>();

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
