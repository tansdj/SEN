using Serverside.HelperLibraries;
using ServerSide;
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

        public ProductFunction(Product productFunc_product, string prodFunction)
        {
            this.ProductFunc_Product = productFunc_product;
            this.ProdFunction = prodFunction;
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
            if (obj==null)
            {
                return false;
            }

            ProductFunction pv = obj as ProductFunction;
            if ((object)pv==null)
            {
                return false;
            }
            return (this.ProductFunc_Product==pv.ProductFunc_Product)&&(this.ProdFunction==pv.ProdFunction);
        }

        public override int GetHashCode()
        {
            return this.ProductFunc_Product.GetHashCode()^this.ProdFunction.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void InsertFunction()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> prodFunc_details = new Dictionary<string, string[]>();

            prodFunc_details.Add(DataAccesHelper.pfProductCode, new string[] { DataAccesHelper.typeString, this.ProductFunc_Product.ProductCode });
            prodFunc_details.Add(DataAccesHelper.pfFunction, new string[] { DataAccesHelper.typeString, this.ProdFunction });

            dh.runQuery(DataAccesHelper.targetProductFunction, DataAccesHelper.requestInsert, prodFunc_details);
        }

        public void UpdateFunction()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> prodFunc_details = new Dictionary<string, string[]>();

            prodFunc_details.Add(DataAccesHelper.pfProductCode, new string[] { DataAccesHelper.typeString, this.ProductFunc_Product.ProductCode });
            prodFunc_details.Add(DataAccesHelper.pfFunction, new string[] { DataAccesHelper.typeString, this.ProdFunction });

            dh.runQuery(DataAccesHelper.targetProductFunction, DataAccesHelper.requestUpdate, prodFunc_details,DataAccesHelper.pfProductCode+" = '"+this.ProductFunc_Product.ProductCode+"'");
        }


        public void RemoveFunction()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> prodFunc_details = new Dictionary<string, string[]>();

            prodFunc_details.Add(DataAccesHelper.pfProductCode, new string[] { DataAccesHelper.typeString, this.ProductFunc_Product.ProductCode });
            prodFunc_details.Add(DataAccesHelper.pfFunction, new string[] { DataAccesHelper.typeString, this.ProdFunction });

            dh.runQuery(DataAccesHelper.targetProductFunction, DataAccesHelper.requestDelete, prodFunc_details, DataAccesHelper.pfProductCode + " = '" + this.ProductFunc_Product.ProductCode + "'");
        }
    }
}
