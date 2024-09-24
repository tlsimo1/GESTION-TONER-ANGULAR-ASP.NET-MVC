using System;
using System.Collections.Generic;

namespace webapi.Repos.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Utilisateur { get; set; }

    public string? Departement { get; set; }

    public string? ReferenceToner { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }
}
