using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class ClientConfigurations
    {
        private Client clientConfigurations_client;
        private Configurations clientConfigurations_configuration;

        public ClientConfigurations()
        {
           
        }

        public Configurations ClientConfigurations_Configuration
        {
            get { return clientConfigurations_configuration; }
            set { clientConfigurations_configuration = value; }
        }

        public Client ClientConfigurations_Client
        {
            get { return clientConfigurations_client; }
            set { clientConfigurations_client = value; }
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

        public void addClientProductConfig() { }

        public void removeClientProductConfig() { }

    }
}
