using System;
using System.Collections.Generic;

namespace DL;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string Categoria1 { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
