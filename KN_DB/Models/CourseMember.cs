using System;
using System.Collections.Generic;

namespace KN_DB.Models;

/// <summary>
/// Table handling the many-to-many relation of &apos;Course&apos; and &apos;Member&apos; tables
/// </summary>
public partial class CourseMember
{
    public int CourseMemberId { get; set; }

    public int MemberId { get; set; }

    public int CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;
}
