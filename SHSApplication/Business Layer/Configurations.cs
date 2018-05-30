using Serverside.HelperLibraries;
using ServerSide;
using ServerSide.HelperLibrabries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class Configurations
    {

        private string configId;
        private string name;
        private string description;
        private SystemComponents configuration_component;
        private double addCost;
        private string status;

        public Configurations(string configId, string name, string description, SystemComponents configuration_component, double addCost,string status)
        {
            this.Name = name;
            this.Description = description;
            this.Configuration_Component = configuration_component;
            this.AddCost = addCost;
            this.ConfigId = configId;
            this.Status = status;
        }

        public Configurations()
        {

        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public double AddCost
        {
            get { return addCost; }
            set { addCost = value; }
        }


        public SystemComponents Configuration_Component
        {
            get { return configuration_component; }
            set { configuration_component = value; }
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


        public string ConfigId
        {
            get { return configId; }
            set { configId = (value==null) ? "CONFIG" + this.Name.Substring(0, 4).Replace(' ', '#').ToUpper():value; }
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            Configurations c = obj as Configurations;
            if ((object)c==null)
            {
                return false;
            }
            return (this.ConfigId==c.ConfigId)&&(this.Name==c.Name)&&(this.Description==c.Description)&&(this.Configuration_Component==c.Configuration_Component)&&(this.AddCost==c.AddCost)&&(this.Status==c.Status);
        }

        public override int GetHashCode()
        {
            return this.ConfigId.GetHashCode()^this.Name.GetHashCode()^this.Description.GetHashCode()^this.Configuration_Component.GetHashCode()^this.AddCost.GetHashCode()^this.Status.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool InsertConfig()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> conf_details = new Dictionary<string, string[]>();

            conf_details.Add(DataAccesHelper.confCode, new string[] { DataAccesHelper.typeString, this.ConfigId});
            conf_details.Add(DataAccesHelper.confName, new string[] { DataAccesHelper.typeString, this.Name });
            conf_details.Add(DataAccesHelper.confDesc, new string[] { DataAccesHelper.typeString, this.Description });
            conf_details.Add(DataAccesHelper.confCompCode, new string[] { DataAccesHelper.typeString, this.Configuration_Component.CompCode });
            conf_details.Add(DataAccesHelper.confAddCost, new string[] { DataAccesHelper.typeDouble, this.AddCost.ToString() });
            conf_details.Add(DataAccesHelper.confStatus, new string[] { DataAccesHelper.typeString, this.Status.ToString() });

            return dh.runQuery(DataAccesHelper.targetConfiguration, DataAccesHelper.requestInsert, conf_details);
        }

        public bool UpdateConfig()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> conf_details = new Dictionary<string, string[]>();

            conf_details.Add(DataAccesHelper.confCode, new string[] { DataAccesHelper.typeString, this.ConfigId });
            conf_details.Add(DataAccesHelper.confName, new string[] { DataAccesHelper.typeString, this.Name });
            conf_details.Add(DataAccesHelper.confDesc, new string[] { DataAccesHelper.typeString, this.Description });
            conf_details.Add(DataAccesHelper.confCompCode, new string[] { DataAccesHelper.typeString, this.Configuration_Component.CompCode });
            conf_details.Add(DataAccesHelper.confAddCost, new string[] { DataAccesHelper.typeDouble, this.AddCost.ToString() });
            conf_details.Add(DataAccesHelper.confStatus, new string[] { DataAccesHelper.typeString, this.Status.ToString() });

            return dh.runQuery(DataAccesHelper.targetConfiguration, DataAccesHelper.requestUpdate, conf_details,DataAccesHelper.confCode+" = '"+this.ConfigId+"'");
        }

        public List<Configurations> GetAllConfigurations()
        {
            Datahandler dh = Datahandler.getData();
            List<Configurations> confs = new List<Configurations>();
            DataTable table = dh.readDataFromDB(DataAccesHelper.QueryGetConfigurations+ this.Configuration_Component.CompCode+"'");

            foreach (DataRow item in table.Rows)
            {
                Configurations c = new Configurations();
                c.ConfigId = item[DataAccesHelper.confCode].ToString();
                c.Name = item[DataAccesHelper.confName].ToString();
                c.Description = item[DataAccesHelper.confDesc].ToString();
                c.AddCost = Convert.ToDouble(item[DataAccesHelper.confAddCost].ToString());
                c.Configuration_Component = new SystemComponents();
                c.Configuration_Component.CompCode = item[DataAccesHelper.confCompCode].ToString();
                c.Status = item[DataAccesHelper.confStatus].ToString();
                confs.Add(c);
            }

            return confs;
        }
    }
}
