using System.ComponentModel.DataAnnotations;

namespace T1.Models.Dto
{
	public class PublisherDto: CreatePublisherDto
	{
		[MaxLength(50)]
		public string Id { get; set; }
	}
	public class CreatePublisherDto
	{
		public required string Name { get; set; }
		public string CoontactNo { get; set; }
		public string Web { get; set; }
	}
}
