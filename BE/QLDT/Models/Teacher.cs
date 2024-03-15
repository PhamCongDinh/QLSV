using System;
using System.Collections.Generic;

namespace QLDT.Models;

public partial class Teacher
{
    public string Id { get; set; } = null!;

    public int? IdDep { get; set; }

    public virtual Department? IdDepNavigation { get; set; }

    public virtual Account IdNavigation { get; set; } = null!;

    public virtual ICollection<TeacherClassCour> TeacherClassCours { get; set; } = new List<TeacherClassCour>();
}
