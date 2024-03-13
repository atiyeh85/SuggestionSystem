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
    public class SendAutoSms : IJob
    {
        private StoreDb db = new StoreDb();

        public Task Execute(IJobExecutionContext context)
        {
            var list = db.SuggestProfils.Where(s => s.Issms == false).ToList();
            foreach (var item in list)
            {
                string tel = item.PersonProfile.Mobile;
                DateTime date;
                string message = item.PersonProfile.FullName + " "+"همکار گرامی ایده شما  با موفقیت ثبت شد"+" "+"از همکاری شما سپاسگزاریم." + "\n" + "سامانه نظام پیشنهادهای شهرداری قزوین ";
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
                item.Issms = true;
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }


            return Task.CompletedTask;
        }
    }
}
