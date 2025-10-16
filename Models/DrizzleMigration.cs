using System;
using System.Collections.Generic;

namespace NewReestrAsp.Models;

public partial class DrizzleMigration
{
    public int Id { get; set; }

    public string Hash { get; set; } = null!;

    public long? CreatedAt { get; set; }
}
