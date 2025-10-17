namespace NewReestrAsp.Dtos;

public class EmployeeArchiveDto
{
    public int id { get; set; }
    public string surname { get; set; } = null!;
    public string name { get; set; } = null!;
    public string? patronymic { get; set; }
    public string birth_date { get; set; } = null!;
    public string gender { get; set; } = null!;
    public string? departament { get; set; }
    public string? post { get; set; }
    public string? division { get; set; }
    public string? start_work_date { get; set; }
    public string? temp { get; set; }
    public string? number_phone_division { get; set; }
    public string? addres { get; set; }
    public string? mobile_number { get; set; }

    // Список образований
    public List<EmployeeEducationDto> educations { get; set; } = new();
}

public class EmployeeArchiveUpdateDto
{
    public int id { get; }
    public string? surname { get; set; }
    public string? name { get; set; }
    public string? patronymic { get; set; }
    public string? birth_date { get; set; }
    public string? gender { get; set; }
    public string? departament { get; set; }
    public string? post { get; set; }
    public string? division { get; set; }
    public string? start_work_date { get; set; }
    public string? temp { get; set; }
    public string? number_phone_division { get; set; }
    public string? addres { get; set; }
    public string? mobile_number { get; set; }

}