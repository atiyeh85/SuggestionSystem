namespace SuggestionSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FileUpload
    {
        [Key]
        public int FileId { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        public int? SuggestId { get; set; }

        [StringLength(50)]
        public string Time { get; set; }

        [StringLength(50)]
        public string Date { get; set; }
        public string FileName { get; set; }
        public int Weight { get; set; }

        public int? PersonProfileId { get; set; }

        [StringLength(50)]
        public string mimetype { get; set; }

        public virtual SuggestProfil SuggestProfil { get; set; }
    }
}
