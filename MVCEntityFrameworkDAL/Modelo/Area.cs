using System;
using System.Collections.Generic;

namespace MVCEntityFrameworkDAL.Modelo;

public partial class Area
{
    public int Id { get; set; }

    public string Area1 { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; } = new List<Empleado>();
}
