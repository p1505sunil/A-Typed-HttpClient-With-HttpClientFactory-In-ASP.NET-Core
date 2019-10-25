using System;
using System.Net.Http;
using System.Threading.Tasks;
using MovieFinder.Models;
using Newtonsoft.Json.Linq;

namespace MovieFinder
{
    public class MovieDetailsClient : IMovieDetailsClient
    {
        private readonly HttpClient _httpClient;
        private readonly OmdbApiConfiguration _apiConfiguration;

        public MovieDetailsClient(HttpClient httpClient, OmdbApiConfiguration apiConfiguration)
        {
            _apiConfiguration = apiConfiguration;
            httpClient.BaseAddress = new Uri(_apiConfiguration.Url);
            _httpClient = httpClient;
        }

        public async Task<MovieDetailModel> GetMovieDetailsAsync(string movieName)
        {
            var queryString = $"?t={movieName}&apikey={_apiConfiguration.Key}";
            var response = await _httpClient.GetStringAsync(queryString);

            JObject json = JObject.Parse(response);

            if (json.SelectToken("Response").Value<string>() == "True")
            {

                var movieDetails = new MovieDetailModel
                {
                    Title = json.SelectToken("Title").Value<string>(),
                    Year = json.SelectToken("Year").Value<string>(),
                    Director = json.SelectToken("Director").Value<string>(),
                    Actors = json.SelectToken("Actors").Value<string>(),
                    IMDBRating = json.SelectToken("imdbRating").Value<string>(),
                    PosterImage = json.SelectToken("Poster").Value<string>(),
                    Plot = json.SelectToken("Plot").Value<string>()
                };

                return movieDetails;
            }

            return new MovieDetailModel
            {
                Title = movieName
            };
        }
    }
}