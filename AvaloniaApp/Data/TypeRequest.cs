using System;
using System.Collections.Generic;

namespace AvaloniaApp.Data;

public partial class TypeRequest
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
