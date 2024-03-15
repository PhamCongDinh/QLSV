using System;
using System.Collections.Generic;

namespace QLDT.Models;

public partial class Account
{
    public string Id { get; set; } = null!;

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public DateOnly? Dateofbirth { get; set; }

    public string? Town { get; set; }

    public string? Images { get; set; }

    public int Role { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
