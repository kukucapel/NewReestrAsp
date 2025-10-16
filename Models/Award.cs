using System;
using System.Collections.Generic;

namespace NewReestrAsp.Models;

public partial class Award
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Period { get; set; }

    public string? Fio { get; set; }

    public string? Organization { get; set; }

    public string? Text { get; set; }

    public string? RegistrationNumber { get; set; }

    public string? ReceiptDate { get; set; }

    public string? OrderNumber { get; set; }

    public string? OrderDate { get; set; }

    public string? Attachments { get; set; }

    public virtual ICollection<AwardsDocument> AwardsDocuments { get; set; } = new List<AwardsDocument>();
}
