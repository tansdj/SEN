using Serverside.HelperLibraries;
using ServerSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class Address
    {
        private string addressId;
        private string addressLine1;
        private string addressLine2;
        private string city;
        private string postalCode;

        public Address(string addressId, string addressLine1, string addressLine2, string city, string postalCode)
        {
            this.AddressId = addressId;
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
            this.City = city;
            this.PostalCode = postalCode;
        }

        public Address()
        {

        }
        public string PostalCode
        {
            get { return postalCode; }
            set { postalCode = value.Trim(' '); }
        }

        public string AddressId
        {
            get { return addressId; }
            set { addressId = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value.Trim(' '); }
        }


        public string AddressLine2
        {
            get { return addressLine2; }
            set { addressLine2 = value.Trim(' '); }
        }


        public string AddressLine1
        {
            get { return addressLine1; }
            set { addressLine1 = value.Trim(' '); }
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            Address a = obj as Address;
            if ((object)a==null)
            {
                return false;
            }
            return (this.AddressId==a.AddressId)&&(this.AddressLine1==a.AddressLine1)&&(this.AddressLine2==a.AddressLine2)&&(this.City==a.City)&&(this.PostalCode==a.PostalCode);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
            //return this.AddressId.GetHashCode()^this.AddressLine1.GetHashCode()^this.AddressLine2.GetHashCode()^this.City.GetHashCode()^this.PostalCode.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}\n{1}\n{2}\n{3}",this.AddressLine1,this.AddressLine2,this.City,this.PostalCode);
        }

        

    }
}
