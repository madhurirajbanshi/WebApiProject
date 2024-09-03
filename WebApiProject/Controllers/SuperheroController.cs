//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Mvc;
//using System.ComponentModel;

//namespace WebApiProject.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SuperheroController : ControllerBase
//    {
//        private static List<Superhero> heroes= new List<Superhero> { 





//             new Superhero { Id = 1,
//                 Name = "Spider Man",
//                 FirstName = "Peter",
//                 LastName="Parker",
//                 Place = "New York City"
//                          },
//             new Superhero
//             {
//                 Id=2,
//                 Name="IronMan",
//                 FirstName="Tony",
//                 LastName="Stark",
//                 Place="Long Island"


//            }
//             };
//            [HttpGet]
//            public async Task<ActionResult<List<Superhero>>> Get()
//            {


//                return Ok(heroes);
//            }
//    };
//    [HttpGet("{id}")]
//    public async Task<ActionResult<Superhero>> Get(int id)
//    {
//        var hero = heroes.Find(h => h.Id == id);
//        if (hero == null)
//            return BadRequest("Hero not found");


//        return Ok(hero);
//    }

//    [HttpPost]
//        public async Task<ActionResult<List<Superhero>>> AddHero(Superhero hero)
//        {
//            heroes.Add(hero);
//            return Ok(heroes);
//        }
//    }




using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroController : ControllerBase
    {
        private static List<Superhero> heroes = new List<Superhero>
        {
            new Superhero
            {
                Id = 1,
                Name = "Spider Man",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New York City"
            },
            new Superhero
            {
                Id = 2,
                Name = "IronMan",
                FirstName = "Tony",
                LastName = "Stark",
                Place = "Long Island"
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<Superhero>>> Get()
        {
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Superhero>> Get(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Hero not found");

            return Ok(hero); // Return the specific hero instead of the entire list
        }

        [HttpPost("add")]
        public async Task<ActionResult<List<Superhero>>> AddHero(Superhero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut("update")]
        public async Task<ActionResult<List<Superhero>>> UpdateHero(Superhero updatedHero)
        {
            var hero = heroes.Find(h => h.Id == updatedHero.Id);
            if (hero == null)
                return BadRequest("Hero not found");

            hero.Name = updatedHero.Name;
            hero.FirstName = updatedHero.FirstName;
            hero.LastName = updatedHero.LastName;
            hero.Place = updatedHero.Place;

            return Ok(heroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Superhero>>> DeleteHero(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Hero not found");

            heroes.Remove(hero);

            return Ok(heroes);
        }
    }
}

