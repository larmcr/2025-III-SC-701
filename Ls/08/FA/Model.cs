
using Microsoft.EntityFrameworkCore;

public class PeopleContext : DbContext
{
    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var folder = Environment.CurrentDirectory;
        var path = Path.Join(folder, "PeopleFA.db");
        optionsBuilder.UseSqlite($"Data Source={path}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>((entityPerson) =>
        {
            entityPerson.Property((prop) => prop.PersonId).HasColumnName("Person_Id");
            entityPerson.Property(prop => prop.Name).HasColumnOrder(1);
            entityPerson.Property(prop => prop.Email).IsRequired(true);
            entityPerson.Property(prop => prop.Age).HasColumnType("REAL");
        });

        modelBuilder.Entity<Account>().HasKey("ThisIsTheKey");
        modelBuilder.Entity<Account>()
            .HasOne(prop => prop.Person)
            .WithMany(prop => prop.Accounts)
            .HasForeignKey(prop => prop.PersonId);
    }
}

public class Person
{
    public int PersonId { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public int Age { get; set; }
    public List<Account> Accounts { get; } = [];
}

public class Account
{
    // [Key]
    public int ThisIsTheKey { get; set; }
    public int Number { get; set; }
    public double Balance { get; set; }
    public bool Active { get; set; }

    public int PersonId { get; set; }
    public Person? Person { get; set; }
}