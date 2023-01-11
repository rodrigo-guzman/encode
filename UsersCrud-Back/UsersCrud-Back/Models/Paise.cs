using System;
using System.Collections.Generic;

namespace UsersCrud_Back.Models;

public partial class Paise
{
    public string Id { get; set; } = null!;

    public string? Descripción { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
