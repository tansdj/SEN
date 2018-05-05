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

        public ClientConfigurations(Client clientConfigurations_client, Configurations clientConfigurations_configuration)
        {
            this.ClientConfigurations_Client = clientConfigurations_client;
            this.ClientConfigurations_Configuration = clientConfigurations_configuration;
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
            if (obj==null)
            {
                return false;
            }

            ClientConfigurations cc = obj as ClientConfigurations;
            if ((object)cc==null)
            {
                return false;
            }
            return (this.ClientConfigurations_Client==cc.ClientConfigurations_Client)&&(this.ClientConfigurations_Configuration==cc.ClientConfigurations_Configuration);
        }

        public override int GetHashCode()
        {
            return this.ClientConfigurations_Client.GetHashCode()^this.ClientConfigurations_Configuration.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void addClientProductConfig() { }

        public void removeClientProductConfig() { }

    }
}
