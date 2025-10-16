namespace NewReestrAsp.Dtos;

public class EmployeeDto
{
    public int id { get; set; }
    public string surname { get; set; } = null!;
    public string name { get; set; } = null!;
    public string patronymic { get; set; } = null!;
    public string birth_date { get; set; } = null!;
    public string gender { get; set; } = null!;
    public string post { get; set; } = null!;
    public string? start_work_date { get; set; }
    public string? temp { get; set; }
    public string number_phone_division { get; set; } = null!;
    public string addres { get; set; } = null!;
    public string mobile_number { get; set; } = null!;

    public int? id_unit { get; set; }

    // Список образований
    public List<EmployeeEducationDto> educations { get; set; } = new();
    public List<string> unit_names { get; set; } = new();
}
public class EmployeeCreateDto
{
    public int id { get; set; }
    public string surname { get; set; } = null!;
    public string name { get; set; } = null!;
    public string patronymic { get; set; } = null!;
    public string birth_date { get; set; } = null!;
    public string gender { get; set; } = null!;
    public string post { get; set; } = null!;
    public string? start_work_date { get; set; }
    public string? temp { get; set; }
    public string number_phone_division { get; set; } = null!;
    public string addres { get; set; } = null!;
    public string mobile_number { get; set; } = null!;

    public int? id_unit { get; set; }
}

public class EmployeeUpdateDto
{
    public int? id { get; set; }
    public string? surname { get; set; }
    public string? name { get; set; }
    public string? patronymic { get; set; }
    public string? birth_date { get; set; }
    public string? gender { get; set; }
    public string? post { get; set; }
    public string? start_work_date { get; set; }
    public string? temp { get; set; }
    public string? number_phone_division { get; set; }
    public string? addres { get; set; }
    public string? mobile_number { get; set; }

    public int? id_unit { get; set; }
}