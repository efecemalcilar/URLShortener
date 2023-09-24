namespace URLShortener.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShortenerDbContext _context;

        public UnitOfWork(ShortenerDbContext context)
        {
            _context = context;
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
