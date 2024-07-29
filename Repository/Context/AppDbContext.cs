using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<User>? Users { get; set; }
    public DbSet<Client>? Clients { get; set; }
    public DbSet<Account>? Accounts { get; set; }
}