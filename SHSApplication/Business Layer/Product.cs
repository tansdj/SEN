﻿using System;
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
        private string productCode;
        private string name;
        private string description;
        private double basePrice;
        private string status;

        public Product(string productCode, string name, string description, double basePrice, string status)
        {
            this.Name = name;
            this.Description = description;
            this.BasePrice = basePrice;
            this.Status = status;
            this.ProductCode = productCode;
        }

        public Product()
        {

        }

        
        public string Status
        {
            get { return status; }
            set { status = value.Trim(' '); }
        }


        public double BasePrice
        {
            get { return basePrice; }
            set { basePrice = value; }
        }


        public string Description
        {
            get { return description; }
            set { description = value.Trim(' '); }
        }


        public string Name
        {
            get { return name; }
            set { name = value.Trim(' '); }
        }


        public string ProductCode
        {
            get { return productCode; }
            set { productCode = (value == "") ? "PROD" + this.Name.Substring(0, 6).Replace(' ', '#').ToUpper() : value.Trim(' '); }
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
            return string.Format("{0}({1})",this.Name,this.ProductCode);
        }

        public bool InsertProduct()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> prod_details = new Dictionary<string, string[]>();

            prod_details.Add(DataAccesHelper.prodCode, new string[] { DataAccesHelper.typeString, this.ProductCode });
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

            prod_details.Add(DataAccesHelper.prodCode, new string[] { DataAccesHelper.typeString, this.ProductCode });
            prod_details.Add(DataAccesHelper.prodName, new string[] { DataAccesHelper.typeString, this.Name });
            prod_details.Add(DataAccesHelper.prodDesc, new string[] { DataAccesHelper.typeString, this.Description });
            prod_details.Add(DataAccesHelper.prodPrice, new string[] { DataAccesHelper.typeDouble, this.BasePrice.ToString() });
            prod_details.Add(DataAccesHelper.prodStatus, new string[] { DataAccesHelper.typeString, this.Status });

            return dh.runQuery(DataAccesHelper.targetProduct, DataAccesHelper.requestUpdate, prod_details,DataAccesHelper.prodCode+" = '"+this.ProductCode+"'");
        }

        public List<Product> GetAllProducts(string prodCode="")
        {
            Datahandler dh = Datahandler.getData();
            List<Product> products = new List<Product>();
            DataTable table = new DataTable();
            if (prodCode != "")
            {
                table = dh.readDataFromDB(DataAccesHelper.QueryGetProducts+ " WHERE "+DataAccesHelper.prodCode+" = '"+prodCode+"'");
            }
            else
            {
                table = dh.readDataFromDB(DataAccesHelper.QueryGetProducts);
            }

            foreach (DataRow item in table.Rows)
            {
                Product p = new Product();
                p.ProductCode = item[DataAccesHelper.prodCode].ToString();
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
