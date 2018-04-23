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
        private string addressLine1;
        private string addressLine2;
        private string city;
        private string cell;
        private string email;
        private string paymentMethod;
        private string status;

        public Client()
        {

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


        public string City
        {
            get { return city; }
            set { city = value; }
        }


        public string AddressLine2
        {
            get { return addressLine2; }
            set { addressLine2 = value; }
        }


        public string AddressLine1
        {
            get { return addressLine1; }
            set { addressLine1 = value; }
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

        public void newClient() { }

        public void updateClient(Client client) { }

    }
}
