namespace Dating.Domain.Entities;

public class BaseEntity
{
    public int Id { get; set; }
    public string CreatedBy { get; set; } = "System";
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public string UpdatedBy { get; set; } = "System";
    public DateTime DateUpdated { get; set; } = DateTime.Now;
    public bool IsActive { get; set; }
}
