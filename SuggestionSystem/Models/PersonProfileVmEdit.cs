namespace SuggestionSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Net.Http;
    using System.Web.Mvc;

    public partial class PersonProfileVmEdit
    {

        public int PersonProfileId { get; set; }

        [Required(ErrorMessage = "نام خانوادگی را وارد کنید.")]
        [DisplayName(" نام خانوادگی   ")]
        public string FullName { get; set; }

        [DisplayName(" نام پدر   ")]
        [Required(ErrorMessage = "نام پدر  را وارد کنید")]
        public string FatherName { get; set; }

        //[Required(ErrorMessage = "کد ملی را وارد کنید")]
        //[StringLength(10, MinimumLength = 10, ErrorMessage = "کد ملی باید 10 رقم باشد")]
        //[Remote("IsValidN", "PersonProfiles", HttpMethod = "POST", ErrorMessage = "این بارکد از قبل در سیستم وجود دارد.")]
        //public string NationalCode { get; set; }

        [DisplayName("   تلفن همراه   ")]
        [Required(ErrorMessage = "تلفن همراه  را وارد کنید")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "تلفن همراه  باید 11 رقم باشد")]
        public string Mobile { get; set; }

        [DisplayName(" تاریخ تولد    ")]

        [StringLength(10, MinimumLength =10, ErrorMessage = "تاریخ تولد  باید 10 رقم باشد")]
        public string BirthDate { get; set; }
        [DisplayName("     پست سازمانی   ")]
        [MaxLength(250, ErrorMessage = "تعداد کاراکتر های وارد شده بیشتر از حد مجاز است!")]
        public string PostOrgans { get; set; }
        [StringLength(500)]
        public string Image { get; set; }

        [MaxLength(1500, ErrorMessage = "تعداد کاراکتر های وارد شده بیشتر از حد مجاز است!")]
        public string Note { get; set; }

        [StringLength(150)]
        [DisplayName("  رشته تحصیلی   ")]
        [Required(ErrorMessage = " رشته تحصیلی  را وارد کنید")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر های وارد شده بیشتر از حد مجاز است!")]

        public string Reshte { get; set; }

        [StringLength(10)]
        public string DateUpload { get; set; }

        [StringLength(10)]
        public string TimeUpload { get; set; }

        [StringLength(10)]
        public string DateEdit { get; set; }

        [StringLength(10)]
        public string TImeEdit { get; set; }

        [StringLength(50)]
        [DisplayName("   تلفن ثابت   ")]
        //[Required(ErrorMessage = "تلفن ثابت  را وارد کنید")]
        [MaxLength(11, ErrorMessage = "تعداد کاراکتر های وارد شده بیشتر از حد مجاز است!")]
        public string Phone { get; set; }


        public int? DegreeId { get; set; }


        public int? PostId { get; set; }

        //[DisplayName("   آدرس محل سکونت   ")]
        //[Required(ErrorMessage = "  آدرس محل سکونت  را وارد کنید")]
        //[MaxLength(500, ErrorMessage = "تعداد کاراکتر های وارد شده بیشتر از حد مجاز است!")]
        //public string Address { get; set; }

        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        public int? ID_MemType { get; set; }


        public bool? Isshow { get; set; }

       

        public int? ID_PeopleType { get; set; }

        public string OtherMem { get; set; }
    }
}
