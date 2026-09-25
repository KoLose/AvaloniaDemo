using System;
using System.Collections.Generic;

namespace AvaloniaApp.Data;

public partial class User
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Login { get; set; }

    public string? Passowrd { get; set; }

    public long? Roleid { get; set; }

    public virtual ICollection<Request> RequestClients { get; set; } = new List<Request>();

    public virtual ICollection<Request> RequestMechas { get; set; } = new List<Request>();

    public virtual Role? Role { get; set; }
}
