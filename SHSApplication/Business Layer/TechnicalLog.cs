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
        private Client techLog_client;
        private Technicians techLog_tech;
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


        public Technicians TechLog_Tech
        {
            get { return techLog_tech; }
            set { techLog_tech = value; }
        }


        public Client TechLog_Client
        {
            get { return techLog_client; }
            set { techLog_client = value; }
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
