using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class Client
    {
        private string idNr;
        private string name;
        private string surname;      
        private string paymentMethod;
        private string status;
        private Address clientAddress;
        private Contact clientContact;

        

        public Client()
        {

        }

        public Contact ClientContact
        {
            get { return clientContact; }
            set { clientContact = value; }
        }


        public Address ClientAddress
        {
            get { return clientAddress; }
            set { clientAddress = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }


        public string PaymentMethod
        {
            get { return paymentMethod; }
            set { paymentMethod = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public string IdNr
        {
            get { return idNr; }
            set { idNr = value; }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void newClient() { }//Take address and contact as parameters

        public void updateClient(Client client) { }

    }
}
