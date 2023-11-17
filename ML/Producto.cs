﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Producto
    {
        public int? IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public ML.Categorias Categorias { get; set; }

        public List<object>? Productoss { get; set; }
    }
}

