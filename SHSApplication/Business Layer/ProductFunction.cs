using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class ProductFunction
    {
        private Product productFunc_product;
        private string prodFunction;

        public ProductFunction()
        {

        }

        public string ProdFunction
        {
            get { return prodFunction; }
            set { prodFunction = value; }
        }


        public Product ProductFunc_Product
        {
            get { return productFunc_product; }
            set { productFunc_product = value; }
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

        public void addFunction() { }

    }
}
