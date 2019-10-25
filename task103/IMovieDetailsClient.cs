using System.Threading.Tasks;
using MovieFinder.Models;

namespace MovieFinder
{
    public interface IMovieDetailsClient
    {
        Task<MovieDetailModel> GetMovieDetailsAsync(string movieName);
    }
}