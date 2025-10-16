using System;
using System.Collections.Generic;

namespace NewReestrAsp.Models;

public partial class GovernmentEmployeesEducationArchive
{
    public int Id { get; set; }

    public int IdEmployee { get; set; }

    public string? Education { get; set; }

    public string? TypeEducation { get; set; }

    public string? EducationalInstitution { get; set; }

    public string? Profession { get; set; }

    public string? TypeProfession { get; set; }

    public virtual GovernmentEmployeesArchive IdEmployeeNavigation { get; set; } = null!;
}
