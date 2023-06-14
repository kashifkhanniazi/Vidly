using AutoMapper;
using Vidly.Dtos;
using Vidly.Models.DbModels;
namespace Vidly.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // domain to Dto
            CreateMap<MembershipType, MembershipTypeDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<Movie, MovieDto>();
            
            //Dto to domain
            CreateMap<CustomerDto, Customer>();
            CreateMap<MovieDto, Movie>();
        }
    }
}
