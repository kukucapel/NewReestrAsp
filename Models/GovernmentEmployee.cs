using System;
using System.Collections.Generic;

namespace NewReestrAsp.Models;

public partial class GovernmentEmployee
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string BirthDate { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string? Post { get; set; }

    public string? StartWorkDate { get; set; }

    public string? Temp { get; set; }

    public string? NumberPhoneDivision { get; set; }

    public string? Addres { get; set; }

    public string? MobileNumber { get; set; }

    public int? IdUnit { get; set; }

    public virtual ICollection<GovernmentEmployeesEducation> GovernmentEmployeesEducations { get; set; } = new List<GovernmentEmployeesEducation>();

    public virtual Unit? IdUnitNavigation { get; set; }
}
