using Microsoft.EntityFrameworkCore;
using T1.Data;
using T1.Models.Domain;
using T1.Repositories.IRepositories;

namespace T1.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private ApplicationDbContext _context;
		private GenericRepository<Author> _Authors;
		private GenericRepository<Publisher> _Publishers;
		private GenericRepository<Book> _Books;
		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
		}
		public IGenericRepository<Author> Authors => _Authors ??= new GenericRepository<Author>(_context);
		public IGenericRepository<Publisher> Publishers => _Publishers ??= new GenericRepository<Publisher>(_context);
		public IGenericRepository<Book> Books => _Books ??= new GenericRepository<Book>(_context);

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		private void Dispose(bool dispose)
		{
			if (dispose)
			{
				_context.Dispose();
			}
		}
		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
