using Serverside.HelperLibraries;
using ServerSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class Contact
    {
        private string contactId;
        private string cell;
        private string email;

        public Contact(string contactId, string cell, string email)
        {
            this.ContactId = contactId;
            this.Cell = cell;
            this.Email = email;
        }

        public Contact()
        {

        }
        public string ContactId
        {
            get { return contactId; }
            set { contactId = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value.Trim(' '); }
        }


        public string Cell
        {
            get { return cell; }
            set { cell = value.Trim(' '); }
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            Contact c = obj as Contact;
            if ((object)c==null)
            {
                return false;
            }
            return (this.ContactId==c.ContactId)&&(this.Cell==c.Cell)&&(this.Email==c.Email);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
            //return this.ContactId.GetHashCode()^this.Cell.GetHashCode()^this.Email.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}\n{1}",this.Cell,this.Email);
        }
    }
}
