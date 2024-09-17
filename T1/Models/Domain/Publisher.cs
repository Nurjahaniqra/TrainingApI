using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace T1.Models.Domain
{
	public class Publisher:BaseModel
	{
        public required string Name { get; set; }
        public string CoontactNo { get; set; }
        public string Web { get; set; }

		[ValidateNever]
		public List<Book>? Books { get; set; }
	}
}
