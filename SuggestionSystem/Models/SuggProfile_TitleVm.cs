using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuggestionSystem.Models
{
    public class SuggProfile_TitleVm
    {
        public SuggProfile_TitleVm()
        {
            TitlList = db.TitlLists.ToList();
            UnitList = db.UnitTypes.ToList();
        }
        private StoreDb db = new StoreDb();
        public string User_Secretariate { get; set; }
        [Key]
        public int SuggestId { get; set; }
        public int PostId { get; set; }
        public string LastTime { get; set; }
        public string LastDate { get; set; }
        public int? ID_PeopleType { get; set; }
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر های وارد شده بیشتر از حد مجاز 500 کاراکتر است!")]
        public string OtherMem { get; set; }
        public List<TitlList> TitlList
        {
            get;
            set;
        }
        public List<UnitType> UnitList
        {
            get;
            set;
        }
        [Required(ErrorMessage = "   پر کردن فیلد اجباری است!  ")]
        [DisplayName(" عنوان پیشنهاد    ")]
        public string SuggestTitle { get; set; }

        
        [DisplayName("  وضعیت مطلوب    ")]

        public string SuggestNote { get; set; }
        public string DateInsert { get; set; }
        public string TimeInsert { get; set; }
        public string UserInsert { get; set; }

        [Required(ErrorMessage = "   پر کردن فیلد اجباری است!  ")]
        [DisplayName("    وضعیت موجود        ")]
        public string CurrentSituationNote { get; set; }
        [DisplayName("     عنوان فرآخوان       ")]
        public string Title_Invitation { get; set; }
        [DisplayName("        تمایل به شرکت در فرآخوان        ")]

        public bool IsInvitation { get; set; }

        [DisplayName("    مزایای روش پیشنهادی         ")]
        public string Result { get; set; }

        [DisplayName("    میزان اعتبار          ")]
        public string Cost { get; set; }
        [DisplayName("    حوزه فعالیت           ")]
        public int? UnitTypeId { get; set; }
        [DisplayName("    دامنه کاربرد            ")]
        public int? ID_DomainOfUsage { get; set; }
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر های وارد شده بیشتر از حد مجاز 500 کاراکتر است!")]
        public string Note_Cost { get; set; }
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر های وارد شده بیشتر از حد مجاز 500کاراکتر است!")]
        public string Benefits { get; set; }
        [Required]
        [DisplayName(" مدت زمان مورد نیاز ")]
        
        public int PeriodOfTime { get; set; }
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر های وارد شده بیشتر از حد مجاز 500کاراکتر است!")]
        public string Equipment { get; set; }
        public bool Issms { get; set; }
        public int? ID_Invitation { get; set; }
        public int? PersonProfileId { get; set; }

    }
}