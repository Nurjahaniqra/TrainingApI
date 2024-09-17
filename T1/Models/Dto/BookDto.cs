using System.ComponentModel.DataAnnotations;

namespace T1.Models.Dto
{
	public class BookDto: CreateBookDto
	{
		[MaxLength(50)]
		public string Id { get; set; }
	}
	public class CreateBookDto
	{
		public required string Title { get; set; }
		public string? Description { get; set; }
		public string AuthorId { get; set; }
		public string PublisherId { get; set; }
	}
}
