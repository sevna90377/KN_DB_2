using System;
using System.Collections.Generic;

namespace KN_DB.Models;

/// <summary>
/// Table handling the many-to-many relation of &apos;Project&apos; and &apos;Member&apos; tables
/// </summary>
public partial class ProjectMember
{
    public int ProjectMemberId { get; set; }

    public int MemberId { get; set; }

    public int ProjectId { get; set; }

    public int RoleId { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
