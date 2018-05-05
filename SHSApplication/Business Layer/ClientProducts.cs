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

        public void addNewClientProduct() { }

        public void removeClientProduct() { }

    }
}
