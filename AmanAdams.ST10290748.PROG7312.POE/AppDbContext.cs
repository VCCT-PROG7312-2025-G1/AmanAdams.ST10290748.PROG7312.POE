using AmanAdams.ST10290748.PROG7312.POE.Models;
using Microsoft.EntityFrameworkCore;

// Aman Adams
// ST10290748
// PROG7312
// POE PART 3 

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Event> Events { get; set; }
    public DbSet<IssueModel> Issues { get; set; }

}

//-------------------------------------------------------------END OF FILE-----------------------------------------------------------------//
