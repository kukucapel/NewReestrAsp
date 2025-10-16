using System;
using System.Collections.Generic;

namespace NewReestrAsp.Models;

public partial class GovernmentEmployeesArchive
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string? BirthDate { get; set; }

    public string Gender { get; set; } = null!;

    public string? Departament { get; set; }

    public string? Post { get; set; }

    public string? Division { get; set; }

    public string? StartWorkDate { get; set; }

    public string? Temp { get; set; }

    public string? NumberPhoneDivision { get; set; }

    public string? Addres { get; set; }

    public string? MobileNumber { get; set; }

    public virtual ICollection<GovernmentEmployeesEducationArchive> GovernmentEmployeesEducationArchives { get; set; } = new List<GovernmentEmployeesEducationArchive>();
}
