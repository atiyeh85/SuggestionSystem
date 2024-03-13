namespace SuggestionSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SuggestProfil
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SuggestProfil()
        {
            FileUploads = new HashSet<FileUpload>();
            ParticipatingUnits_Suggest_Interface = new HashSet<ParticipatingUnits_Suggest_Interface>();
            SuggProfile_SuggType_Interface = new HashSet<SuggProfile_SuggType_Interface>();
            UnitType_Suggest_Interface = new HashSet<UnitType_Suggest_Interface>();
        }

        [Key]
        public int SuggestId { get; set; }
        public string Benefits { get; set; }
        public string SuggestTitle { get; set; }
        public bool Issms { get; set; }
        public bool IsEditedSugg { get; set; }


        public string SuggestNote { get; set; }

        public string CurrentSituationNote { get; set; }

        public string Result { get; set; }

        public string Cost { get; set; }

        public int? UnitTypeId { get; set; }

        public int? ID_DomainOfUsage { get; set; }

        public int? PersonProfileId { get; set; }
        public string DateInsert { get; set; }
        
        public int PeriodOfTime { get; set; }
        public string Note_Cost { get; set; }
        public string Equipment { get; set; }

        [StringLength(250)]
        public string TimeInsert { get; set; }

        [StringLength(250)]
        public string UserInsert { get; set; }

        [StringLength(250)]
        public string LastTime { get; set; }

        [StringLength(250)]
        public string LastDate { get; set; }

        public bool? IsShow { get; set; }
        public bool IsInvitation { get; set; }
        public int? ID_Invitation { get; set; }
        public string OtherMem { get; set; }

        public int? ID_PeopleType { get; set; }
        public virtual PeopleType PeopleType { get; set; }
        public virtual Invitatin Invitatin { get; set; }
        public virtual DomainOfUsage DomainOfUsage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FileUpload> FileUploads { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ParticipatingUnits_Suggest_Interface> ParticipatingUnits_Suggest_Interface { get; set; }

        public virtual PersonProfile PersonProfile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuggProfile_SuggType_Interface> SuggProfile_SuggType_Interface { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UnitType_Suggest_Interface> UnitType_Suggest_Interface { get; set; }
    }
}
