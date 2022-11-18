using System;
using System.Collections.Generic;

namespace MVCEntityFrameworkDAL.Modelo;

public partial class Empleado
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int? IdArea { get; set; }

    public virtual Area? IdAreaNavigation { get; set; }
}
