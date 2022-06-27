namespace SimonsVoss.LSM.Core.Entities.Dictionaries;

public class MediumType : BaseDictionaryEntity
{
    public MediumType()
    {
        Media = new HashSet<Medium>();
    }
    
    #region navigation properties

    public ICollection<Medium> Media { get; set; }

    #endregion
}