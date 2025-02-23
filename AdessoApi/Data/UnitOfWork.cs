using AdessoApi.Entities;

namespace AdessoApi.Data
{
    // TODO IUnitOfWork should be seperated as different file.
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<Team> Teams { get; }
        GenericRepository<Group> Groups { get; }
        GenericRepository<Country> Countries { get; }

        Task<int> SaveChangesAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public GenericRepository<Team> Teams { get; }
        public GenericRepository<Group> Groups { get; }
        public GenericRepository<Country> Countries { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Teams = new GenericRepository<Team>(context);
            Groups = new GenericRepository<Group>(context);
            Countries = new GenericRepository<Country>(context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
