using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuggestionSystem.Models
{
    public class SuggestProfilVm
    {
        public SuggestProfilVm()
        {
            FileUploads = new HashSet<FileUpload>();
            //ParticipatingUnits_Suggest_Interface = new HashSet<ParticipatingUnits_Suggest_Interface>();

        }
        private StoreDb db = new StoreDb();
        public string User_Secretariate { get; set; }
        public int payvast { get; set; }
        public int? ID_SuggTypeRefree { get; set; }
        public int? SuggestId { get; set; }
        public int? SuggTypetId { get; set; }
        [DisplayName(" منافع حاصله از پیشنهاد ")]
        public string Benefits { get; set; }
        public bool IsEditable { get; set; }
        public bool? IsRefree { get; set; }


        [Required]
        [DisplayName(" مدت زمان مورد نیاز ")]
    
        public int PeriodOfTime { get; set; }


        public string PostOrgans { get; set; }
        [DisplayName(" امکانات و تجهیزات مورد نیاز    ")]
        public string Equipment { get; set; }
        public bool IsEditedSugg { get; set; }
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر های وارد شده بیشتر از حد مجاز 500 کاراکتر است!")]
        [DisplayName(" نحوه محاسبه هزینه ")]
        public string Note_Cost { get; set; }
        public int S_T_Interface { get; set; }
        //[MaxLength(500, ErrorMessage = "تعداد کاراکتر های وارد شده بیشتر از حد مجاز 500 کاراکتر است!")]
        public string OtherMem { get; set; }

        [StringLength(700)]
        [DisplayName(" عنوان پیشنهاد    ")]
        public string SuggestTitle { get; set; }
        public int? ID_PeopleType { get; set; }
        public bool IsActive { get; set; }
        public string Date_Secretariate { get; set; }
        public string time_Secretariate { get; set; }
        public string Edit_Date_Secretariate { get; set; }
        public string Edit_Time_Secretariate { get; set; }
        public string Edit_User_Secretariate { get; set; }
        public string Image { get; set; }
        public string LastState { get; set; }
        [DisplayName(" تاریخ ثبت داور   ")]
        public string Date_Referee { get; set; }
        public string User_Referee { get; set; }
        public string Time_Referee { get; set; }
        public string Edit_Time_Referee { get; set; }
        public string Edit_Date_Referee { get; set; }
        public string Edit_User_Referee { get; set; }
        public int Count { get; set; }
        [StringLength(700)]
        [DisplayName(" وضعیت مطلوب (شرح پیشنهاد)    ")]
        public string SuggestNote { get; set; }
        [DisplayName(" وضعیت پیشنهاد - دبیرخانه    ")]
        public string Title_SuggestType { get; set; }
        [DisplayName(" وضعیت پیشنهاد - داوران    ")]
        public string Title_SuggestType_Referee { get; set; }
        [DisplayName(" وضعیت پیشنهاد - دبیرخانه    ")]
        public string Title_SuggestType_Secretariate { get; set; }
        [DisplayName(" شماره نامه     ")]
        public string LetterNumber { get; set; }
        [DisplayName(" نوع شرکت کننده     ")]
        public string Title_PartType { get; set; }
        [DisplayName("   توضیحات- دبیر خانه      ")]
        public string Note_Secretariate { get; set; }
        [DisplayName(" مجموع امتیاز       ")]
     
        public int? Point { get; set; }
        [DisplayName("   توضیحات - داوران      ")]
        public string Note_Referee { get; set; }
        [DisplayName("    شرکت کننده      ")]
        public string Title_MemberType { get; set; }
        [DisplayName(" تاریخ ثبت ")]
        public string InsertDate { get; set; }
        [DisplayName("   مدرک تحصیلی      ")]
        public string Title_Degree { get; set; }
        
        public string Title_Post{ get; set; }
        [StringLength(700)]

        [DisplayName("    وضعیت موجود        ")]
        public string CurrentSituationNote { get; set; }
        public bool? IsInvitation { get; set; }
        public int? ID_Invitation { get; set; }

        [StringLength(700)]

        [DisplayName(" مزایای روش پیشنهادی      ")]
        public string Result { get; set; }
        [DisplayName("   میزان اعتبار برآورد شده ")]
        public string Cost { get; set; }
        public int? ID_Part { get; set; }
        public bool Issms { get; set; }

        [DisplayName("    حوزه فعالیت           ")]

        public int? UnitTypeId { get; set; }

        public int? ID_DomainOfUsage { get; set; }

        public int? PersonProfileId { get; set; }


        [Required(ErrorMessage = " نام و نام خانوادگی وارد کنید")]
        [DisplayName(" نام و نام خانوادگی   ")]
        public string FullName { get; set; }

        [Required(ErrorMessage = " نام پدر وارد کنید")]
        [DisplayName("نام پدر ")]
        public string FatherName { get; set; }

        [DisplayName(" کد ملی   ")]
        [Required(ErrorMessage = "کد ملی را وارد کنید")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "کد ملی باید 10 رقم باشد")]
        public string NationalCode { get; set; }

        [DisplayName("   تلفن همراه   ")]
        [Required(ErrorMessage = "تلفن همراه  را وارد کنید")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "تلفن همراه  باید 11 رقم باشد")]
        public string Mobile { get; set; }

        [UIHint("PersianDatePicker")]
        [DisplayName(" تاریخ تولد    ")]
        public string BirthDate { get; set; }
        public string Password { get; set; }

        [StringLength(500)]

        [DisplayName(" توضیحات     ")]
        public string Note { get; set; }

        [DisplayName("   رشته تحصیلی    ")]
        [Required(ErrorMessage = "رشته تحصیلی  را وارد کنید")]
        public string Reshte { get; set; }
        [DisplayName("   تلفن ثابت   ")]
        [Required(ErrorMessage = "تلفن ثابت  را وارد کنید")]
        public string Phone { get; set; }
        [DisplayName("   مدرک تحصیلی    ")]
        [Required(ErrorMessage = "مدرک تحصیلی   را وارد کنید")]
        public int? DegreeId { get; set; }
        [DisplayName("    سمت    ")]
        [Required(ErrorMessage = "سمت    را وارد کنید")]
        public int? PostId { get; set; }

        [StringLength(500)]
        [DisplayName("   آدرس منزل    ")]

        public string Address { get; set; }

        [DisplayName("   آدرس پست الکترونیک    ")]
        public string Email { get; set; }
        [DisplayName("   نوع شرکت کننده      ")]
        public int? ID_MemType { get; set; }
        [DisplayName(" تاریخ ثبت  ")]
        public string DateInsert { get; set; }
        public List<SuggProfile_SuggType_Interface> S_SuggType_Inter { get; set; }
        public bool? Isshow { get; set; }
        [StringLength(50)]
        [DisplayName("   تاریخ ثبت  ")]

        public string Date { get; set; }
        public virtual DomainOfUsage DomainOfUsage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FileUpload> FileUploads { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ParticipatingUnits_Suggest_Interface> ParticipatingUnits_Suggest_Interface { get; set; }

        public virtual PersonProfile PersonProfile { get; set; }
    }
}