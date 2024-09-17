using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using T1.Models.Domain;
using T1.Models.Dto;
using T1.Repositories.IRepositories;

namespace T1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public BookController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<List<BookDto>>> Get()
		{
			//List<string> includes = ["Authors", "Publishers"];
			var model = await _unitOfWork.Books.GetAllAsync();
			if (model == null)
			{
				return NotFound();
			}
			return Ok(model);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> Get(string id)
		{
			//List<string> includes = ["Author", "Publisher"];

			var model = await _unitOfWork.Books.GetAsync(expression: x => x.Id == id);
			if (model == null)
			{
				return NotFound();
			}
			return Ok(model);
		}

		[HttpPost]
		public async Task<ActionResult> Create(CreateBookDto model)
		{
			var mapper = _mapper.Map<Book>(model);
			await _unitOfWork.Books.CreateAsync(mapper);
			await _unitOfWork.SaveAsync();
			return Ok("Data Save Successfully!");

		}

		[HttpPut]
		public async Task<ActionResult> Update(BookDto model)
		{
			var mapper = _mapper.Map<Book>(model);
			_unitOfWork.Books.UpdateAsync(mapper);
			await _unitOfWork.SaveAsync();
			return Ok("Data Updated Successfully!");

		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(string id)
		{
			var model = await _unitOfWork.Books.GetAsync(x => x.Id == id);
			if (model == null)
			{
				return NotFound();
			}
			_unitOfWork.Books.DeleteAsync(model);
			await _unitOfWork.SaveAsync();
			return Ok("Data Updated Successfully!");

		}
	}
}
