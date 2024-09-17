using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace T1.Models.Domain
{
	public class Book:BaseModel
	{
        public required string Title { get; set; }

		public string? Description { get; set; }

		public string AuthorId { get; set; }
		[ValidateNever]
		public Author? Authors { get; set; }

		public string PublisherId { get; set; }
		[ValidateNever]
		public Publisher? Publishers { get; set; }
	}
}
