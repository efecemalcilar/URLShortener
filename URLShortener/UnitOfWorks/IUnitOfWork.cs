namespace URLShortener.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
