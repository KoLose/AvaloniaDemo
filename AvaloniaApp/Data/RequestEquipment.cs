using System;
using System.Collections.Generic;

namespace AvaloniaApp.Data;

public partial class RequestEquipment
{
    public string Id { get; set; } = null!;

    public long? Reqid { get; set; }

    public long? Eqid { get; set; }
}
