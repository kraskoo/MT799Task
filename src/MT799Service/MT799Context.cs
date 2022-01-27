namespace MT799Service;

using Microsoft.EntityFrameworkCore;
using MT799Service.Models;

public class MT799Context : DbContext
{
    public MT799Context()
    {
    }

    public MT799Context(DbContextOptions<MT799Context> options) : base(options)
    {
    }

    public DbSet<Message> Messages { get; set; } = default!;
}