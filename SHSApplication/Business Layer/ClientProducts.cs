﻿using System;
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

        public ClientProducts()
        {

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
