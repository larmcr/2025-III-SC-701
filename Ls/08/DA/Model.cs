
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

public class PeopleContext : DbContext
{
    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var folder = Environment.CurrentDirectory;
        var path = Path.Join(folder, "PeopleDA.db");
        optionsBuilder.UseSqlite($"Data Source={path}");
    }
}

public class Person
{
    [Column("Person_Id")]
    public int PersonId { get; set; }
    
    [Column(Order = 1)]
    public string? Name { get; set; }

    [NotNull]
    public string? Email { get; set; }

    [Column(TypeName = "REAL")]
    public int Age { get; set; }
}