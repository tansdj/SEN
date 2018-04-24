using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class Vendor
    {
        private string vendorCode;
        private string name;
        private Address vendorAddress;
        private Contact vendorContact;

        public Vendor()
        {

        }

        public Contact VendorContact
        {
            get { return vendorContact; }
            set { vendorContact = value; }
        }


        public Address VendorAddress
        {
            get { return vendorAddress; }
            set { vendorAddress = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public string VendorCode
        {
            get { return vendorCode; }
            set { vendorCode = value; }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
