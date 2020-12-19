using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ShareWatch.Common.Utility
{
    public static class StringExtension
    {

        public static List<string> ToList(this string Data, string Spliter)
        {
            string[] sa = Data.Split(Spliter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            List<string> al = new List<string>();
            foreach (string s in sa)
            {
                al.Add(s);
            }
            return al;
        }

        public static List<string> ToList(this string text)
        {
            string spliter = ";,";
            string[] sa = text.Split(spliter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            List<string> al = new List<string>();
            foreach (string s in sa)
            {
                al.Add(s);
            }
            return al;
        }



        public static List<MailAddress> ToMailList(this string text)
        {
            if (text == null || text.Trim() == "") return new List<MailAddress>();
            List<string> address = text.ToList();
            List<MailAddress> mailAddress = new List<MailAddress>();
            foreach (string s in address)
            {
                if (string.IsNullOrEmpty(s))
                {
                    continue;
                }
                mailAddress.Add(new MailAddress(s));
            }
            return mailAddress;
        }

    }
}
