using Microsoft.AspNetCore.Mvc;
using PelisSocios.Models;

namespace PelisSocios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {

        public static List<Pelicula> peliculas = new List<Pelicula> {
                    new Pelicula
                    {
                        Id = 1,
                        Descripcion = "El Conjuro",
                        Genero = "Terror",
                        Duracion = 160
                    },
                    new Pelicula
                    {
                        Id = 2,
                        Descripcion = "King Kong",
                        Genero = "Aventura",
                        Duracion = 180
                    }
                };

        // GET : api/peliculas
        [HttpGet]
            public IActionResult GetAllPeliculas()
            {
                return Ok(peliculas);
            }

        // GET : api/peliculas/{id}
        [HttpGet("{id}")]
        public IActionResult GetPeliculaById(int id) 
        {
            var pelicula = peliculas.Find(x => x.Id == id);
            if (pelicula == null)
                return NotFound("Lo siento, esta película no existe.");
            {
                
            }
            return Ok(pelicula);
        }

        // POST : api/peliculas
        [HttpPost]
        public IActionResult AddPelicula(Pelicula pelicula)
        {
            peliculas.Add(pelicula);
            return Ok(peliculas);
        }

        // PUT : api/peliculas/{id}
        [HttpPut("{id}")]
        public IActionResult UpdatePelicula(int id, Pelicula request)
        {
            var pelicula = peliculas.Find(x => x.Id == id);
            if (pelicula == null)
                return NotFound("Lo siento, esta película no existe.");
            
            pelicula.Descripcion = request.Descripcion;
            pelicula.Genero = request.Genero;
            pelicula.Duracion = request.Duracion;

            return Ok(pelicula);
        }

        // DELETE : api/peliculas/{id}
        [HttpDelete("{id}")]
        public IActionResult DeletePelicula(int id)
        {
            var pelicula = peliculas.Find(x => x.Id == id);
            if (pelicula == null)
                return NotFound("Lo siento, pero esta película no existe.");

            peliculas.Remove(pelicula);
            return Ok(peliculas);
        }
    }
    
    
}
