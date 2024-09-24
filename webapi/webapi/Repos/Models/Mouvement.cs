using System;
using System.Collections.Generic;

namespace webapi.Repos.Models;

public partial class Mouvement
{
    public string? Reference { get; set; }

    public int? Entree { get; set; }

    public int? Sortie { get; set; }

    public DateTime? Date { get; set; }

    public int IdMouvement { get; set; }
}
