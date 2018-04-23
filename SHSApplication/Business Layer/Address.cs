using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class Address
    {
        private string addressLine1;
        private string addressLine2;
        private string city;

        public Address()
        {

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

    }
}
