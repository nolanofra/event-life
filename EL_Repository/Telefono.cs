//------------------------------------------------------------------------------
// <auto-generated>
//    Codice generato da un modello.
//
//    Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//    Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EL_Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Telefono
    {
        public int ID_telefono { get; set; }
        public string tel { get; set; }
        public System.Guid profilo_id { get; set; }
    
        public virtual Profilo Profilo { get; set; }
    }
}
