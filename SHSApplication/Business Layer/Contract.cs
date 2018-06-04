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
    public class Contract
    {
        private string contractIdentifier;
        private Client contractClient;
        private ServiceLevel sLevel;
        private DateTime dateOfIssue;
        private int termDuration;

        public Contract(string contractIdentifier, Client contractClient, ServiceLevel sLevel, DateTime dateOfIssue, int termDuration)
        {
            this.ContractClient = contractClient;
            this.SLevel = sLevel;
            this.DateOfIssue = dateOfIssue;
            this.TermDuration = termDuration;
            this.ContractIdentifier = contractIdentifier;
        }

        public Contract()
        {

        }

        public int TermDuration
        {
            get { return termDuration; }
            set { termDuration = value; }
        }


        public DateTime DateOfIssue
        {
            get { return dateOfIssue; }
            set { dateOfIssue = value; }
        }


        public ServiceLevel SLevel
        {
            get { return sLevel; }
            set { sLevel = value; }
        }


        public Client ContractClient
        {
            get { return contractClient; }
            set { contractClient = value; }
        }


        public string ContractIdentifier
        {
            get { return contractIdentifier; }
            set { contractIdentifier = (value=="")?CalculateContractId():value.Trim(' '); }
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            Contract c = (Contract)obj;
            if ((object)c==null)
            {
                return false;
            }
            return (this.ContractIdentifier==c.ContractIdentifier)&&(this.ContractClient==c.ContractClient)&&(this.SLevel==c.SLevel)&&(this.DateOfIssue==c.DateOfIssue)&&(this.TermDuration==c.TermDuration);
        }

        public override int GetHashCode()
        {
            return this.ContractIdentifier.GetHashCode()^this.ContractClient.GetHashCode()^this.SLevel.GetHashCode()^this.DateOfIssue.GetHashCode()^this.TermDuration.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        private string CalculateContractId()
        {
            string id = "";
            int contracts = CountContracts();
            id += DateTime.UtcNow.Year.ToString();
            switch (this.TermDuration)
            {
                case 0:id += "A";break;//Represents a once - off purchase
                case 1:id += "B";break;//Represents a 6 month contract
                case 2:id += "C";break;//Represents a 1 year contract
                case 3:id += "D";break;//Represents a 2 year contract
                case 4:id += "E";break;//Represents a 5 year contract
                case 5:id += "F";break;//Represents a custom length contract
                default:
                    break;
            }
            switch (this.SLevel.Level)
            {
                case "LOW":id += "L";break;
                case "STANDARD":id += "S";break;
                case "HIGH":id += "H";break;
                default:
                    break;
            }
            for (int i = 0; i < 6- contracts.ToString().Length; i++)
            {
                id += "0";
            }
            id += contracts.ToString();
            return id;
        }

        private int CountContracts()
        {
            int count = 0;
            Datahandler dh = Datahandler.getData();
            DataTable table = dh.readDataFromDB(DataAccesHelper.QueryCountContracts);

            foreach (DataRow item in table.Rows)
            {
                count = Convert.ToInt32(item["NrContracts"].ToString());
            }
            return count;
        }

        public bool InsertContract()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> contract_details = new Dictionary<string, string[]>();

            contract_details.Add(DataAccesHelper.contractId, new string[] { DataAccesHelper.typeString, this.ContractIdentifier });
            contract_details.Add(DataAccesHelper.contractClient, new string[] { DataAccesHelper.typeString, this.ContractClient.ClientIdentifier });
            contract_details.Add(DataAccesHelper.contractServiceLevel, new string[] { DataAccesHelper.typeString, this.SLevel.Level });
            contract_details.Add(DataAccesHelper.contractIssueDate, new string[] { DataAccesHelper.typeDateTime, this.DateOfIssue.ToShortDateString() });
            contract_details.Add(DataAccesHelper.contractTermDur, new string[] { DataAccesHelper.typeInt, this.TermDuration.ToString() });

            return dh.runQuery(DataAccesHelper.targetContract, DataAccesHelper.requestInsert, contract_details);
        }

        public bool UpdateContract()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> contract_details = new Dictionary<string, string[]>();

            contract_details.Add(DataAccesHelper.contractClient, new string[] { DataAccesHelper.typeString, this.ContractClient.ClientIdentifier });
            contract_details.Add(DataAccesHelper.contractServiceLevel, new string[] { DataAccesHelper.typeString, this.SLevel.Level });
            contract_details.Add(DataAccesHelper.contractIssueDate, new string[] { DataAccesHelper.typeDateTime, this.DateOfIssue.ToShortDateString() });
            contract_details.Add(DataAccesHelper.contractTermDur, new string[] { DataAccesHelper.typeInt, this.TermDuration.ToString() });

            return dh.runQuery(DataAccesHelper.targetContract, DataAccesHelper.requestUpdate, contract_details,DataAccesHelper.contractId+" = '"+this.ContractIdentifier+"'");
        }

        public List<Contract> GetAllContracts(string clientId="")
        {
            Datahandler dh = Datahandler.getData();
            List<Contract> contracts = new List<Contract>();
            DataTable table = new DataTable();
            if (clientId!="")
            {
                table = dh.readDataFromDB(DataAccesHelper.QueryGetContracts+ " WHERE "+DataAccesHelper.contractClient+" = '"+clientId+"'");
            }
            else
            {
                table = dh.readDataFromDB(DataAccesHelper.QueryGetContracts);
            }

            foreach (DataRow item in table.Rows)
            {
                Contract c = new Contract();
                c.ContractIdentifier = item[DataAccesHelper.contractId].ToString();
                c.ContractClient = new Client("", "", "", null, null, "", "", item[DataAccesHelper.contractClient].ToString());
                c.SLevel = new ServiceLevel(item[DataAccesHelper.contractServiceLevel].ToString());
                c.DateOfIssue = Convert.ToDateTime(item[DataAccesHelper.contractIssueDate].ToString());
                c.TermDuration = Convert.ToInt32(item[DataAccesHelper.contractTermDur].ToString());
                contracts.Add(c);
            }

            return contracts;
        }

    }
}
