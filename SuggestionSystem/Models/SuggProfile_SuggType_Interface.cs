namespace SuggestionSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SuggProfile_SuggType_Interface
    {
        public int id { get; set; }

        public int? ID_SuggType { get; set; }
        public int? ID_SuggTypeRefree { get; set; }

        public int? ID_SuggProfile { get; set; }
        public string User_Secretariate { get; set; }
        public string Date_Secretariate { get; set; }
        public string time_Secretariate { get; set; }
        public string Edit_Date_Secretariate { get; set; }
        public string Edit_Time_Secretariate { get; set; }
        public string Edit_User_Secretariate { get; set; }
        public string Date { get; set; }
        [DisplayName(" تاریخ ثبت داور   ")]
        public string Date_Referee { get; set; }
        public string User_Referee { get; set; }
        public string Time_Referee { get; set; }
        public string Edit_Time_Referee { get; set; }
        public string Edit_Date_Referee { get; set; }
        public string Edit_User_Referee { get; set; }

        [StringLength(50)]
        [DisplayName("    شماره صورتجلسه  ")]

        public string LetterNumber { get; set; }
        [DisplayName("   توضیحات- دبیر خانه      ")]

        public string Note_Secretariate { get; set; }
        [DisplayName("   توضیحات - داوران      ")]
        public string Note_Referee { get; set; }
        [DisplayName("    مجموع امتیاز       ")]

        [Range(0, 100, ErrorMessage = "امتیاز وارد شده باید بین 0 و 100 باشد")]
        public int? Point { get; set; }
        public bool IsActive { get; set; }
        public bool IsRefree { get; set; }
        public bool IsEdited { get; set; }
        public bool RefreeSms { get; set; }
        public bool SecreSms { get; set; }

        public int? ID_Part { get; set; }


        public virtual PartType PartType { get; set; }

        public virtual SuggestProfil SuggestProfil { get; set; }

        public virtual SuggestType SuggestType { get; set; }
    }
}
