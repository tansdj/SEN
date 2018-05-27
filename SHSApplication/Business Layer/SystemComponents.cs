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
        private string compSerial;
        private Product sysComps_product;
        private string description;
        private string status;
        private string manufacturer;
        private string model;

        public SystemComponents(string compSerial, Product sysComps_product, string description,string status, string manufacturer, string model)
        {
            this.CompSerial = compSerial;
            this.SysComps_Product = sysComps_product;
            this.Description = description;
            this.Status = status;
            this.Manufacturer = manufacturer;
            this.Model = model;
        }

        public SystemComponents()
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

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public Product SysComps_Product
        {
            get { return sysComps_product; }
            set { sysComps_product = value; }
        }


        public string CompSerial
        {
            get { return compSerial; }
            set { compSerial = value; }
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
            return (this.CompSerial==sc.CompSerial)&&(this.Description==sc.Description)&&(this.SysComps_Product==sc.SysComps_Product)&&(this.Status==sc.Status)&&(this.Manufacturer==sc.Manufacturer)&&(this.Model==sc.Model);
        }

        public override int GetHashCode()
        {
            return this.CompSerial.GetHashCode()^this.Description.GetHashCode()^this.SysComps_Product.GetHashCode()^this.Status.GetHashCode()^this.Manufacturer.GetHashCode()^this.Model.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool InsertComponent()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> sysComp_details = new Dictionary<string, string[]>();

            sysComp_details.Add(DataAccesHelper.compSerial, new string[] { DataAccesHelper.typeString, this.CompSerial });
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

            sysComp_details.Add(DataAccesHelper.compSerial, new string[] { DataAccesHelper.typeString, this.CompSerial });
            sysComp_details.Add(DataAccesHelper.compProdCode, new string[] { DataAccesHelper.typeString, this.SysComps_Product.ProductCode });
            sysComp_details.Add(DataAccesHelper.compDesc, new string[] { DataAccesHelper.typeString, this.Description });
            sysComp_details.Add(DataAccesHelper.compStatus, new string[] { DataAccesHelper.typeString, this.Status });
            sysComp_details.Add(DataAccesHelper.compManufacturer, new string[] { DataAccesHelper.typeString, this.Manufacturer });
            sysComp_details.Add(DataAccesHelper.compModel, new string[] { DataAccesHelper.typeString, this.Model });

            return dh.runQuery(DataAccesHelper.targetComponents, DataAccesHelper.requestUpdate, sysComp_details, DataAccesHelper.compSerial + " = '" + this.CompSerial + "'");
        }

        public List<SystemComponents> GetSystemComponents()
        {
            Datahandler dh = Datahandler.getData();
            List<SystemComponents> sysComps = new List<SystemComponents>();
            DataTable table = dh.readDataFromDB(DataAccesHelper.QueryGetSystemComponents+this.SysComps_Product.ProductCode);

            foreach (DataRow item in table.Rows)
            {
                SystemComponents sc = new SystemComponents();
                sc.CompSerial = item[DataAccesHelper.compSerial].ToString();
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

    }
}
