using Storage.Models;
using System.Data.Entity;

public class Context : DbContext
{
   public DbSet<Customer> Customer { get; set; }
   public DbSet<Feature> Feature { get; set; }
   public DbSet<Person> Person { get; set; }
   public DbSet<Project> Project { get; set; }
   public DbSet<Task> Task { get; set; }
   public DbSet<Team> Team { get; set; }
}