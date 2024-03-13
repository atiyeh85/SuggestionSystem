namespace SuggestionSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Search
    {
        public int SearchId { get; set; }

        [Required(ErrorMessage = "کد ملی را واردکنید.")]
        [DisplayName("کد ملی  ")]
        [StringLength(10, ErrorMessage = "فیلد کد ملی  باید 10 رقم باشد", MinimumLength = 10)]
        public string NationalCode { get; set; }
        [Display(Name = "شماره همراه")]
        [StringLength(11, ErrorMessage = "فیلد شماره همراه حداکثر باید 11 رقم باشد", MinimumLength = 11)]
        public string Mobile { get; set; }

        public string FullName { get; set; }
        //[Required(ErrorMessage = "کد امنیتی  را وارد کنید")]
        [Display(Name = "کد امنیتی")]
        public string Securitycode { get; set; }


    }
}
