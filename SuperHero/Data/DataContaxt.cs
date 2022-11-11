using Microsoft.EntityFrameworkCore;
using SuperHero.Models;

namespace SuperHero.Data
{
    public class DataContaxt : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DataContaxt(DbContextOptions<DataContaxt> options) : base(options) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DbSet<MarvelHero> marvelHeroes { get; set; }
    }
}
