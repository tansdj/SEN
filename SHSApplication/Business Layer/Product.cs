using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerSide;

namespace SHSApplication.Business_Layer
{
    public class Product
    {
        private string productCode;
        private string name;
        private string description;
        private double basePrice;
        private string status;
        

        public Product(string productCode, string name, string description, double basePrice, string status)
        {
            this.ProductCode = productCode;
            this.Name = name;
            this.Description = description;
            this.BasePrice = basePrice;
            this.Status = status;
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }


        public double BasePrice
        {
            get { return basePrice; }
            set { basePrice = value; }
        }


        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public string ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            Product p = obj as Product;
            if ((object)p==null)
            {
                return false;
            }
            return (this.ProductCode==p.ProductCode)&&(this.Name==p.Name)&&(this.Description==p.Description)&&(this.BasePrice==p.BasePrice)&&(this.Status==p.Status);
        }

        public override int GetHashCode()
        {
            return this.ProductCode.GetHashCode()^this.Name.GetHashCode()^this.Description.GetHashCode()^this.BasePrice.GetHashCode()^this.Status.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void addProduct() { }

        public void upgradeProduct() { }

        public void discontinueProduct() { }

    }
}
