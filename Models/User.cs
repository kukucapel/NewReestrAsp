using System;
using System.Collections.Generic;

namespace NewReestrAsp.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string HashedPassword { get; set; } = null!;

    public string? UserRole { get; set; }

    public int? IsActive { get; set; }

    public string? NumberPhone { get; set; }

    public int AwardsAccess { get; set; }

    public int EmployeesAccess { get; set; }

    public int UnitAccess { get; set; }

    public int AdminAccess { get; set; }
}
