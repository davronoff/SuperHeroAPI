using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHero.Data;
using SuperHero.Models;

namespace SuperHero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContaxt _data;

        public SuperHeroController(DataContaxt data)
        {
            _data = data;
        }
        [HttpGet]
        public async Task<ActionResult<List<MarvelHero>>> Get()
        {
            return Ok( await _data.marvelHeroes.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<MarvelHero>>> Add(MarvelHero hero)
        {
            _data.marvelHeroes.Add(hero);
            await _data.SaveChangesAsync();
            return Ok(_data.marvelHeroes.ToListAsync());   
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MarvelHero>> Get(int id)
        {
            var hero = _data.marvelHeroes.FindAsync(id);
            if(hero == null)
            {
                return BadRequest("Not Found!");
            }
            return Ok(hero);
        }
        [HttpPut]
        public async Task<ActionResult<List<MarvelHero>>> UpdateHero(MarvelHero hero)
        {
            var dbHero = await _data.marvelHeroes.FindAsync(hero.Id);
            if(dbHero == null)
            {
                return BadRequest("Not Found!");
            }
            dbHero.Name = hero.Name;
            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;
            dbHero.Place = hero.Place;

            await _data.SaveChangesAsync();

            return Ok(dbHero);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarvelHero>> Delete(int id)
        {
            var dbHero = await _data.marvelHeroes.FindAsync(id);
            if (dbHero == null)
            {
                return BadRequest("Not Found!");
            }
            heros.Remove(dbHero);
            return Ok(heros);
        }
    }
}
