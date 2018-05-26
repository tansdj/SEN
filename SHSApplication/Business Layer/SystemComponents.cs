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

        public SystemComponents(string compCode, Product sysComps_product, string description,string status)
        {
            this.CompCode = compCode;
            this.SysComps_Product = sysComps_product;
            this.Description = description;
            this.Status = status;
        }

        public SystemComponents()
        {

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


        public string CompCode
        {
            get { return compCode; }
            set { compCode = (value==null)? "COMP" + this.Description.Substring(0, 6).Replace(' ', '#').ToUpper():value; }
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
            return (this.CompCode==sc.CompCode)&&(this.Description==sc.Description)&&(this.SysComps_Product==sc.SysComps_Product)&&(this.Status==sc.Status);
        }

        public override int GetHashCode()
        {
            return this.CompCode.GetHashCode()^this.Description.GetHashCode()^this.SysComps_Product.GetHashCode()^this.Status.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool InsertComponent()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> sysComp_details = new Dictionary<string, string[]>();

            sysComp_details.Add(DataAccesHelper.compCode, new string[] { DataAccesHelper.typeString, this.CompCode });
            sysComp_details.Add(DataAccesHelper.compProdSerial, new string[] { DataAccesHelper.typeString, this.SysComps_Product.ProductSerialNr });
            sysComp_details.Add(DataAccesHelper.compDesc, new string[] { DataAccesHelper.typeString, this.Description });
            sysComp_details.Add(DataAccesHelper.compStatus, new string[] { DataAccesHelper.typeString, this.Status });

            return dh.runQuery(DataAccesHelper.targetComponents, DataAccesHelper.requestInsert, sysComp_details);
        }

        public bool UpdateComponent()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> sysComp_details = new Dictionary<string, string[]>();

            sysComp_details.Add(DataAccesHelper.compCode, new string[] { DataAccesHelper.typeString, this.CompCode });
            sysComp_details.Add(DataAccesHelper.compProdSerial, new string[] { DataAccesHelper.typeString, this.SysComps_Product.ProductSerialNr });
            sysComp_details.Add(DataAccesHelper.compDesc, new string[] { DataAccesHelper.typeString, this.Description });
            sysComp_details.Add(DataAccesHelper.compStatus, new string[] { DataAccesHelper.typeString, this.Status });

            return dh.runQuery(DataAccesHelper.targetComponents, DataAccesHelper.requestUpdate, sysComp_details, DataAccesHelper.compCode + " = '" + this.CompCode + "'");
        }

        public List<SystemComponents> GetSystemComponents()
        {
            Datahandler dh = Datahandler.getData();
            List<SystemComponents> sysComps = new List<SystemComponents>();
            DataTable table = dh.readDataFromDB(DataAccesHelper.QueryGetSystemComponents+this.SysComps_Product.ProductSerialNr);

            foreach (DataRow item in table.Rows)
            {
                SystemComponents sc = new SystemComponents();
                sc.CompCode = item[DataAccesHelper.compCode].ToString();
                sc.Description = item[DataAccesHelper.compDesc].ToString();
                sc.SysComps_Product = new Product();
                sc.SysComps_Product.ProductSerialNr = item[DataAccesHelper.compProdSerial].ToString();
                sc.Status = item[DataAccesHelper.compStatus].ToString();
                sysComps.Add(sc);
            }

            return sysComps;
        }

    }
}
