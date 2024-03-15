using System;
using System.Collections.Generic;

namespace QLDT.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Abbreviations { get; set; } = null!;

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<Cohort> Cohorts { get; set; } = new List<Cohort>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
