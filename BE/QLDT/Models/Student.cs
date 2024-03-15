using System;
using System.Collections.Generic;

namespace QLDT.Models;

public partial class Student
{
    public string Id { get; set; } = null!;

    public int IdClass { get; set; }

    public virtual Class IdClassNavigation { get; set; } = null!;

    public virtual Account IdNavigation { get; set; } = null!;

    public virtual ICollection<Point> Points { get; set; } = new List<Point>();
}
