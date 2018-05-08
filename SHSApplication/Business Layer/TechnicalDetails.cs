using Serverside.HelperLibraries;
using ServerSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class TechnicalDetails
    {
        private int detailId;
        private Configurations techDet_config;
        private string docPath;

        public TechnicalDetails(int detailId, Configurations techDet_config, string docPath)
        {
            this.DetailId = detailId;
            this.TechDet_Config = techDet_config;
            this.DocPath = docPath;
        }

        public string DocPath
        {
            get { return docPath; }
            set { docPath = value; }
        }


        public Configurations TechDet_Config
        {
            get { return techDet_config; }
            set { techDet_config = value; }
        }


        public int DetailId
        {
            get { return detailId; }
            set { detailId = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            TechnicalDetails td = obj as TechnicalDetails;
            if ((object)td==null)
            {
                return false;
            }
            return (this.DetailId==td.DetailId)&&(this.TechDet_Config==td.TechDet_Config)&&(this.DocPath==td.DocPath);
        }

        public override int GetHashCode()
        {
            return this.DetailId.GetHashCode()^this.TechDet_Config.GetHashCode()^this.DocPath.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void InsertDetail()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> tecDet_details = new Dictionary<string, string[]>();

            tecDet_details.Add(DataAccesHelper.tecDetId, new string[] { DataAccesHelper.typeInt, this.DetailId.ToString() });
            tecDet_details.Add(DataAccesHelper.tecDetConfCode, new string[] { DataAccesHelper.typeString, this.TechDet_Config.ConfigId });
            tecDet_details.Add(DataAccesHelper.tecDetDocPath, new string[] { DataAccesHelper.typeString, this.DocPath });

            dh.runQuery(DataAccesHelper.targetTechDetail, DataAccesHelper.requestInsert, tecDet_details);
        }

        public void RemoveDetail()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> tecDet_details = new Dictionary<string, string[]>();

            tecDet_details.Add(DataAccesHelper.tecDetId, new string[] { DataAccesHelper.typeInt, this.DetailId.ToString() });
            tecDet_details.Add(DataAccesHelper.tecDetConfCode, new string[] { DataAccesHelper.typeString, this.TechDet_Config.ConfigId });
            tecDet_details.Add(DataAccesHelper.tecDetDocPath, new string[] { DataAccesHelper.typeString, this.DocPath });

            dh.runQuery(DataAccesHelper.targetTechDetail, DataAccesHelper.requestDelete, tecDet_details,DataAccesHelper.tecDetId+" = "+this.DetailId);
        }
    }
}
