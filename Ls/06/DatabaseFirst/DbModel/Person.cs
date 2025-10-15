using System;
using System.Collections.Generic;

namespace DatabaseFirst.DbModel;

public partial class Person
{
    public int PersonId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
