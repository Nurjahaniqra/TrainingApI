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
	public class PublisherController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public PublisherController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<List<PublisherDto>>> Get()
		{
			var model = await _unitOfWork.Publishers.GetAllAsync();
			if (model == null)
			{
				return NotFound();
			}
			return Ok(model);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> Get(string id)
		{
			var model = await _unitOfWork.Publishers.GetAsync(x => x.Id == id);
			if (model == null)
			{
				return NotFound();
			}
			return Ok(model);
		}

		[HttpPost]
		public async Task<ActionResult> Create(CreatePublisherDto model)
		{
			var mapper = _mapper.Map<Publisher>(model);
			await _unitOfWork.Publishers.CreateAsync(mapper);
			await _unitOfWork.SaveAsync();
			return Ok("Data Save Successfully!");

		}

		[HttpPut]
		public async Task<ActionResult> Update(PublisherDto model)
		{
			var mapper = _mapper.Map<Publisher>(model);
			 _unitOfWork.Publishers.UpdateAsync(mapper);
			await _unitOfWork.SaveAsync();
			return Ok("Data Updated Successfully!");

		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(string id)
		{
			var model = await _unitOfWork.Publishers.GetAsync(x => x.Id == id);
			if (model == null)
			{
				return NotFound();
			}
			_unitOfWork.Publishers.DeleteAsync(model);
			await _unitOfWork.SaveAsync();
			return Ok("Data Updated Successfully!");

		}
	}
}
