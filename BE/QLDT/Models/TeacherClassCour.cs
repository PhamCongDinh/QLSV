using System;
using System.Collections.Generic;

namespace QLDT.Models;

public partial class TeacherClassCour
{
    public string IdTeacher { get; set; } = null!;

    public int IdClass { get; set; }

    public string IdCour { get; set; } = null!;

    public virtual Class IdClassNavigation { get; set; } = null!;

    public virtual Course IdCourNavigation { get; set; } = null!;

    public virtual Teacher IdTeacherNavigation { get; set; } = null!;
}
