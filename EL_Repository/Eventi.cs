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
    
    public partial class Eventi
    {
        public int Id_evento { get; set; }
        public string Titolo { get; set; }
        public string desc_breve { get; set; }
        public string desc_lunga { get; set; }
        public Nullable<int> gallery_id { get; set; }
        public System.DateTime data_inizio { get; set; }
        public System.DateTime data_fine { get; set; }
        public System.Guid profilo_id { get; set; }
        public int categoria_id { get; set; }    
        public virtual Categoria Categoria { get; set; }
        public virtual Gallery Gallery { get; set; }        
        public virtual Profilo Profilo { get; set; }
    }
}
