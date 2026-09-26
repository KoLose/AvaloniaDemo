using System;
using System.Collections.Generic;

namespace AvaloniaApp.Data;

public partial class Comment
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public long? Requestid { get; set; }

    public virtual Request? Request { get; set; }
}
