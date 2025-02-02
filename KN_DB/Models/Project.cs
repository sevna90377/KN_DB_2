using KN_DB.Attributes;
using System;
using System.Collections.Generic;

namespace KN_DB.Models;

public partial class Project
{
    [IgnoreOnCreation]
    public int ProjectId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? StartDate { get; set; }
    
    public int SectionId { get; set; }
    [IgnoreOnCreation]
    public virtual ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();
    [IgnoreOnCreation]
    public virtual Section Section { get; set; } = null!;
}
