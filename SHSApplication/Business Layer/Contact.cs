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

        public string ContactId
        {
            get { return contactId; }
            set { contactId = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }


        public string Cell
        {
            get { return cell; }
            set { cell = value; }
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
            return this.ContactId.GetHashCode()^this.Cell.GetHashCode()^this.Email.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        //public void InsertContact()
        //{
        //    Datahandler dh = Datahandler.getData();
        //    Dictionary<string, string[]> cont_details = new Dictionary<string, string[]>();

        //    cont_details.Add(DataAccesHelper.contactId, new string[] { DataAccesHelper.typeString, this.ContactId });
        //    cont_details.Add(DataAccesHelper.contactCell, new string[] { DataAccesHelper.typeString, this.Cell });
        //    cont_details.Add(DataAccesHelper.contactEmail, new string[] { DataAccesHelper.typeString, this.Email });

        //    dh.runQuery(DataAccesHelper.targetContact, DataAccesHelper.requestInsert, cont_details);
        //}

        //public void UpdateContact()
        //{
        //    Datahandler dh = Datahandler.getData();
        //    Dictionary<string, string[]> cont_details = new Dictionary<string, string[]>();

        //    cont_details.Add(DataAccesHelper.contactId, new string[] { DataAccesHelper.typeString, this.ContactId });
        //    cont_details.Add(DataAccesHelper.contactCell, new string[] { DataAccesHelper.typeString, this.Cell });
        //    cont_details.Add(DataAccesHelper.contactEmail, new string[] { DataAccesHelper.typeString, this.Email });

        //    dh.runQuery(DataAccesHelper.targetContact, DataAccesHelper.requestUpdate, cont_details, DataAccesHelper.contactId + " = '" + this.ContactId + "'");
        //}

        //public void RemoveContact()
        //{
        //    Datahandler dh = Datahandler.getData();
        //    Dictionary<string, string[]> cont_details = new Dictionary<string, string[]>();

        //    cont_details.Add(DataAccesHelper.contactId, new string[] { DataAccesHelper.typeString, this.ContactId });
        //    cont_details.Add(DataAccesHelper.contactCell, new string[] { DataAccesHelper.typeString, this.Cell });
        //    cont_details.Add(DataAccesHelper.contactEmail, new string[] { DataAccesHelper.typeString, this.Email });

        //    dh.runQuery(DataAccesHelper.targetContact, DataAccesHelper.requestDelete, cont_details, DataAccesHelper.contactId + " = '" + this.ContactId + "'");
        //}
    }
}
