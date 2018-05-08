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

        public Address(string addressId, string addressLine1, string addressLine2, string city)
        {
            this.AddressId = addressId;
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
            this.City = city;
        }

        public string AddressId
        {
            get { return addressId; }
            set { addressId = value; }
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
            if (obj==null)
            {
                return false;
            }

            Address a = obj as Address;
            if ((object)a==null)
            {
                return false;
            }
            return (this.AddressId==a.AddressId)&&(this.AddressLine1==a.AddressLine1)&&(this.AddressLine2==a.AddressLine2)&&(this.City==a.City);
        }

        public override int GetHashCode()
        {
            return this.AddressId.GetHashCode()^this.AddressLine1.GetHashCode()^this.AddressLine2.GetHashCode()^this.City.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void InsertAddress()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> addr_details = new Dictionary<string, string[]>();

            addr_details.Add(DataAccesHelper.addressId, new string[] { DataAccesHelper.typeString, this.AddressId });
            addr_details.Add(DataAccesHelper.addrLine1, new string[] { DataAccesHelper.typeString, this.AddressLine1 });
            addr_details.Add(DataAccesHelper.addrLine2, new string[] { DataAccesHelper.typeString, this.AddressLine2 });
            addr_details.Add(DataAccesHelper.addrCity, new string[] { DataAccesHelper.typeString, this.City });

            dh.runQuery(DataAccesHelper.targetAddress, DataAccesHelper.requestInsert, addr_details);
        }

        public void UpdateAddress()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> addr_details = new Dictionary<string, string[]>();

            addr_details.Add(DataAccesHelper.addressId, new string[] { DataAccesHelper.typeString, this.AddressId });
            addr_details.Add(DataAccesHelper.addrLine1, new string[] { DataAccesHelper.typeString, this.AddressLine1 });
            addr_details.Add(DataAccesHelper.addrLine2, new string[] { DataAccesHelper.typeString, this.AddressLine2 });
            addr_details.Add(DataAccesHelper.addrCity, new string[] { DataAccesHelper.typeString, this.City });

            dh.runQuery(DataAccesHelper.targetAddress, DataAccesHelper.requestUpdate, addr_details, DataAccesHelper.addressId + " = '" + this.AddressId + "'");
        }

        public void RemoveAddress()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> addr_details = new Dictionary<string, string[]>();

            addr_details.Add(DataAccesHelper.addressId, new string[] { DataAccesHelper.typeString, this.AddressId });
            addr_details.Add(DataAccesHelper.addrLine1, new string[] { DataAccesHelper.typeString, this.AddressLine1 });
            addr_details.Add(DataAccesHelper.addrLine2, new string[] { DataAccesHelper.typeString, this.AddressLine2 });
            addr_details.Add(DataAccesHelper.addrCity, new string[] { DataAccesHelper.typeString, this.City });

            dh.runQuery(DataAccesHelper.targetAddress, DataAccesHelper.requestDelete, addr_details, DataAccesHelper.addressId + " = '" + this.AddressId + "'");
        }

    }
}
