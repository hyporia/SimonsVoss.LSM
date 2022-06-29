namespace SimonsVoss.LSM.Core.Entities;

public class SearchingWeight
{
    public SearchingWeight(int id, string entityName, string propertyName, int weight,
        string? transitiveEntityName = null, int fullMatchMultiplier = 10)
    {
        if (string.IsNullOrEmpty(entityName)) throw new ArgumentNullException(nameof(entityName));
        if (string.IsNullOrEmpty(propertyName)) throw new ArgumentNullException(nameof(propertyName));
        if (weight == 0) throw new ArgumentException(nameof(weight));
        Id = id;
        EntityName = entityName;
        PropertyName = propertyName;
        TransitiveEntityName = transitiveEntityName;
        Weight = weight;
        FullMatchMultiplier = fullMatchMultiplier;
    }

    public int Id { get; set; }

    public string EntityName { get; set; }

    public string PropertyName { get; set; }

    public string? TransitiveEntityName { get; set; }

    public int Weight { get; set; }

    public int FullMatchMultiplier { get; set; }
}