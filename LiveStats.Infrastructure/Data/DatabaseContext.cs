using LiveStats.Infrastructure.Data.Models.Football;
using LiveStats.Infrastructure.Data.Models.Identity;
using LiveStats.Infrastructure.Data.Models.Shared;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LiveStats.Infrastructure.Data;

public class DatabaseContext : IdentityDbContext<ApplicationUser>
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public DbSet<Sh_Nationality> Sh_Nationalities { get; set; }

    public DbSet<Fb_CompetitionTeam> Fb_CompetitionsTeams { get; set; }
    public DbSet<Fb_Competition> Fb_Competitions { get; set; }
    public DbSet<Fb_Match> Fb_Matches { get; set; }
    public DbSet<Fb_Player> Fb_Players { get; set; }
    public DbSet<Fb_Position> Fb_Positions { get; set; }
    public DbSet<Fb_PositionType> Fb_PositionTypes { get; set; }
    public DbSet<Fb_Stadium> Fb_Stadiums { get; set; }
    public DbSet<Fb_Team> Fb_Teams { get; set; }
    public DbSet<Fb_UserMatch> Fb_UsersMatches { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Fb_CompetitionTeam>()
            .HasOne(ct => ct.Team)
            .WithMany(t => t.CompetitionTeams)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Fb_Match>()
            .HasOne(m => m.AwayTeam)
            .WithMany(t => t.AwayMatches)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Fb_Match>()
            .HasOne(m => m.HomeTeam)
            .WithMany(t => t.HomeMatches)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Fb_Player>()
            .HasOne(p => p.Nationality)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
    }
}
