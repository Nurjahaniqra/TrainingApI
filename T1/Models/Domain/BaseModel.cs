using System.ComponentModel.DataAnnotations;

namespace T1.Models.Domain
{
	public class BaseModel
	{
		[Key]
		[MaxLength(50)]
		public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
