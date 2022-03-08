using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace AirTickets.Core.Validate
{
    public class Validate
    {
        public static bool Email(string email)
        {
            try
            {
                email = new MailAddress(email).Address;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        } 
    }
}
