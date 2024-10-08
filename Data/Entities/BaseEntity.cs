namespace Data.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }

    public string? Marca { get; set; }
}