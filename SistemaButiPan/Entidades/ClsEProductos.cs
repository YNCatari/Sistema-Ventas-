using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaButiPan.Entidades
{
    class ClsEProductos
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public Double Precio { get; set; }
        public string Proveedor {get; set;}
        public decimal Importe { get; set; }
    }
}
