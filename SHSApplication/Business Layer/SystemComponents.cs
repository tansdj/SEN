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
    public class SystemComponents
    {
        private string compCode;
        private Product sysComps_product;
        private string description;
        private string status;
        private string manufacturer;
        private string model;

        public SystemComponents(string compCode, Product sysComps_product, string description,string status, string manufacturer, string model)
        {
            this.SysComps_Product = sysComps_product;
            this.Description = description;
            this.Status = status;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.CompCode = compCode;
        }

        public SystemComponents()
        {

        }
        public SystemComponents(Product sysComps_product)
        {
            this.SysComps_Product = sysComps_product;
        }
        public string Model
        {
            get { return model; }
            set { model = value.Trim(' '); }
        }


        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value.Trim(' '); }
        }
        public string Status
        {
            get { return status; }
            set { status = value.Trim(' '); }
        }

        public string Description
        {
            get { return description; }
            set { description = value.Trim(' '); }
        }

        public Product SysComps_Product
        {
            get { return sysComps_product; }
            set { sysComps_product = value; }
        }


        public string CompCode
        {
            get { return compCode; }
            set { compCode = (value=="")?Manufacturer.Substring(0,4).ToUpper()+Model.Substring(0,4).ToUpper()+CountComponents().ToString():value.Trim(' '); }
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            SystemComponents sc = obj as SystemComponents;
            if ((object)sc==null)
            {
                return false;
            }
            return (this.CompCode==sc.CompCode)&&(this.Description==sc.Description)&&(this.SysComps_Product==sc.SysComps_Product)&&(this.Status==sc.Status)&&(this.Manufacturer==sc.Manufacturer)&&(this.Model==sc.Model);
        }

        public override int GetHashCode()
        {
            return this.CompCode.GetHashCode()^this.Description.GetHashCode()^this.Status.GetHashCode()^this.Manufacturer.GetHashCode()^this.Model.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}({1}) - {2}",this.Model,this.Manufacturer,this.CompCode);
        }

        public bool InsertComponent()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> sysComp_details = new Dictionary<string, string[]>();

            sysComp_details.Add(DataAccesHelper.compCode, new string[] { DataAccesHelper.typeString, this.CompCode });
            sysComp_details.Add(DataAccesHelper.compProdCode, new string[] { DataAccesHelper.typeString, this.SysComps_Product.ProductCode });
            sysComp_details.Add(DataAccesHelper.compDesc, new string[] { DataAccesHelper.typeString, this.Description });
            sysComp_details.Add(DataAccesHelper.compStatus, new string[] { DataAccesHelper.typeString, this.Status });
            sysComp_details.Add(DataAccesHelper.compManufacturer, new string[] { DataAccesHelper.typeString, this.Manufacturer });
            sysComp_details.Add(DataAccesHelper.compModel, new string[] { DataAccesHelper.typeString, this.Model });

            return dh.runQuery(DataAccesHelper.targetComponents, DataAccesHelper.requestInsert, sysComp_details);
        }

        public bool UpdateComponent()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> sysComp_details = new Dictionary<string, string[]>();

            sysComp_details.Add(DataAccesHelper.compCode, new string[] { DataAccesHelper.typeString, this.CompCode });
            sysComp_details.Add(DataAccesHelper.compProdCode, new string[] { DataAccesHelper.typeString, this.SysComps_Product.ProductCode });
            sysComp_details.Add(DataAccesHelper.compDesc, new string[] { DataAccesHelper.typeString, this.Description });
            sysComp_details.Add(DataAccesHelper.compStatus, new string[] { DataAccesHelper.typeString, this.Status });
            sysComp_details.Add(DataAccesHelper.compManufacturer, new string[] { DataAccesHelper.typeString, this.Manufacturer });
            sysComp_details.Add(DataAccesHelper.compModel, new string[] { DataAccesHelper.typeString, this.Model });

            return dh.runQuery(DataAccesHelper.targetComponents, DataAccesHelper.requestUpdate, sysComp_details, DataAccesHelper.compCode + " = '" + this.CompCode + "'");
        }

        public List<SystemComponents> GetSystemComponents()
        {
            Datahandler dh = Datahandler.getData();
            List<SystemComponents> sysComps = new List<SystemComponents>();
            DataTable table = dh.readDataFromDB(DataAccesHelper.QueryGetSystemComponents+this.SysComps_Product.ProductCode+"'");

            foreach (DataRow item in table.Rows)
            {
                SystemComponents sc = new SystemComponents();
                sc.CompCode = item[DataAccesHelper.compCode].ToString();
                sc.Description = item[DataAccesHelper.compDesc].ToString();
                sc.SysComps_Product = new Product();
                sc.SysComps_Product.ProductCode = item[DataAccesHelper.compProdCode].ToString();
                sc.Status = item[DataAccesHelper.compStatus].ToString();
                sc.Manufacturer = item[DataAccesHelper.compManufacturer].ToString();
                sc.Model = item[DataAccesHelper.compModel].ToString();
                sysComps.Add(sc);
            }

            return sysComps;
        }

        public int CountComponents()
        {
            Datahandler dh = Datahandler.getData();
            DataTable table = dh.readDataFromDB(DataAccesHelper.QueryCountComponents);
            int count = 0;

            foreach (DataRow item in table.Rows)
            {
                count = Convert.ToInt32(item["NrComponents"].ToString());
            }

            return count;
        }

    }
}
