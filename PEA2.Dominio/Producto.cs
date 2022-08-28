using System;
using System.Collections.Generic;
using System.Text;

namespace PEA2.Dominio
{
    public class Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public int IdCategoria { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
