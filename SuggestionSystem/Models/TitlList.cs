namespace SuggestionSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TitlList
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public bool Checked { get; set; }
    }
}
