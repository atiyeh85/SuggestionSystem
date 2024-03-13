namespace SuggestionSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UnitType_Suggest_Interface
    {
        public int Id { get; set; }

        public int? SuggestId { get; set; }

        public int? ID_UnitType { get; set; }

        [StringLength(50)]
        public string LastTime { get; set; }

        [StringLength(50)]
        public string LastDate { get; set; }

        public virtual SuggestProfil SuggestProfil { get; set; }

        public virtual UnitType UnitType { get; set; }
    }
}
