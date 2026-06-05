using Lectures.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lectures.Api.Infrastructure;

public class LecturesDbContext : DbContext
{
    public LecturesDbContext(DbContextOptions<LecturesDbContext> options)
        : base(options)
    {
    }

    public DbSet<Lecture> Lectures => Set<Lecture>();
}