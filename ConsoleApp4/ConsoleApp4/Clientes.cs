//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp4
{
    using System;
    using System.Collections.Generic;
    
    public partial class Clientes
    {
        public Clientes()
        {
            this.Ventas = new HashSet<Ventas>();
        }
    
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string TipoCliente { get; set; }
    
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
