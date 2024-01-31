using System;
using System.Collections.Generic;
using System.Text;

namespace Appcompras.Modelo
{
   public class Mdetallecompras
    {
        public string Cantidad { get; set; }
        public string Preciocompra { get; set; }
        public string Idproducto { get; set; }
        public string Total { get; set; }
        public string Iddetallecompra { get; set; }

        //
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
    }
}
