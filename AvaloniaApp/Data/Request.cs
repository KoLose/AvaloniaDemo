using System;
using System.Collections.Generic;

namespace AvaloniaApp.Data;

public partial class Request
{
    public long Id { get; set; }

    public int? SerialNumber { get; set; }

    public string? Description { get; set; }

    public long? Type { get; set; }

    public long? Clientid { get; set; }

    public long? Mechaid { get; set; }

    public long? Stageid { get; set; }

    public virtual User? Client { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Request> InverseStage { get; set; } = new List<Request>();

    public virtual User? Mecha { get; set; }

    public virtual Request? Stage { get; set; }

    public virtual TypeRequest? TypeNavigation { get; set; }
}
