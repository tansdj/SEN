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
    public class RequestedEvents
    {
        private int eventId;
        private Client techLog_client;
        private DateTime requestedDate;
        private string remarks;
        private string status;
        private string skillRequired;
        private DateTime completedDate;
        private int scheduleOrder;

        public RequestedEvents(Client techLog_client, DateTime requestedDate, string status, string remarks, string skillRequired, DateTime completedDate, int eventId =0, int scheduleOrder=0)
        {
            this.EventId = eventId;
            this.TechLog_Client = techLog_client;
            this.RequestedDate = requestedDate;
            this.CompletedDate = completedDate;
            this.Remarks = remarks;
            this.Status = status;
            this.SkillRequired = skillRequired;
            this.ScheduleOrder = scheduleOrder;
        }
        public RequestedEvents(Client techLog_client, DateTime requestedDate, string status, string remarks, string skillRequired,  int eventId = 0, int scheduleOrder = 0)
        {
            this.EventId = eventId;
            this.TechLog_Client = techLog_client;
            this.RequestedDate = requestedDate;
            this.Remarks = remarks;
            this.Status = status;
            this.SkillRequired = skillRequired;
            this.ScheduleOrder = scheduleOrder;
        }

        public int ScheduleOrder
        { get {return scheduleOrder; }
          set {scheduleOrder = value; } }
        public DateTime CompletedDate
        {
            get { return completedDate; }
            set { completedDate = value; }
        }

        public RequestedEvents()
        {

        }
        public string SkillRequired
        {
            get { return skillRequired; }
            set { skillRequired = value.Trim(' '); }
        }

        public string Status
        {
            get { return status; }
            set { status = value.Trim(' '); }
        }


        public string Remarks
        {
            get { return remarks; }
            set { remarks = value.Trim(' '); }
        }


        public DateTime RequestedDate
        {
            get { return requestedDate; }
            set { requestedDate = value; }
        }

        public Client TechLog_Client
        {
            get { return techLog_client; }
            set { techLog_client = value; }
        }


        public int EventId
        {
            get { return eventId; }
            set { eventId = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            RequestedEvents tl = obj as RequestedEvents;
            if ((object)tl==null)
            {
                return false;
            }
            return (this.EventId==tl.EventId)&&(this.TechLog_Client==tl.TechLog_Client)&&(this.RequestedDate==tl.RequestedDate)&&(this.CompletedDate==tl.CompletedDate)&&(this.Status==tl.Status) &&(this.Remarks==tl.Remarks&&(this.SkillRequired==tl.SkillRequired));
        }

        public override int GetHashCode()
        {
            return this.EventId.GetHashCode()^this.TechLog_Client.GetHashCode()^this.RequestedDate.GetHashCode()^this.CompletedDate.GetHashCode()^this.Status.GetHashCode()^this.Remarks.GetHashCode()^this.SkillRequired.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}({1}):{2}",this.TechLog_Client.ClientIdentifier,this.RequestedDate.ToShortDateString(),this.SkillRequired);
        }

        public bool NewEvent()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> event_details = new Dictionary<string, string[]>();

            event_details.Add(DataAccesHelper.eventId, new string[] { DataAccesHelper.typeInt, this.EventId.ToString() });
            event_details.Add(DataAccesHelper.eventClientId, new string[] { DataAccesHelper.typeString, this.TechLog_Client.ClientIdentifier });
            event_details.Add(DataAccesHelper.eventReqDate, new string[] { DataAccesHelper.typeDateTime, this.RequestedDate.ToShortDateString() });
            if(this.CompletedDate.Year>=2018)event_details.Add(DataAccesHelper.eventCompDate, new string[] { DataAccesHelper.typeDateTime, this.CompletedDate.ToShortDateString() });
            event_details.Add(DataAccesHelper.eventRemarks, new string[] { DataAccesHelper.typeString, this.Remarks });
            event_details.Add(DataAccesHelper.eventStatus, new string[] { DataAccesHelper.typeString, this.Status });
            event_details.Add(DataAccesHelper.skillReq, new string[] { DataAccesHelper.typeString, this.SkillRequired });
            event_details.Add(DataAccesHelper.eventScheduleOrder, new string[] { DataAccesHelper.typeInt, this.ScheduleOrder.ToString() });

            return dh.runQuery(DataAccesHelper.targetRequestedEvents, DataAccesHelper.requestInsert, event_details);
        }

        public bool UpdateEvent()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> event_details = new Dictionary<string, string[]>();

            event_details.Add(DataAccesHelper.eventId, new string[] { DataAccesHelper.typeInt, this.EventId.ToString() });
            event_details.Add(DataAccesHelper.eventClientId, new string[] { DataAccesHelper.typeString, this.TechLog_Client.ClientIdentifier });
            event_details.Add(DataAccesHelper.eventReqDate, new string[] { DataAccesHelper.typeDateTime, this.RequestedDate.ToShortDateString() });
            if (this.CompletedDate.Year >= 2018) event_details.Add(DataAccesHelper.eventCompDate, new string[] { DataAccesHelper.typeDateTime, this.CompletedDate.ToShortDateString() });
            event_details.Add(DataAccesHelper.eventRemarks, new string[] { DataAccesHelper.typeString, this.Remarks });
            event_details.Add(DataAccesHelper.eventStatus, new string[] { DataAccesHelper.typeString, this.Status });
            event_details.Add(DataAccesHelper.skillReq, new string[] { DataAccesHelper.typeString, this.SkillRequired });
            event_details.Add(DataAccesHelper.eventScheduleOrder, new string[] { DataAccesHelper.typeInt, this.ScheduleOrder.ToString() });

            return dh.runQuery(DataAccesHelper.targetRequestedEvents, DataAccesHelper.requestUpdate, event_details,DataAccesHelper.eventId+" = "+this.EventId);
        }

        public bool RemoveEvent()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> event_details = new Dictionary<string, string[]>();

            event_details.Add(DataAccesHelper.eventId, new string[] { DataAccesHelper.typeInt, this.EventId.ToString() });
            event_details.Add(DataAccesHelper.eventClientId, new string[] { DataAccesHelper.typeString, this.TechLog_Client.ClientIdentifier });
            event_details.Add(DataAccesHelper.eventReqDate, new string[] { DataAccesHelper.typeDateTime, this.RequestedDate.ToShortDateString() });
            if (this.CompletedDate.Year >= 2018) event_details.Add(DataAccesHelper.eventCompDate, new string[] { DataAccesHelper.typeDateTime, this.CompletedDate.ToShortDateString() });
            event_details.Add(DataAccesHelper.eventRemarks, new string[] { DataAccesHelper.typeString, this.Remarks });
            event_details.Add(DataAccesHelper.eventStatus, new string[] { DataAccesHelper.typeString, this.Status });
            event_details.Add(DataAccesHelper.skillReq, new string[] { DataAccesHelper.typeString, this.SkillRequired });
            event_details.Add(DataAccesHelper.eventScheduleOrder, new string[] { DataAccesHelper.typeDateTime, this.ScheduleOrder.ToString() });

            return dh.runQuery(DataAccesHelper.targetRequestedEvents, DataAccesHelper.requestDelete, event_details, DataAccesHelper.eventId + " = " + this.EventId);
        }

        public List<RequestedEvents> GetRequestedEvents()
        {
            Datahandler dh = Datahandler.getData();
            List<RequestedEvents> events = new List<RequestedEvents>();
            DataTable table = dh.readDataFromDB(DataAccesHelper.QueryGetRequestedEvents);

            foreach (DataRow item in table.Rows)
            {
                RequestedEvents tl = new RequestedEvents();
                tl.EventId = Convert.ToInt32(item[DataAccesHelper.eventId].ToString());
                tl.TechLog_Client = new Client(item[DataAccesHelper.clientId].ToString(),item[DataAccesHelper.clientName].ToString(),item[DataAccesHelper.clientSurname].ToString(),new Address(),new Contact(),"","",item[DataAccesHelper.clientIdentifier].ToString());
                tl.RequestedDate = Convert.ToDateTime(item[DataAccesHelper.eventReqDate].ToString());
                try { tl.CompletedDate = Convert.ToDateTime(item[DataAccesHelper.eventCompDate].ToString()); } catch { }
                tl.Remarks = item[DataAccesHelper.eventRemarks].ToString();
                tl.SkillRequired = item[DataAccesHelper.skillReq].ToString();
                tl.Status = item[DataAccesHelper.eventStatus].ToString();
                tl.ScheduleOrder = Convert.ToInt32(item[DataAccesHelper.eventScheduleOrder].ToString());
                events.Add(tl);
            }

            return events;
        }



    }
}
