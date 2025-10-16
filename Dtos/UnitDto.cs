namespace NewReestrAsp.Dtos;

public class UnitDto
{
    public int id { get; set; }

    public string? unit_name { get; set; }

    public string? path { get; set; }

    public int? self_employees { get; set; }
    public int? total_employees { get; set; }

    public List<EmployeeDto> employees { get; set; } = new();
    public List<UnitDto> children { get; set; } = new();
}
public class UnitModalDto
{
    public int id { get; set; }
    public string? unit_name { get; set; }
    public string? path { get; set; }
    public int? is_active { get; set; }
    public List<UnitModalDto> children { get; set; } = new();
}