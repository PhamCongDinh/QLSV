using System;
using System.Collections.Generic;

namespace QLDT.Models;

public partial class Term
{
    public int Id { get; set; }

    public string TermName { get; set; } = null!;

    public int Semester { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
