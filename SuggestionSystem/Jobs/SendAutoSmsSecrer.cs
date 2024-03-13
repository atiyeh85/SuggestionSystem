using Quartz;
using SuggestionSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace SuggestionSystem.Jobs
{
    public class SendAutoSmsSecrer : IJob
    {
        private StoreDb db = new StoreDb();

        public Task Execute(IJobExecutionContext context)
        {
            var list = db.SuggProfile_SuggType_Interface.Where(s => s.SecreSms == true).ToList();
            foreach (var item in list)
            {
                string tel = item.SuggestProfil.PersonProfile.Mobile;
                DateTime date;
                string message = "با سلام همکار گرامی" + " \n"+ "نظر دبیرخانه برای پیشنهاد شما ثبت گردید. لطفا برای پیگیری پیشنهاد خود، به سامانه نظام پیشنهادها در پورتال شهرداری مراجعه فرمایید" + "\n" + "مدیریت نوسازی و تحول اداری-معاونت برنامه‌ریزی و توسعه سرمایه انسانی ";
                string username = "shahrdariqazvin_fava";
                string password = "fava281";
                string[] senderNumbers = { "30002309" };
                string[] recipientNumbers = { tel };
                string[] messageBodies = { message };
               
                date = DateTime.Now;
                date = DateTime.Now.AddHours(8);
                int[] messageClasses = { };
                long[] MessageIDs = { };
                //SuggestionSystem.ParsaSms.v2 ws = new SuggestionSystem.ParsaSms.v2();
                //ws.SendSMS(username, password, senderNumbers, recipientNumbers, messageBodies, null, null, null);
                item.SecreSms = false;
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }


            return Task.CompletedTask;
        }
    }
}
