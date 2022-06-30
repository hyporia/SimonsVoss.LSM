namespace SimonsVoss.LSM.Core.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }

    public string? Description { get; set; }
}