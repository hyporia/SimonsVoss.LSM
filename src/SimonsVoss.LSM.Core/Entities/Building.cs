namespace SimonsVoss.LSM.Core.Entities;

public class Building : BaseEntity
{
    public Building()
    {
        Locks = new HashSet<Lock>();
    }

    public string? ShortCut { get; set; }

    public string? Name { get; set; }

    #region navigation properties
    
    public ICollection<Lock> Locks { get; set; }

    #endregion
}