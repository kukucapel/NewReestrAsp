namespace NewReestrAsp.Dtos;

public class AwardDto
{
    public int id { get; set; }
    public string? name { get; set; }
    public string? period { get; set; }
    public string? fio { get; set; }
    public string? organization { get; set; }
    public string? text { get; set; }
    public string? registration_number { get; set; }
    public string? receipt_date { get; set; }
    public string? order_number { get; set; }
    public string? order_date { get; set; }
    public string? attachments { get; set; }
    public List<AwardsDocumentDto> awards_documents { get; set; } = new();
}
public class AwardCreateUpdateDto
{
    public int id { get; set; }
    public string? name { get; set; }
    public string? period { get; set; }
    public string? fio { get; set; }
    public string? organization { get; set; }
    public string? text { get; set; }
    public string? registration_number { get; set; }
    public string? receipt_date { get; set; }
    public string? order_number { get; set; }
    public string? order_date{ get; set; }
    public string? attachments { get; set; }
}