using System;
using System.Collections.Generic;

namespace webapi.Repos.Models;

public partial class BaseToner
{
    public int IdTonner { get; set; }

    public string Reference { get; set; } = null!;

    public string? Description { get; set; }
}
