namespace SuggestionSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ParticipatingUnit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ParticipatingUnit()
        {
            ParticipatingUnits_Suggest_Interface = new HashSet<ParticipatingUnits_Suggest_Interface>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public bool? Checked { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ParticipatingUnits_Suggest_Interface> ParticipatingUnits_Suggest_Interface { get; set; }
    }
}
