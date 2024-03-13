using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using SuggestionSystem.ParsaSms;

namespace SuggestionSystem.utility
{
    public class SmSSender
    {
        public static long[]  SendSmS(string Mobile)
        {
            string Phone = Mobile;
            string message = " همکارگرامی ایده شما با موفقیت ثبت شد  . از همکاری شما سپاسگزاریم " + "\n" + "سامانه نظام پیشنهادهای شهرداری قزوین ";

            string username = "";
            string password = "";
            string[] senderNumbers = { "" };
            string[] recipientNumbers = { Phone };
            string[] messageBodies = { message };
            int[] messageClasses = { };
            long[] MessageIDs = { };
            return MessageIDs;

        }
        public static long[] SendSmS(string Mobile,string code)
        {
            string Phone = Mobile;
            string message = "همکارگرامی " + "\n"+"کلمه عبور شما  "+code.ToString()+" می باشد."+"\n" + "سامانه نظام پیشنهادهای شهرداری قزوین ";

            string username = "";
            string password = "";
            string[] senderNumbers = { "" };
            string[] recipientNumbers = { Phone };
            string[] messageBodies = { message };
            int[] messageClasses = { };
            long[] MessageIDs = { };
            return MessageIDs;

        }
        public static string GenerateString()
        {
            Random rand = new Random();

            const string Alphabet =
           "0123456789";
            int size = 6;
            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = Alphabet[rand.Next(Alphabet.Length)];
            }

            return new string(chars);
        }
    }
}