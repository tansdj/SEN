using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHSApplication.HelperLibraries;
using ServerSide;

namespace SHSApplication.Business_Layer
{
    public class Vendor
    {
        private string vendorCode;
        private string name;
        private Address vendorAddress;
        private Contact vendorContact;

        public Vendor(string vendorCode, string name, Address vendorAddress, Contact vendorContact)
        {
            this.VendorCode = vendorCode;
            this.Name = name;
            this.VendorAddress = vendorAddress;
            this.VendorContact = vendorContact;
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
            if (obj==null)
            {
                return false;
            }

            Vendor v = obj as Vendor;
            if ((object)v==null)
            {
                return false;
            }
            return (this.VendorCode==v.VendorCode)&&(this.Name==v.Name)&&(this.VendorAddress==v.VendorAddress)&&(this.VendorContact==v.VendorContact);
        }

        public override int GetHashCode()
        {
            return this.VendorCode.GetHashCode()^this.Name.GetHashCode()^this.VendorAddress.GetHashCode()^this.VendorContact.GetHashCode();
        }

        public void InsertVendor()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> vend_details = new Dictionary<string, string[]>();
            Dictionary<string, string[]> addr_details = new Dictionary<string, string[]>();
            Dictionary<string, string[]> cont_details = new Dictionary<string, string[]>();
            this.VendorCode = "VENDOR" + this.Name.Substring(0,4).Replace(' ','#').ToUpper();
            this.VendorAddress.AddressId = "ADDRESS" + this.VendorCode;
            this.VendorContact.ContactId = "CONTACT" + this.VendorCode;

            vend_details.Add(DataAccesHelper.vendCode, new string[] { DataAccesHelper.typeString, this.VendorCode });
            vend_details.Add(DataAccesHelper.vendName, new string[] { DataAccesHelper.typeString, this.Name });
            vend_details.Add(DataAccesHelper.vendAddressId, new string[] { DataAccesHelper.typeString, this.VendorAddress.AddressId});
            vend_details.Add(DataAccesHelper.vendContactId, new string[] { DataAccesHelper.typeString, this.VendorContact.ContactId });
            addr_details.Add(DataAccesHelper.addressId, new string[] { DataAccesHelper.typeString, this.VendorAddress.AddressId });
            addr_details.Add(DataAccesHelper.addrLine1, new string[] { DataAccesHelper.typeString, this.VendorAddress.AddressLine1 });
            addr_details.Add(DataAccesHelper.addrLine2, new string[] { DataAccesHelper.typeString, this.VendorAddress.AddressLine2 });
            addr_details.Add(DataAccesHelper.addrCity, new string[] { DataAccesHelper.typeString, this.VendorAddress.City });
            cont_details.Add(DataAccesHelper.contactId, new string[] { DataAccesHelper.typeString, this.VendorContact.ContactId });
            cont_details.Add(DataAccesHelper.contactCell, new string[] { DataAccesHelper.typeString, this.VendorContact.Cell });
            cont_details.Add(DataAccesHelper.contactEmail, new string[] { DataAccesHelper.typeString, this.VendorContact.Email });

            dh.runQuery(DataAccesHelper.targetAddress, DataAccesHelper.requestInsert, addr_details);
            dh.runQuery(DataAccesHelper.targetContact, DataAccesHelper.requestInsert, cont_details);
            dh.runQuery(DataAccesHelper.targetVendor, DataAccesHelper.requestInsert, vend_details);

        }

        public void UpdateVendor()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> vend_details = new Dictionary<string, string[]>();
            Dictionary<string, string[]> addr_details = new Dictionary<string, string[]>();
            Dictionary<string, string[]> cont_details = new Dictionary<string, string[]>();
            this.VendorAddress.AddressId = "ADDRESS" + this.VendorCode;
            this.VendorContact.ContactId = "CONTACT" + this.VendorCode;

            vend_details.Add(DataAccesHelper.vendCode, new string[] { DataAccesHelper.typeString, this.VendorCode });
            vend_details.Add(DataAccesHelper.vendName, new string[] { DataAccesHelper.typeString, this.Name });
            vend_details.Add(DataAccesHelper.vendAddressId, new string[] { DataAccesHelper.typeString, this.VendorAddress.AddressId });
            vend_details.Add(DataAccesHelper.vendContactId, new string[] { DataAccesHelper.typeString, this.VendorContact.ContactId });
            addr_details.Add(DataAccesHelper.addressId, new string[] { DataAccesHelper.typeString, this.VendorAddress.AddressId });
            addr_details.Add(DataAccesHelper.addrLine1, new string[] { DataAccesHelper.typeString, this.VendorAddress.AddressLine1 });
            addr_details.Add(DataAccesHelper.addrLine2, new string[] { DataAccesHelper.typeString, this.VendorAddress.AddressLine2 });
            addr_details.Add(DataAccesHelper.addrCity, new string[] { DataAccesHelper.typeString, this.VendorAddress.City });
            cont_details.Add(DataAccesHelper.contactId, new string[] { DataAccesHelper.typeString, this.VendorContact.ContactId });
            cont_details.Add(DataAccesHelper.contactCell, new string[] { DataAccesHelper.typeString, this.VendorContact.Cell });
            cont_details.Add(DataAccesHelper.contactEmail, new string[] { DataAccesHelper.typeString, this.VendorContact.Email });

            dh.runQuery(DataAccesHelper.targetVendor,DataAccesHelper.requestUpdate, vend_details,DataAccesHelper.vendCode + " = '"+this.VendorCode+"'");
            dh.runQuery(DataAccesHelper.targetAddress, DataAccesHelper.requestUpdate, addr_details, DataAccesHelper.addressId + " = '" + this.VendorAddress.AddressId + "'");
            dh.runQuery(DataAccesHelper.targetContact, DataAccesHelper.requestUpdate, cont_details, DataAccesHelper.contactId + " = " + this.VendorContact.ContactId + "'");
        }
    }
}
