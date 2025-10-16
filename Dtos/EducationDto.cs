namespace NewReestrAsp.Dtos;

public class EmployeeEducationDto
{
    public int id { get; set; }
    public int id_employee { get; set; }
    public string education { get; set; } = null!;
    public string type_education { get; set; } = null!;
    public string educational_institution { get; set; } = null!;
    public string profession { get; set; } = null!;
    public string type_profession { get; set; } = null!;
}

public class EmployeeEducationCreateDto
{
    public int id { get; set; }
    public int id_employee { get; set; }
    public string education { get; set; } = null!;
    public string type_education { get; set; } = null!;
    public string educational_institution { get; set; } = null!;
    public string profession { get; set; } = null!;
    public string type_profession { get; set; } = null!;
}

public class EmployeeEducationUpdateDto
{
    public int id { get; set; }
    public int id_employee { get; }
    public string? education { get; set; }
    public string? type_education { get; set; }
    public string? educational_institution { get; set; }
    public string? profession { get; set; }
    public string? type_profession { get; set; }
}