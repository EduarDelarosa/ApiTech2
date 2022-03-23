using System;
using System.Collections.Generic;

namespace APIVentas.Models
{
    public partial class Concepto
    {
        public long Id { get; set; }
        public long FkIdVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }
        public long FkIdProducto { get; set; }

        public virtual Producto FkIdProductoNavigation { get; set; } = null!;
        public virtual Ventum FkIdVentaNavigation { get; set; } = null!;
    }
}
