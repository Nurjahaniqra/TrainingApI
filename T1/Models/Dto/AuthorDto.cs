using System.ComponentModel.DataAnnotations;

namespace T1.Models.Dto
{
	public class AuthorDto: CreateAuthorDto
	{
		[MaxLength(50)]
		public string Id { get; set; }
	}
	public class CreateAuthorDto
	{
		public string Name { get; set; }
		public string ContactNo { get; set; }
	}
}
