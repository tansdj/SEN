﻿using Serverside.HelperLibraries;
using ServerSide;
using System;
using System.Collections.Generic;
using System.Data;
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

        public void InsertClientConfiguration()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> clientConf_details = new Dictionary<string, string[]>();

            clientConf_details.Add(DataAccesHelper.ccClientId, new string[] { DataAccesHelper.typeString, this.ClientConfigurations_Client.PersonId });
            clientConf_details.Add(DataAccesHelper.ccConfId, new string[] { DataAccesHelper.typeString, this.ClientConfigurations_Configuration.ConfigId });

            dh.runQuery(DataAccesHelper.targetClientConf, DataAccesHelper.requestInsert, clientConf_details);
        }

        public void RemoveClientConfiguration()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> clientConf_details = new Dictionary<string, string[]>();

            clientConf_details.Add(DataAccesHelper.ccClientId, new string[] { DataAccesHelper.typeString, this.ClientConfigurations_Client.PersonId });
            clientConf_details.Add(DataAccesHelper.ccConfId, new string[] { DataAccesHelper.typeString, this.ClientConfigurations_Configuration.ConfigId });

            dh.runQuery(DataAccesHelper.targetClientConf, DataAccesHelper.requestDelete, clientConf_details,DataAccesHelper.ccClientId+" = '"+this.ClientConfigurations_Client.PersonId+"' AND "+DataAccesHelper.ccConfId+" = '"+this.ClientConfigurations_Configuration.ConfigId+"'");
        }

        public List<ClientConfigurations> GetClientConfigurations()
        {
            Datahandler dh = Datahandler.getData();
            List<ClientConfigurations> clientConf = new List<ClientConfigurations>();
            DataTable table = dh.readDataFromDB(DataAccesHelper.QueryGetClientConfiguration+this.ClientConfigurations_Client.PersonId);

            foreach (DataRow item in table.Rows)
            {
                ClientConfigurations cf = new ClientConfigurations();
                cf.ClientConfigurations_Client = new Client();
                cf.ClientConfigurations_Client.PersonId = item[DataAccesHelper.ccClientId].ToString();
                cf.ClientConfigurations_Configuration = new Configurations();
                cf.ClientConfigurations_Configuration.ConfigId = item[DataAccesHelper.ccConfId].ToString();
                clientConf.Add(cf);
            }

            return clientConf;
        }
    }
}
