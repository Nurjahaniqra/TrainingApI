using T1.Models.Domain;

namespace T1.Repositories.IRepositories
{
	public interface IUnitOfWork:IDisposable
	{
		IGenericRepository<Author> Authors { get; }
		IGenericRepository<Publisher> Publishers { get; }
		IGenericRepository<Book> Books { get; }
		Task SaveAsync();
	}
}
