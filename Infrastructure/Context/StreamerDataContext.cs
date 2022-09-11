using Domain.Entities;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class StreamerDataContext
    : DbContext
{
    public StreamerDataContext(DbContextOptions<StreamerDataContext> options)
        : base(options) 
    { }

    public DbSet<StreamerData> StreamerData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StreamerDataConfiguration());
    }
}
