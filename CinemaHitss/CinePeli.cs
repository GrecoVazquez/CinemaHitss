//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CinemaHitss
{
    using System;
    using System.Collections.Generic;
    
    public partial class CinePeli
    {
        public int ID_Cine { get; set; }
        public int ID_Pelicula { get; set; }
        public int ID { get; set; }
    
        public virtual Cine Cine { get; set; }
        public virtual Pelicula Pelicula { get; set; }
    }
}
