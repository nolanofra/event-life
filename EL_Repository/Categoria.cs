//------------------------------------------------------------------------------
// <auto-generated>
//    Codice generato da un modello.
//
//    Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//    Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace EL_Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Categoria
    {
        public Categoria()
        {
            this.Eventis = new HashSet<Eventi>();
            this.Profiloes = new HashSet<Profilo>();
        }
    
        public int ID_categoria { get; set; }
        public string Titolo { get; set; }

        
        public virtual ICollection<Eventi> Eventis { get; set; }
        
        public virtual ICollection<Profilo> Profiloes { get; set; }
    }
}
