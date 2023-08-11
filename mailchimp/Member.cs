using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace mailchimp
{
    
    internal class Member
    {
        private string _status;
        public string email_address { get; set; }
        public string status 
        {
            get { return _status; }
            set
            {
                if (value == "unsubscribed" || value == "subscribed")
                {
                    _status = value;
                }
                else
                {
                    throw new ArgumentException("Invalid status value. Valid values are 'unsubscribed' or 'subscribed'.");
                }
            }
        }
    }
}
