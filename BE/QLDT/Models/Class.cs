using System;
using System.Collections.Generic;

namespace QLDT.Models;

public partial class Class
{
    public int Id { get; set; }

    public string Abbreviations { get; set; } = null!;

    public string ClassesName { get; set; } = null!;

    public int IdCoh { get; set; }

    public virtual Cohort IdCohNavigation { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<TeacherClassCour> TeacherClassCours { get; set; } = new List<TeacherClassCour>();
}
