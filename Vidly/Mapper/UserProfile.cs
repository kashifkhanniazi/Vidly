using AutoMapper;
using Vidly.Dtos;
using Vidly.Models.DbModels;
namespace Vidly.Mapper
{
    public class UserProfile : 
Profile
    {
        public UserProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();
            
        }
    }
}
