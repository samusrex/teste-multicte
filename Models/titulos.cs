//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TituloApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class titulos
    {
        public int titulo_id { get; set; }
        public string numero { get; set; }
        public System.DateTime data_emissao { get; set; }
        public string cliente { get; set; }
        public int situacao { get; set; }
        public string observacao { get; set; }
        public Nullable<decimal> Valor { get; set; }
    }
}