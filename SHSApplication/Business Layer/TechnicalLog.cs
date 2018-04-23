using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class TechnicalLog
    {
        private string eventId;
        private string clientId;
        private string techId;
        private DateTime date;
        private string remarks;

        public TechnicalLog()
        {

        }

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }


        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }


        public string TechId
        {
            get { return techId; }
            set { techId = value; }
        }


        public string ClientId
        {
            get { return clientId; }
            set { clientId = value; }
        }


        public string EventId
        {
            get { return eventId; }
            set { eventId = value; }
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

        public void logEvent() { }

    }
}
