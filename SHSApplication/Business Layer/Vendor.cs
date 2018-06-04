using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerSide;
using Serverside.HelperLibraries;
using System.Data;
using ServerSide.HelperLibrabries;

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
            this.Name = name;
            this.VendorAddress = vendorAddress;
            this.VendorContact = vendorContact;
            this.VendorCode = vendorCode;
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
            set { name = value.Trim(' '); }
        }


        public string VendorCode
        {
            get { return vendorCode; }
            set { vendorCode = (value=="")? "VENDOR" + this.Name.Substring(0, 4).Replace(' ', '#').ToUpper():value.Trim(' '); }
        }

        public override string ToString()
        {
            return this.Name;
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

        public bool InsertVendor()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> vend_details = new Dictionary<string, string[]>();

            vend_details.Add(QueryBuilder.spAddVendor.sp_code, new string[] { DataAccesHelper.typeString, this.VendorCode });
            vend_details.Add(QueryBuilder.spAddVendor.sp_name, new string[] { DataAccesHelper.typeString, this.Name });
            vend_details.Add(QueryBuilder.spAddVendor.sp_addrLine1, new string[] { DataAccesHelper.typeString, this.VendorAddress.AddressLine1 });
            vend_details.Add(QueryBuilder.spAddVendor.sp_addrLine2, new string[] { DataAccesHelper.typeString, this.VendorAddress.AddressLine2 });
            vend_details.Add(QueryBuilder.spAddVendor.sp_city, new string[] { DataAccesHelper.typeString, this.VendorAddress.City });
            vend_details.Add(QueryBuilder.spAddVendor.sp_postCode, new string[] { DataAccesHelper.typeString, this.VendorAddress.PostalCode });
            vend_details.Add(QueryBuilder.spAddVendor.sp_cell, new string[] { DataAccesHelper.typeString, this.VendorContact.Cell });
            vend_details.Add(QueryBuilder.spAddVendor.sp_email, new string[] { DataAccesHelper.typeString, this.VendorContact.Email });

            return dh.runStoredProcedure(QueryBuilder.spAddVendor.sp, vend_details);

        }

        public bool UpdateVendor()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> vend_details = new Dictionary<string, string[]>();

            vend_details.Add(QueryBuilder.spUpdateVendor.sp_code, new string[] { DataAccesHelper.typeString, this.VendorCode });
            vend_details.Add(QueryBuilder.spUpdateVendor.sp_name, new string[] { DataAccesHelper.typeString, this.Name });
            vend_details.Add(QueryBuilder.spUpdateVendor.sp_addrLine1, new string[] { DataAccesHelper.typeString, this.VendorAddress.AddressLine1 });
            vend_details.Add(QueryBuilder.spUpdateVendor.sp_addrLine2, new string[] { DataAccesHelper.typeString, this.VendorAddress.AddressLine2 });
            vend_details.Add(QueryBuilder.spUpdateVendor.sp_city, new string[] { DataAccesHelper.typeString, this.VendorAddress.City });
            vend_details.Add(QueryBuilder.spUpdateVendor.sp_postCode, new string[] { DataAccesHelper.typeString, this.VendorAddress.PostalCode });
            vend_details.Add(QueryBuilder.spUpdateVendor.sp_cell, new string[] { DataAccesHelper.typeString, this.VendorContact.Cell });
            vend_details.Add(QueryBuilder.spUpdateVendor.sp_email, new string[] { DataAccesHelper.typeString, this.VendorContact.Email });

            return dh.runStoredProcedure(QueryBuilder.spUpdateVendor.sp, vend_details);
        }

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
