using FlixNTix.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlixNTix.Data;


//identity note - don't forget to install identity.entityframeworkcore package before switching things to implement identity

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor_Movie>().HasKey(am => new
        {
            am.ActorId,
            am.MovieId
        });

        modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);
        modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);

        base.OnModelCreating(modelBuilder);
    }

    //tables for database
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor_Movie> Actors_Movies { get; set; }
    public DbSet<Theater> Theaters { get; set; }
    public DbSet<Producer> Producers { get; set; }

    //orders-related tables
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    

}
