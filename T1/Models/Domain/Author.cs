using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace T1.Models.Domain
{
	public class Author:BaseModel
	{
        public required string Name { get; set; }
        public string? ContactNo { get; set; }

		[ValidateNever]
		public  List<Book>? Books { get; set; }
	}
}
