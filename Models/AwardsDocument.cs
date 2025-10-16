using System;
using System.Collections.Generic;

namespace NewReestrAsp.Models;

public partial class AwardsDocument
{
    public int Id { get; set; }

    public int IdAward { get; set; }

    public string? NameDocument { get; set; }

    public virtual Award IdAwardNavigation { get; set; } = null!;
}
