using System;
using System.Collections.Generic;

namespace KN_DB.Models;

/// <summary>
/// Student Circle&apos;s distinct sections of activity
/// </summary>
public partial class Section
{
    public int SectionId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? LeadId { get; set; }

    public virtual Member? Lead { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<SectionMember> SectionMembers { get; set; } = new List<SectionMember>();
}
