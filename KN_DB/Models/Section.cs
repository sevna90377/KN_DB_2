using KN_DB.Attributes;
using System;
using System.Collections.Generic;

namespace KN_DB.Models;

/// <summary>
/// Student Circle&apos;s distinct sections of activity
/// </summary>
public partial class Section
{
    [IgnoreOnCreation]
    public int SectionId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
    [IgnoreOnCreation]
    public int? LeadId { get; set; }
    [IgnoreOnCreation]
    public virtual Member? Lead { get; set; }
    [IgnoreOnCreation]
    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    [IgnoreOnCreation]
    public virtual ICollection<SectionMember> SectionMembers { get; set; } = new List<SectionMember>();

    public override string ToString()
    {
        string line = @"|";

        // Name column (mandatory, no null check)
        line += Name.PadLeft(22) + "  |";

        // Lead column (nullable)
        string leadName = Lead != null ? Lead.Name : "N/A";
        line += leadName.PadLeft(22) + "  |";

        // Projects count column
        line += Projects.Count.ToString().PadLeft(8) + "  |";

        // SectionMembers count column
        line += SectionMembers.Count.ToString().PadLeft(8) + "  |";

        return line;
    }

}
