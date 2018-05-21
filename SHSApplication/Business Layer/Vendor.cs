using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerSide;
using Serverside.HelperLibraries;
using System.Data;

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

        //public void InsertVendor()
        //{
        //    Datahandler dh = Datahandler.getData();
        //    Dictionary<string, string[]> vend_details = new Dictionary<string, string[]>();
        //    Dictionary<string, string[]> addr_details = new Dictionary<string, string[]>();
        //    Dictionary<string, string[]> cont_details = new Dictionary<string, string[]>();
        //    this.VendorCode = "VENDOR" + this.Name.Substring(0,4).Replace(' ','#').ToUpper();
        //    this.VendorAddress.AddressId = "ADDRESS" + this.VendorCode;
        //    this.VendorContact.ContactId = "CONTACT" + this.VendorCode;

        //    vend_details.Add(DataAccesHelper.vendCode, new string[] { DataAccesHelper.typeString, this.VendorCode });
        //    vend_details.Add(DataAccesHelper.vendName, new string[] { DataAccesHelper.typeString, this.Name });
        //    vend_details.Add(DataAccesHelper.vendAddressId, new string[] { DataAccesHelper.typeString, this.VendorAddress.AddressId});
        //    vend_details.Add(DataAccesHelper.vendContactId, new string[] { DataAccesHelper.typeString, this.VendorContact.ContactId });

        //    this.VendorAddress.InsertAddress();
        //    this.VendorContact.InsertContact();
        //    dh.runQuery(DataAccesHelper.targetVendor, DataAccesHelper.requestInsert, vend_details);

        //}

        //public void UpdateVendor()
        //{
        //    Datahandler dh = Datahandler.getData();
        //    Dictionary<string, string[]> vend_details = new Dictionary<string, string[]>();
        //    Dictionary<string, string[]> addr_details = new Dictionary<string, string[]>();
        //    Dictionary<string, string[]> cont_details = new Dictionary<string, string[]>();
        //    this.VendorAddress.AddressId = "ADDRESS" + this.VendorCode;
        //    this.VendorContact.ContactId = "CONTACT" + this.VendorCode;

        //    vend_details.Add(DataAccesHelper.vendCode, new string[] { DataAccesHelper.typeString, this.VendorCode });
        //    vend_details.Add(DataAccesHelper.vendName, new string[] { DataAccesHelper.typeString, this.Name });
        //    vend_details.Add(DataAccesHelper.vendAddressId, new string[] { DataAccesHelper.typeString, this.VendorAddress.AddressId });
        //    vend_details.Add(DataAccesHelper.vendContactId, new string[] { DataAccesHelper.typeString, this.VendorContact.ContactId });

        //    this.VendorAddress.UpdateAddress();
        //    this.VendorContact.UpdateContact();
        //    dh.runQuery(DataAccesHelper.targetVendor,DataAccesHelper.requestUpdate, vend_details,DataAccesHelper.vendCode + " = '"+this.VendorCode+"'");
        //}

        //public void RemoveVendor()
        //{
        //    Datahandler dh = Datahandler.getData();
        //    Dictionary<string, string[]> vend_details = new Dictionary<string, string[]>();
        //    Dictionary<string, string[]> addr_details = new Dictionary<string, string[]>();
        //    Dictionary<string, string[]> cont_details = new Dictionary<string, string[]>();
        //    this.VendorAddress.AddressId = "ADDRESS" + this.VendorCode;
        //    this.VendorContact.ContactId = "CONTACT" + this.VendorCode;

        //    vend_details.Add(DataAccesHelper.vendCode, new string[] { DataAccesHelper.typeString, this.VendorCode });
        //    vend_details.Add(DataAccesHelper.vendName, new string[] { DataAccesHelper.typeString, this.Name });
        //    vend_details.Add(DataAccesHelper.vendAddressId, new string[] { DataAccesHelper.typeString, this.VendorAddress.AddressId });
        //    vend_details.Add(DataAccesHelper.vendContactId, new string[] { DataAccesHelper.typeString, this.VendorContact.ContactId });

        //    dh.runQuery(DataAccesHelper.targetVendor, DataAccesHelper.requestDelete, vend_details, DataAccesHelper.vendCode + " = '" + this.VendorCode + "'");
        //}

        public List<Vendor> GetAllVendors()
        {
            Datahandler dh = Datahandler.getData();
            List<Vendor> vends = new List<Vendor>();
            DataTable table = dh.readDataFromDB(DataAccesHelper.QueryGetVendors);

            foreach (DataRow item in table.Rows)
            {
                Vendor v = new Vendor();
                v.VendorCode = item[DataAccesHelper.vendCode].ToString();
                v.Name = item[DataAccesHelper.vendName].ToString();
                v.VendorAddress = new Address(item[DataAccesHelper.addressId].ToString(), item[DataAccesHelper.addrLine1].ToString(), item[DataAccesHelper.addrLine2].ToString(), item[DataAccesHelper.addrCity].ToString(), item[DataAccesHelper.addrPostalCode].ToString());
                v.VendorContact = new Contact(item[DataAccesHelper.contactId].ToString(), item[DataAccesHelper.contactCell].ToString(), item[DataAccesHelper.contactEmail].ToString());
                vends.Add(v);
            }

            return vends;
        }
    }
}
