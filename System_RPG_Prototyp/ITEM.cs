//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace System_RPG_Prototyp
{
    using System;
    using System.Collections.Generic;
    
    public partial class ITEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ITEM()
        {
            this.DZIALANIE = new HashSet<DZIALANIE>();
            this.OCENA = new HashSet<OCENA>();
        }
    
        public int IDITEM { get; set; }
        public short IDKATEGORIA { get; set; }
        public int IDUZYTKOWNIK { get; set; }
        public byte WAGA { get; set; }
        public bool DWURECZNOSC { get; set; }
        public string NAZWA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DZIALANIE> DZIALANIE { get; set; }
        public virtual KATEGORIA KATEGORIA { get; set; }
        public virtual UZYTKOWNIK UZYTKOWNIK { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OCENA> OCENA { get; set; }
    }
}
