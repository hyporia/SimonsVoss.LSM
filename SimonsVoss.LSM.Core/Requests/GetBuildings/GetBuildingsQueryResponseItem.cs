namespace SimonsVoss.LSM.Core.Requests.GetBuildings;

public class GetBuildingsQueryResponseItem
{
    public Guid Id { get; set; }

    public string? Description { get; set; }
    
    public string? ShortCut { get; set; }

    public string? Name { get; set; }
}