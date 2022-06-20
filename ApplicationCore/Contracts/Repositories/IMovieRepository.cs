using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repository
{
    public interface IMovieRepository :IRepository <Movie>
    {
        //some common methods
        //GetById(int id);
        IEnumerable<Movie> Get30HighestGrossingMovies();
        IEnumerable<Movie> Get30HighestRatedoMovies();


    }
}
