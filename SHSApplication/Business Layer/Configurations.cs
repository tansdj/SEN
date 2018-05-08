using Serverside.HelperLibraries;
using ServerSide;
using System;
using System.Collections.Generic;
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

        public Configurations(string configId, string name, string description, SystemComponents configuration_component, double addCost)
        {
            this.ConfigId = configId;
            this.Name = name;
            this.Description = description;
            this.Configuration_Component = configuration_component;
            this.AddCost = addCost;
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
            set { configId = value; }
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
            return (this.ConfigId==c.ConfigId)&&(this.Name==c.Name)&&(this.Description==c.Description)&&(this.Configuration_Component==c.Configuration_Component)&&(this.AddCost==c.AddCost);
        }

        public override int GetHashCode()
        {
            return this.ConfigId.GetHashCode()^this.Name.GetHashCode()^this.Description.GetHashCode()^this.Configuration_Component.GetHashCode()^this.AddCost.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void InsertConfig()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> conf_details = new Dictionary<string, string[]>();
            this.ConfigId = "CONFIG"+ this.Name.Substring(0,4).Replace(' ','#').ToUpper();

            conf_details.Add(DataAccesHelper.confCode, new string[] { DataAccesHelper.typeString, this.ConfigId});
            conf_details.Add(DataAccesHelper.confName, new string[] { DataAccesHelper.typeString, this.Name });
            conf_details.Add(DataAccesHelper.confDesc, new string[] { DataAccesHelper.typeString, this.Description });
            conf_details.Add(DataAccesHelper.confCompCode, new string[] { DataAccesHelper.typeString, this.Configuration_Component.CompCode });
            conf_details.Add(DataAccesHelper.confAddCost, new string[] { DataAccesHelper.typeDouble, this.AddCost.ToString() });

            dh.runQuery(DataAccesHelper.targetConfiguration, DataAccesHelper.requestInsert, conf_details);
        }

        public void UpdateConfig()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> conf_details = new Dictionary<string, string[]>();
            this.ConfigId = "CONFIG" + this.Name.Substring(0, 4).Replace(' ', '#').ToUpper();

            conf_details.Add(DataAccesHelper.confCode, new string[] { DataAccesHelper.typeString, this.ConfigId });
            conf_details.Add(DataAccesHelper.confName, new string[] { DataAccesHelper.typeString, this.Name });
            conf_details.Add(DataAccesHelper.confDesc, new string[] { DataAccesHelper.typeString, this.Description });
            conf_details.Add(DataAccesHelper.confCompCode, new string[] { DataAccesHelper.typeString, this.Configuration_Component.CompCode });
            conf_details.Add(DataAccesHelper.confAddCost, new string[] { DataAccesHelper.typeDouble, this.AddCost.ToString() });

            dh.runQuery(DataAccesHelper.targetConfiguration, DataAccesHelper.requestUpdate, conf_details,DataAccesHelper.confCode+" = '"+this.ConfigId+"'");
        }

        public void RemoveConfig()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> conf_details = new Dictionary<string, string[]>();
            this.ConfigId = "CONFIG" + this.Name.Substring(0, 4).Replace(' ', '#').ToUpper();

            conf_details.Add(DataAccesHelper.confCode, new string[] { DataAccesHelper.typeString, this.ConfigId });
            conf_details.Add(DataAccesHelper.confName, new string[] { DataAccesHelper.typeString, this.Name });
            conf_details.Add(DataAccesHelper.confDesc, new string[] { DataAccesHelper.typeString, this.Description });
            conf_details.Add(DataAccesHelper.confCompCode, new string[] { DataAccesHelper.typeString, this.Configuration_Component.CompCode });
            conf_details.Add(DataAccesHelper.confAddCost, new string[] { DataAccesHelper.typeDouble, this.AddCost.ToString() });

            dh.runQuery(DataAccesHelper.targetConfiguration, DataAccesHelper.requestDelete, conf_details, DataAccesHelper.confCode + " = '" + this.ConfigId + "'");
        }
    }
}
