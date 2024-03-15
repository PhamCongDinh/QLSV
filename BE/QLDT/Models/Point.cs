using System;
using System.Collections.Generic;

namespace QLDT.Models;

public partial class Point
{
    public string IdStu { get; set; } = null!;

    public string IdCour { get; set; } = null!;

    public double? PointProcess { get; set; }

    public double? PointTest { get; set; }

    public int Number { get; set; }

    public virtual Course? IdCourNavigation { get; set; }

    public virtual Student? IdStuNavigation { get; set; }
}
