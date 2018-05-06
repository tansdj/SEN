using ServerSide;
using SHSApplication.HelperLibraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class ClientProducts
    {
        private Client clientProducts_client;
        private Product clientProducts_product;

        public ClientProducts(Client clientProducts_client, Product clientProducts_product)
        {
            this.ClientProducts_Client = clientProducts_client;
            this.ClientProducts_Product = clientProducts_product;
        }

        public Product ClientProducts_Product
        {
            get { return clientProducts_product; }
            set { clientProducts_product = value; }
        }


        public Client ClientProducts_Client
        {
            get { return clientProducts_client; }
            set { clientProducts_client = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            ClientProducts cp = obj as ClientProducts;
            if ((object)cp==null)
            {
                return false;
            }
            return (this.ClientProducts_Client==cp.ClientProducts_Client)&&(this.ClientProducts_Product==cp.ClientProducts_Product);
        }

        public override int GetHashCode()
        {
            return this.ClientProducts_Client.GetHashCode()^this.ClientProducts_Product.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void InsertClientProduct()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> clientProd_details = new Dictionary<string, string[]>();

            clientProd_details.Add(DataAccesHelper.cpClientId, new string[] { DataAccesHelper.typeString, this.ClientProducts_Client.PersonId});
            clientProd_details.Add(DataAccesHelper.cpProductId, new string[] { DataAccesHelper.typeString, this.ClientProducts_Product.ProductCode });

            dh.runQuery(DataAccesHelper.targetClientProducts, DataAccesHelper.requestInsert, clientProd_details);
        }

        public void RemoveClientProduct()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> clientProd_details = new Dictionary<string, string[]>();

            clientProd_details.Add(DataAccesHelper.cpClientId, new string[] { DataAccesHelper.typeString, this.ClientProducts_Client.PersonId });
            clientProd_details.Add(DataAccesHelper.cpProductId, new string[] { DataAccesHelper.typeString, this.ClientProducts_Product.ProductCode });

            dh.runQuery(DataAccesHelper.targetClientProducts, DataAccesHelper.requestDelete, clientProd_details,DataAccesHelper.cpClientId+" = '"+this.ClientProducts_Client.PersonId+"' AND "+DataAccesHelper.cpProductId+" = '"+this.ClientProducts_Product.ProductCode+"'");
        }

    }
}
