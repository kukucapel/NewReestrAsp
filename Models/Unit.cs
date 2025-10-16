using System;
using System.Collections.Generic;

namespace NewReestrAsp.Models;

public partial class Unit
{
    public int Id { get; set; }

    public string? UnitName { get; set; }

    public string? Path { get; set; }

    public virtual ICollection<GovernmentEmployee> GovernmentEmployees { get; set; } = new List<GovernmentEmployee>();
}
