namespace SimonsVoss.LSM.Core.Entities.Dictionaries;

public class LockType : BaseDictionaryEntity
{
    #region navigation properties

    public LockType()
    {
        Locks = new HashSet<Lock>();
    }

    public ICollection<Lock> Locks { get; set; }

    #endregion
}