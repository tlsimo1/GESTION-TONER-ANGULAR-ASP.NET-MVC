using System;
using System.Collections.Generic;

namespace webapi.Repos.Models;

public partial class EtatStock
{
    public int IdEtat { get; set; }

    public string ReferenceId { get; set; } = null!;

    public int? SommeEntree { get; set; }

    public int? SommeSortie { get; set; }

    public int? StockFinal { get; set; }
}
