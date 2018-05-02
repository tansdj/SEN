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

        public Configurations()
        {

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
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void newConfig() { }

        public void updateConfig() { }

        public void removeConfig() { }
    }
}
