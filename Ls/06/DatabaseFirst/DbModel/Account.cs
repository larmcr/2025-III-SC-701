using System;
using System.Collections.Generic;

namespace DatabaseFirst.DbModel;

public partial class Account
{
    public int Id { get; set; }

    public int Number { get; set; }

    public double Balance { get; set; }

    public int PersonId { get; set; }

    public int Active { get; set; }

    public virtual Person Person { get; set; } = null!;
}
