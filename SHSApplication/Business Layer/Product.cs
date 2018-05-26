using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerSide;
using Serverside.HelperLibraries;
using System.Data;

namespace SHSApplication.Business_Layer
{
    public class Product
    {
        private string productSerialNr;
        private string name;
        private string description;
        private double basePrice;
        private string status;
        private string manufacturer;
        private string model;

        public Product(string productSerialNr, string name, string description, double basePrice, string status, string manufacturer, string model)
        {
            this.ProductSerialNr = productSerialNr;
            this.Name = name;
            this.Description = description;
            this.BasePrice = basePrice;
            this.Status = status;
            this.Manufacturer = manufacturer;
            this.Model = model;
        }

        public Product()
        {

        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }


        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
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


        public string ProductSerialNr
        {
            get { return productSerialNr; }
            set { productSerialNr = value; }
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
            return (this.ProductSerialNr==p.ProductSerialNr)&&(this.Name==p.Name)&&(this.Description==p.Description)&&(this.BasePrice==p.BasePrice)&&(this.Status==p.Status)&&(this.Manufacturer==p.Manufacturer)&&(this.Model==p.Model);
        }

        public override int GetHashCode()
        {
            return this.ProductSerialNr.GetHashCode()^this.Name.GetHashCode()^this.Description.GetHashCode()^this.BasePrice.GetHashCode()^this.Status.GetHashCode()^this.Manufacturer.GetHashCode()^this.Model.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool InsertProduct()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> prod_details = new Dictionary<string, string[]>();

            prod_details.Add(DataAccesHelper.prodSerialNo, new string[] { DataAccesHelper.typeString, this.ProductSerialNr });
            prod_details.Add(DataAccesHelper.prodName, new string[] { DataAccesHelper.typeString, this.Name });
            prod_details.Add(DataAccesHelper.prodDesc, new string[] { DataAccesHelper.typeString, this.Description });
            prod_details.Add(DataAccesHelper.prodPrice, new string[] { DataAccesHelper.typeDouble, this.BasePrice.ToString() });
            prod_details.Add(DataAccesHelper.prodStatus, new string[] { DataAccesHelper.typeString, this.Status });

            return dh.runQuery(DataAccesHelper.targetProduct, DataAccesHelper.requestInsert, prod_details);
        }

        public bool UpdateProduct()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> prod_details = new Dictionary<string, string[]>();

            prod_details.Add(DataAccesHelper.prodSerialNo, new string[] { DataAccesHelper.typeString, this.ProductSerialNr });
            prod_details.Add(DataAccesHelper.prodName, new string[] { DataAccesHelper.typeString, this.Name });
            prod_details.Add(DataAccesHelper.prodDesc, new string[] { DataAccesHelper.typeString, this.Description });
            prod_details.Add(DataAccesHelper.prodPrice, new string[] { DataAccesHelper.typeDouble, this.BasePrice.ToString() });
            prod_details.Add(DataAccesHelper.prodStatus, new string[] { DataAccesHelper.typeString, this.Status });

            return dh.runQuery(DataAccesHelper.targetProduct, DataAccesHelper.requestUpdate, prod_details,DataAccesHelper.prodSerialNo+" = '"+this.ProductSerialNr+"'");
        }

        public List<Product> GetAllProducts(string serialCode="")
        {
            Datahandler dh = Datahandler.getData();
            List<Product> products = new List<Product>();
            DataTable table = new DataTable();
            if (serialCode!="")
            {
                table = dh.readDataFromDB(DataAccesHelper.QueryGetProducts+ " WHERE "+DataAccesHelper.prodSerialNo+" = '"+this.ProductSerialNr+"'");
            }
            else
            {
                table = dh.readDataFromDB(DataAccesHelper.QueryGetProducts);
            }

            foreach (DataRow item in table.Rows)
            {
                Product p = new Product();
                p.ProductSerialNr = item[DataAccesHelper.prodSerialNo].ToString();
                p.Name = item[DataAccesHelper.prodName].ToString();
                p.Description = item[DataAccesHelper.prodDesc].ToString();
                p.BasePrice = Convert.ToDouble(item[DataAccesHelper.prodPrice].ToString());
                p.Status = item[DataAccesHelper.prodStatus].ToString();
                products.Add(p);
            }

            return products;
        }
    }
}
