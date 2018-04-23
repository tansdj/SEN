using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class ClientProducts
    {
        private string clientId;
        private string productCode;

        public ClientProducts()
        {

        }

        public string ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }


        public string ClientId
        {
            get { return clientId; }
            set { clientId = value; }
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

        public void addNewClientProduct() { }

        public void removeClientProduct() { }

    }
}
