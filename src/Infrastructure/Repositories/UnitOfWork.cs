using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly Dictionary<string, object> _repositories = new();

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            var typeName = typeof(T).Name;
            if (!_repositories.ContainsKey(typeName))
            {
                var repositoryInstance = new GenericRepository<T>(_context);
                _repositories.Add(typeName, repositoryInstance);
            }
            return (IGenericRepository<T>)_repositories[typeName];
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}