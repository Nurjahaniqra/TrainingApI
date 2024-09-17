using AutoMapper;
using T1.Models.Domain;
using T1.Models.Dto;

namespace T1.Configuration
{
	public class MapperProfile:Profile
	{
        public MapperProfile()
        {
            //===============================Author==========================
            CreateMap<CreateAuthorDto,Author>().ReverseMap();
            CreateMap<AuthorDto, Author>().ReverseMap();

            //==============================Publisher===========================
            CreateMap<CreatePublisherDto, Publisher>().ReverseMap();
            CreateMap<PublisherDto, Publisher>().ReverseMap();

			//==============================Book===========================
			CreateMap<CreateBookDto, Book>().ReverseMap();
			CreateMap<BookDto, Book>().ReverseMap();

		}
    }
}
