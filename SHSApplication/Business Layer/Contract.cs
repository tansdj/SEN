using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class Contract
    {
        private string contractIdentifier;
        private Client contractClient;
        private string serviceLevel;
        private DateTime dateOfIssue;
        private int termDuration;

        public Contract(string contractIdentifier, Client contractClient, string serviceLevel, DateTime dateOfIssue, int termDuration)
        {
            this.ContractIdentifier = contractIdentifier;
            this.ContractClient = contractClient;
            this.ServiceLevel = serviceLevel;
            this.DateOfIssue = dateOfIssue;
            this.TermDuration = termDuration;
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


        public string ServiceLevel
        {
            get { return serviceLevel; }
            set { serviceLevel = value; }
        }


        public Client ContractClient
        {
            get { return contractClient; }
            set { contractClient = value; }
        }


        public string ContractIdentifier
        {
            get { return contractIdentifier; }
            set { contractIdentifier = value; }
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
            return (this.ContractIdentifier==c.ContractIdentifier)&&(this.ContractClient==c.ContractClient)&&(this.ServiceLevel==c.ServiceLevel)&&(this.DateOfIssue==c.DateOfIssue)&&(this.TermDuration==c.TermDuration);
        }

        public override int GetHashCode()
        {
            return this.ContractIdentifier.GetHashCode()^this.ContractClient.GetHashCode()^this.ServiceLevel.GetHashCode()^this.DateOfIssue.GetHashCode()^this.TermDuration.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
