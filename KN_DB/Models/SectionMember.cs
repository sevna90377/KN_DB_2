using System;
using System.Collections.Generic;

namespace KN_DB.Models;

/// <summary>
/// Table handling the many-to-many relation of &apos;Section&apos; and &apos;Member&apos; tables
/// </summary>
public partial class SectionMember
{
    public int SectionMemberId { get; set; }

    public int MemberId { get; set; }

    public int SectionId { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual Section Section { get; set; } = null!;
}
