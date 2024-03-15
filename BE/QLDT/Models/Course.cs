using System;
using System.Collections.Generic;

namespace QLDT.Models;

public partial class Course
{
    public string Id { get; set; } = null!;

    public string CourseName { get; set; } = null!;

    public int IdTerm { get; set; }

    public int? IdDep { get; set; }

    public int? IdCoh { get; set; }

    public virtual Cohort? IdCohNavigation { get; set; }

    public virtual Department? IdDepNavigation { get; set; }

    public virtual Term IdTermNavigation { get; set; } = null!;

    public virtual ICollection<Point> Points { get; set; } = new List<Point>();

    public virtual ICollection<TeacherClassCour> TeacherClassCours { get; set; } = new List<TeacherClassCour>();
}
