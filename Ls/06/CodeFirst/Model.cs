using Microsoft.EntityFrameworkCore;

public class BankContext : DbContext
{
  public DbSet<Person> Persons { get; set; }
  public DbSet<Account> Accounts { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    var folder = Environment.CurrentDirectory;
    var path = Path.Join(folder, "BankCf.db");
    optionsBuilder.UseSqlite($"Data Source={path}");
  }
}

public class Person
{
  public int PersonId { get; set; }
  public string? Name { get; set; }

  public List<Account> Accounts { get; } = [];
}

public class Account
{
  public int Id { get; set; }
  public int Number { get; set; }
  public double Balance { get; set; }
  public bool Active { get; set; }

  public int PersonId { get; set; }
  public Person? Person { get; set; }
}