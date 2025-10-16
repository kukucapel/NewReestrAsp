using System;
using System.Collections.Generic;

namespace NewReestrAsp.Models;

public partial class GovernmentEmployeesEducation
{
    public int Id { get; set; }

    public int IdEmployee { get; set; }

    public string? Education { get; set; }

    public string? TypeEducation { get; set; }

    public string? EducationalInstitution { get; set; }

    public string? Profession { get; set; }

    public string? TypeProfession { get; set; }

    public virtual GovernmentEmployee IdEmployeeNavigation { get; set; } = null!;
}
