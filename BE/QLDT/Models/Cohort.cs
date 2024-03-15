using System;
using System.Collections.Generic;

namespace QLDT.Models;

public partial class Cohort
{
    public int Id { get; set; }

    public string Abbreviations { get; set; } = null!;

    public string CohortName { get; set; } = null!;

    public int IdDep { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Department IdDepNavigation { get; set; } = null!;
}
