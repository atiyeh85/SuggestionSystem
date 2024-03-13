namespace SuggestionSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UnitType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UnitType()
        {
            UnitType_Suggest_Interface = new HashSet<UnitType_Suggest_Interface>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public bool Checked { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UnitType_Suggest_Interface> UnitType_Suggest_Interface { get; set; }
    }
}
