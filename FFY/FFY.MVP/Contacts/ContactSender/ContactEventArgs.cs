using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Contacts.ContactSender
{
    public class ContactEventArgs : EventArgs
    {
        public ContactEventArgs(string title,
            string email,
            string emailContent,
            DateTime sendOn,
            ContactStatusType statusType)
        {
            if(string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("Title cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("Email cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(emailContent))
            {
                throw new ArgumentNullException("Email content cannot be null or empty.");
            }

            this.Title = title;
            this.Email = email;
            this.EmailContent = emailContent;
            this.SendOn = sendOn;
            this.StatusType = statusType;
        }

        public string Title { get; set; }
        public string Email { get; set; }
        public string EmailContent { get; set; }
        public DateTime SendOn { get; set; }
        public ContactStatusType StatusType { get; set; }
    }
}
