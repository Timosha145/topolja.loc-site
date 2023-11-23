using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using topolja.loc_site.Models;

namespace topolja.loc_site.Data
{
    public class FootballersDbContext : DbContext
    {
        
        public DbSet<Footballer> Footballers { get; set; }
        public DbSet<Team> Teams { get; set; }

        public FootballersDbContext(DbContextOptions<FootballersDbContext> options) : base(options)
        {

        }

        public List<Footballer> GetAllFootballers()
        {
            return Footballers.ToList();
        }

        public void AddFootballer(Footballer footballers)
        {
            Footballers.Add(footballers);
            SaveChanges();
        }

        public Footballer? GetFootballerById(int id)
        {
            return Footballers.Find(id);
        }
    }
}
