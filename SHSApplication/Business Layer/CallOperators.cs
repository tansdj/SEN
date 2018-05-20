using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class CallOperators:Person
    {
        private string operatorStatus;

        public CallOperators(string personId, string name, string surname, Address personAddress, Contact personContact,string operatorStatus):base(personId,name,surname,personAddress,personContact)
        {
            this.OperatorStatus = operatorStatus;
        }

        public CallOperators()
        {

        }
        public string OperatorStatus
        {
            get { return operatorStatus; }
            set { operatorStatus = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            CallOperators co = (CallOperators)obj;
            if ((object)co==null)
            {
                return false;
            }
            return base.Equals(obj)&&(this.OperatorStatus==co.OperatorStatus);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode()^this.OperatorStatus.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
