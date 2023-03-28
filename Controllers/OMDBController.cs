using Microsoft.AspNetCore.Mvc;
using Pizzas.API.Models;
using Pizzas.API.Utils;
using Movie.API.Models;
using System.Text.Json;

namespace OMDB.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OMDBController : ControllerBase
    {
        [HttpGet("movieTitulo/{titulo}")]
        public async Task<IActionResult> BuscarPorTitulo([FromQuery] string titulo)   
        {
            //http://localhost:5062/api/OMDB/movieTitulo/search?titulo=toy
            //http://www.omdbapi.com/?apikey=b0a67d38

            string apiResponse = await HTTPHelper.GetContentAsync("http://www.omdbapi.com/?apikey=b0a67d38&s=" + titulo, null);
            return Ok(apiResponse);
        }

        [HttpGet("movieId/{id}")]
        public async Task<IActionResult> BuscarPorID([FromQuery] string id)   
        {
            //http://localhost:5062/api/OMDB/movieId/search?id=tt0084809
            //http://www.omdbapi.com/?apikey=b0a67d38

            string apiResponse = await HTTPHelper.GetContentAsync("http://www.omdbapi.com/?apikey=b0a67d38&i=" + id, null);
            return Ok(apiResponse);
        }
    }
}