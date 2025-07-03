using System;
using System.Collections.Generic;

namespace ProyectoDePruebaMVC.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string CurrentPassword { get; set; } = null!;
}
