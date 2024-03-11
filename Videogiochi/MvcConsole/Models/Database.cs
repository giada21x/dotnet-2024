
using Microsoft.EntityFrameworkCore;

public class Database : DbContext
{
    public DbSet<Utente> Utenti { get; set; }
    public DbSet<Videogioco> Videogiochi { get; set; }
    public DbSet<Valutazione> Valutazioni { get; set; }
    public DbSet<Genere> Generi { get; set; }
    public DbSet<Platform> Platforms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=MyDatabase.sqlite");
    
    }
    
    
    
}
    

