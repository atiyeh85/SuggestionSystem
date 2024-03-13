using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace SuggestionSystem.Utility
{
    public class PertionDate
    {
        public static string Today()
        {
            DateTime dt = DateTime.Now;

            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();

            return p.GetYear(dt).ToString() + "/" + p.GetMonth(dt).ToString("0#") + "/" + p.GetDayOfMonth(dt).ToString("0#");
        }
        public static DateTime CalculateDate(string Date,string time)
        {

            var year = Convert.ToInt16(Date.Substring(0, 4));
            var month = Convert.ToInt16(Date.Substring(5, 2));
            var day = Convert.ToInt16(Date.Substring(8, 2));
            //var min= Convert.ToInt16(time.Substring(0, 2));
            //var sec= Convert.ToInt16(time.Substring(3, 2));
            var TimeSpam= time.Substring(5, 2);
            PersianCalendar persianDate = new PersianCalendar();
            //DateTime start = DateTime.Parse(time);
            //TimeSpan span1 = new TimeSpan(10, 20, 0);
            DateTime st = persianDate.ToDateTime(year, month, day, 0, 0, 0, 0);
            //DateTime newDateTime = st.Add(TimeSpan.Parse(start.ToShortTimeString()));
            DateTime NextDate = st.AddDays(1);
            var GetYear = persianDate.GetYear(NextDate).ToString();
            var GetMonth = persianDate.GetMonth(NextDate).ToString("0#");
            var GetDayOfMonth = persianDate.GetDayOfMonth(NextDate).ToString("0#");
            //return GetYear + "/" + GetMonth + "/" + GetDayOfMonth;
            return NextDate;
        }
        public static string PtoE(string Number)
        {
            string jj = Number;
            var Converted = Number.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");
            return Converted;
        }
        public static string ConvertNumbersToEnglish(string str)
        {
            return str.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");
        }
        public static string GenerateString(string Rasteh)
        {
            Random rand = new Random();
            var Year = Utility.PertionDate.Today();
            var Years = Year.Substring(2, 2);
            const string Alphabet =
           "0123456789";
            int size = 5;
            char[] Chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                Chars[i] = Alphabet[rand.Next(Alphabet.Length)];
            }
            var CharsString = new string(Chars);
            CharsString = Years + "" + Rasteh + "" + CharsString;
            return (CharsString);
        }
        public static string EditString(string Rasteh,string nid)
        {
           
            var nidS = nid;
            var Y= nidS.Substring(0, 2);
            var R = nidS.Substring(2, 2);
            var c = nidS.Substring(4,5);
           
          var  CharsString = Y + "" + Rasteh + "" + c;
            return (CharsString);
        }
        public static string GenerateCoderahgiri(string personalcode)

        {
            var Year = Utility.PertionDate.Today();
            var Years = Year.Substring(2, 2);
            var str=Years + "" + personalcode;
            return str;

        }
        public static string EditCoderahgiri(string personalcode,string beforecoderahgiri)

        {
            var befcod = beforecoderahgiri;
            var Years = befcod.Substring(0, 2);
            var str = Years + "" + personalcode;
            return str;

        }
        public static int CurrentMonth()
        {
            DateTime dt = DateTime.Now;

            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();

            return p.GetMonth(dt);
        }
        public  static string GetAge(string date)
        {
            try
            {
                System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
                DateTime dt = p.ToDateTime(int.Parse(date.Substring(0, 4)),
                    int.Parse(date.Substring(5, 2)),
                    int.Parse(date.Substring(8, 2)), 0, 0, 0, 0);

                int age = (int)DateTime.Now.Subtract(dt).TotalDays / 365;
                string Age = Convert.ToString(age);
                return Age;
            }
            catch (Exception ex)
            {
            }
            return "1";

        }
    }
}