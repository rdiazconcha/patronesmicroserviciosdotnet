using Microsoft.EntityFrameworkCore;

namespace Pdm.Person.Api.Infrastructure;

public class PersonDbContext : DbContext
{
    public DbSet<Domain.Entities.Person> People { get; set; }

    public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Domain.Entities.Person>().HasKey(x => x.Id);
        modelBuilder.Entity<Domain.Entities.Person>().OwnsOne(x => x.Name);
    }
}

public static class PersonDbContextExtensions
{
    public static void AddPersonDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PersonDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Person"));
        });
    }
    public static void EnsurePersonDbIsCreated(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetService<PersonDbContext>();
        context.Database.EnsureCreated();
        context.Database.CloseConnection();
    }
}