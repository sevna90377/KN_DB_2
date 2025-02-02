using KN_DB.Attributes;
using System;
using System.Collections.Generic;

namespace KN_DB.Models;

/// <summary>
/// Currently registered members of the science circle
/// </summary>
public partial class Member
{
    [IgnoreOnCreation]
    public int MemberId { get; set; }

    public string? Name { get; set; }

    public string? DiscordName { get; set; }

    public DateOnly? JoinDate { get; set; }

    public bool IsCouncilMember { get; set; }
    [IgnoreOnCreation]
    public virtual ICollection<CourseMember> CourseMembers { get; set; } = new List<CourseMember>();
    [IgnoreOnCreation]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    [IgnoreOnCreation]
    public virtual ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();
    [IgnoreOnCreation]
    public virtual ICollection<SectionMember> SectionMembers { get; set; } = new List<SectionMember>();
    [IgnoreOnCreation]
    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();


    public override string ToString()
    {
        string line = "|".PadLeft(13);
        line += Name.PadLeft(32) + "  |";
        if(DiscordName == null)
        {
            DiscordName = "N/A";
        }
        line += DiscordName.PadLeft(27) + "  |";
        line += JoinDate.ToString().PadLeft(16) + "  |";

        return line;
    }
}
