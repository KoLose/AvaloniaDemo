using System;
using System.Collections.Generic;

namespace AvaloniaApp.Data;

public partial class Request
{
    public long Id { get; set; }

    public int? SerialNumber { get; set; }

    public string? Description { get; set; }
}
