using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class Product
    {
        private string productCode;
        private string name;
        private string description;
        private double basePrice;
        private string status;
        private string category;

        public Product()
        {

        }

        public string Category
        {
            get { return category; }
            set { category = value; }
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

        public void addProduct() { }

        public void upgradeProduct() { }

        public void discontinueProduct() { }

    }
}
