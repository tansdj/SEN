using Serverside.HelperLibraries;
using ServerSide;
using System;
using System.Collections.Generic;
using System.Data;
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
            set { prodFunction = value.Trim(' '); }
        }

        public ProductFunction()
        {

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
            return this.ProdFunction;
        }

        public bool InsertFunction()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> prodFunc_details = new Dictionary<string, string[]>();

            prodFunc_details.Add(DataAccesHelper.pfProductCode, new string[] { DataAccesHelper.typeString, this.ProductFunc_Product.ProductCode });
            prodFunc_details.Add(DataAccesHelper.pfFunction, new string[] { DataAccesHelper.typeString, this.ProdFunction });

            return dh.runQuery(DataAccesHelper.targetProductFunction, DataAccesHelper.requestInsert, prodFunc_details);
        }

        public bool UpdateFunction()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> prodFunc_details = new Dictionary<string, string[]>();

            prodFunc_details.Add(DataAccesHelper.pfProductCode, new string[] { DataAccesHelper.typeString, this.ProductFunc_Product.ProductCode });
            prodFunc_details.Add(DataAccesHelper.pfFunction, new string[] { DataAccesHelper.typeString, this.ProdFunction });

            return dh.runQuery(DataAccesHelper.targetProductFunction, DataAccesHelper.requestUpdate, prodFunc_details,DataAccesHelper.pfProductCode+" = '"+this.ProductFunc_Product.ProductCode+"'");
        }


        public bool RemoveFunction()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> prodFunc_details = new Dictionary<string, string[]>();

            prodFunc_details.Add(DataAccesHelper.pfProductCode, new string[] { DataAccesHelper.typeString, this.ProductFunc_Product.ProductCode });
            prodFunc_details.Add(DataAccesHelper.pfFunction, new string[] { DataAccesHelper.typeString, this.ProdFunction });

            return dh.runQuery(DataAccesHelper.targetProductFunction, DataAccesHelper.requestDelete, prodFunc_details, DataAccesHelper.pfProductCode + " = '" + this.ProductFunc_Product.ProductCode + "'");
        }

        public List<ProductFunction> GetAllProductFunctions()
        {
            Datahandler dh = Datahandler.getData();
            List<ProductFunction> prodFunc = new List<ProductFunction>();
            DataTable table = dh.readDataFromDB(DataAccesHelper.QueryGetProductFunction+this.ProductFunc_Product.ProductCode+"'");

            foreach (DataRow item in table.Rows)
            {
                ProductFunction pf = new ProductFunction();
                pf.ProductFunc_Product = new Product();
                pf.ProductFunc_Product.ProductCode = item[DataAccesHelper.pfProductCode].ToString();
                pf.ProdFunction = item[DataAccesHelper.pfFunction].ToString();
                prodFunc.Add(pf);
            }

            return prodFunc;
        }
    }
}
