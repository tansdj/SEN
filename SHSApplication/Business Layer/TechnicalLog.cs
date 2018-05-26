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
    public class TechnicalLog
    {
        private RequestedEvents reqEvent;
        private Technicians tlTech;

        public TechnicalLog(RequestedEvents reqEvent, Technicians tlTech)
        {
            this.ReqEvent = reqEvent;
            this.TlTech = tlTech;
        }

        public TechnicalLog()
        {

        }

        public Technicians TlTech
        {
            get { return tlTech; }
            set { tlTech = value; }
        }


        public RequestedEvents ReqEvent
        {
            get { return reqEvent; }
            set { reqEvent = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            TechnicalLog tl = (TechnicalLog)obj;
            if ((object)tl==null)
            {
                return false;
            }
            return (this.ReqEvent==tl.ReqEvent)&&(this.TlTech==tl.TlTech);
        }

        public override int GetHashCode()
        {
            return this.ReqEvent.GetHashCode()^this.TlTech.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool LogEvent()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> event_details = new Dictionary<string, string[]>();

            event_details.Add(DataAccesHelper.tlEventId, new string[] { DataAccesHelper.typeInt, this.ReqEvent.EventId.ToString()});
            event_details.Add(DataAccesHelper.tlEventTechId, new string[] { DataAccesHelper.typeString, this.TlTech.PersonId.ToString()});
           

            return dh.runQuery(DataAccesHelper.targetTechEvents, DataAccesHelper.requestInsert, event_details);
        }

        public List<TechnicalLog> GetTechEvents(string techId = "")
        {
            Datahandler dh = Datahandler.getData();
            List<TechnicalLog> events = new List<TechnicalLog>();
            DataTable table = dh.readDataFromDB(DataAccesHelper.QueryGetTechEvents);

            foreach (DataRow item in table.Rows)
            {
                TechnicalLog tl = new TechnicalLog();
                tl.ReqEvent = new RequestedEvents();
                tl.ReqEvent.EventId = Convert.ToInt32(item[DataAccesHelper.tlEventId].ToString());
                tl.TlTech = new Technicians();
                tl.TlTech.PersonId = item[DataAccesHelper.tlEventTechId].ToString();
                events.Add(tl);
            }

            return events;
        }

    }
}
