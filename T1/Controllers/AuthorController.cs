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
	public class AuthorController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public AuthorController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<List<AuthorDto>>> Get()
		{
			var model = await _unitOfWork.Authors.GetAllAsync();
			if (model == null)
			{
				return NotFound();
			}
			return Ok(model);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> Get(string id)
		{
			var model = await _unitOfWork.Authors.GetAsync(x => x.Id == id);
			if (model == null)
			{
				return NotFound();
			}
			return Ok(model);
		}

		[HttpPost]
		public async Task<ActionResult> Create(CreateAuthorDto model)
		{
			var mapper = _mapper.Map<Author>(model);
			await _unitOfWork.Authors.CreateAsync(mapper);
			await _unitOfWork.SaveAsync();
			return Ok("Data Save Successfully!");
		}

		[HttpPut]
		public async Task<ActionResult> Update(AuthorDto model)
		{
			var mapper = _mapper.Map<Author>(model);

			_unitOfWork.Authors.UpdateAsync(mapper);
			await _unitOfWork.SaveAsync();
			return Ok("Data Updated Successfully!");

		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(string id)
		{
			var model = await _unitOfWork.Authors.GetAsync(x => x.Id == id);
			if (model == null)
			{
				return NotFound();
			}
			_unitOfWork.Authors.DeleteAsync(model);
			await _unitOfWork.SaveAsync();
			return Ok("Data Updated Successfully!");

		}
	}
}
