using System.Collections.Generic;
using Vidly.Models.DbModels;

namespace Vidly.ViewModels
{
    public class RandomMovieVM
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
