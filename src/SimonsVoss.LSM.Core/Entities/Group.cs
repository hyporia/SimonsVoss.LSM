namespace SimonsVoss.LSM.Core.Entities;

public class Group : BaseEntity
{
    public Group()
    {
        Media = new HashSet<Medium>();
    }
    public string? Name { get; set; }

    #region navigation properties

    public ICollection<Medium> Media { get; set; }

    #endregion
}