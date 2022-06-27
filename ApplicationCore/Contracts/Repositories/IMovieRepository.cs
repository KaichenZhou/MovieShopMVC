﻿using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repository
{
    public interface IMovieRepository : IRepository<Movie>
    {
         Task <IEnumerable<Movie>> Get30HighestGrossingMovies();
         Task <IEnumerable<Movie>> Get30HighestRatedoMovies();
        //IEnumerable<Movie> Get30HighestGrossingMovies();
        //IEnumerable<Movie> Get30HighestRatedoMovies();
        Task<PagedResultSetModel<Movie>> GetMoviesByGenre(int genreId, int pageSize = 30, int pageNumber = 1);
    }


}

