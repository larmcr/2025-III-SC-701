
using Microsoft.EntityFrameworkCore;

using var db = new BankContext();

Console.WriteLine("Inserting new Person");
db.Add(new Person
{
  Name = "Francisco"
});
await db.SaveChangesAsync();
Console.WriteLine("\t New Person inserted");

Console.WriteLine("\n Getting last Person inserted");
var lastPerson = await db.Persons.OrderBy(p => p.PersonId).LastAsync();

Console.WriteLine("\n Inserting new Account to last Person");
lastPerson.Accounts.Add(new Account
{
  Active = true,
  Number = 456,
  Balance = 0.0,
});
await db.SaveChangesAsync();
Console.WriteLine("\t New Account inserted");

Console.WriteLine("\n Updating last Person");
lastPerson.Name = "Zoila";
db.SaveChanges();
Console.WriteLine("\t Person updated");

Console.WriteLine("\n Querying database");
foreach (var person in db.Persons)
{
  Console.WriteLine($"Id: {person.PersonId} | Name: {person.Name}");
  var accounts = db.Accounts.Where(a => a.PersonId == person.PersonId).OrderBy(a => a.Id).ToList();
  accounts.ForEach(a =>
  {
    Console.WriteLine($"\t Id: {a.Id} | Active: {a.Active} | Balance: {a.Balance} | Account: {a.Number} ");
  });
}

Console.WriteLine("\n Deleting last Person");
db.Remove(lastPerson);
await db.SaveChangesAsync();
Console.WriteLine("\t Person deleted");