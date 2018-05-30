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
    public class ContractConfigurations
    {
        private Contract contractConfigurations_contract;
        private Configurations contractConfigurations_configuration;
        private string compSerial;

        public ContractConfigurations(Contract contractConfigurations_contract, Configurations clientConfigurations_configuration,string compSerial)
        {
            this.ContractConfigurations_Contract = contractConfigurations_contract;
            this.ContractConfigurations_Configuration = clientConfigurations_configuration;
            this.CompSerial = compSerial;
        }

        public ContractConfigurations()
        {

        }
        public string CompSerial
        {
            get { return compSerial; }
            set { compSerial = value; }
        }
        public Configurations ContractConfigurations_Configuration
        {
            get { return contractConfigurations_configuration; }
            set { contractConfigurations_configuration = value; }
        }

        public Contract ContractConfigurations_Contract
        {
            get { return contractConfigurations_contract; }
            set { contractConfigurations_contract = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            ContractConfigurations cc = obj as ContractConfigurations;
            if ((object)cc==null)
            {
                return false;
            }
            return (this.ContractConfigurations_Contract==cc.ContractConfigurations_Contract)&&(this.ContractConfigurations_Configuration==cc.ContractConfigurations_Configuration)&&(this.CompSerial==cc.CompSerial);
        }

        public override int GetHashCode()
        {
            return this.ContractConfigurations_Contract.GetHashCode()^this.ContractConfigurations_Configuration.GetHashCode()^this.CompSerial.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool InsertContractConfiguration()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> contractConf_details = new Dictionary<string, string[]>();

            contractConf_details.Add(DataAccesHelper.ccContractId, new string[] { DataAccesHelper.typeString, this.ContractConfigurations_Contract.ContractIdentifier });
            contractConf_details.Add(DataAccesHelper.ccConfId, new string[] { DataAccesHelper.typeString, this.ContractConfigurations_Configuration.ConfigId });
            contractConf_details.Add(DataAccesHelper.ccCompSerial, new string[] { DataAccesHelper.typeString, this.CompSerial });

            return dh.runQuery(DataAccesHelper.targetContractConf, DataAccesHelper.requestInsert, contractConf_details);
        }

        public bool RemoveContractConfiguration()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> clientConf_details = new Dictionary<string, string[]>();

            clientConf_details.Add(DataAccesHelper.ccContractId, new string[] { DataAccesHelper.typeString, this.ContractConfigurations_Contract.ContractIdentifier });
            clientConf_details.Add(DataAccesHelper.ccConfId, new string[] { DataAccesHelper.typeString, this.ContractConfigurations_Configuration.ConfigId });
            clientConf_details.Add(DataAccesHelper.ccCompSerial, new string[] { DataAccesHelper.typeString, this.CompSerial });

            return dh.runQuery(DataAccesHelper.targetContractConf, DataAccesHelper.requestDelete, clientConf_details,DataAccesHelper.ccContractId + " = '"+this.ContractConfigurations_Contract.ContractIdentifier + "' AND "+DataAccesHelper.ccConfId+" = '"+this.ContractConfigurations_Configuration.ConfigId+"'");
        }

        public List<ContractConfigurations> GetContractConfigurations()
        {
            Datahandler dh = Datahandler.getData();
            List<ContractConfigurations> contractConf = new List<ContractConfigurations>();
            DataTable table = dh.readDataFromDB(DataAccesHelper.QueryGetContractConfiguration+this.ContractConfigurations_Contract.ContractIdentifier+"'");

            foreach (DataRow item in table.Rows)
            {
                ContractConfigurations cf = new ContractConfigurations();
                cf.ContractConfigurations_Contract = new Contract();
                cf.ContractConfigurations_Contract.ContractIdentifier = item[DataAccesHelper.ccContractId].ToString();
                cf.ContractConfigurations_Configuration = new Configurations(item[DataAccesHelper.ccConfId].ToString(),item[DataAccesHelper.confName].ToString(),item[DataAccesHelper.confDesc].ToString(),new SystemComponents(item[DataAccesHelper.confCompCode].ToString(),null,"","","",""),Convert.ToDouble(item[DataAccesHelper.confAddCost].ToString()),item[DataAccesHelper.compStatus].ToString());
                cf.CompSerial = item[DataAccesHelper.ccCompSerial].ToString();
                contractConf.Add(cf);
            }

            return contractConf;
        }
    }
}
