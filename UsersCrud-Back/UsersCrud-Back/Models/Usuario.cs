using System;
using System.Collections.Generic;

namespace UsersCrud_Back.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FechaNacimiento { get; set; } = null!;

    public int? Telefono { get; set; }

    public string IdPaisResidencia { get; set; } = null!;

    public byte RecibirInformación { get; set; }

    public virtual ICollection<Actividade> Actividades { get; } = new List<Actividade>();

    public virtual Paise IdPaisResidenciaNavigation { get; set; } = null!;
}
