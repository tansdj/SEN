using SHSApplication.Business_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Helper_Libraries
{
    public static class Scheduler
    {
        public static void ScheduleEvents()
        {
            List<RequestedEvents> reqEvents = new RequestedEvents().GetRequestedEvents();
            Contract contractFirst;
            Contract contractSecond;
            foreach (RequestedEvents item in reqEvents)
            {
                if (item.Status=="Completed")
                {
                    reqEvents.Remove(item);
                }
                else
                {
                    item.RemoveEvent();
                }
            }
            RequestedEvents[] eventList = reqEvents.ToArray();
            int eventOrder = eventList[0].EventId;
            List<Contract> contracts;
            for (int i = 0; i < eventList.Count()-1; i++)
            {
                contracts = new Contract().GetAllContracts(eventList[i].TechLog_Client.ClientIdentifier);
                contractFirst = contracts[contracts.Count - 1];
                for (int k = i+1; k > 0; k--)
                {
                    contracts = new Contract().GetAllContracts(eventList[k].TechLog_Client.ClientIdentifier);
                    contractSecond = contracts[contracts.Count - 1];
                    RequestedEvents temp;

                    if (((contractSecond.SLevel.Level=="HIGH")&&(contractFirst.SLevel.Level=="STANDARD"||contractFirst.SLevel.Level=="LOW"))||((contractSecond.SLevel.Level=="STANDARD")&&(contractFirst.SLevel.Level=="LOW")))
                    {
                        temp = eventList[i];
                        eventList[i] = eventList[k];
                        eventList[k] = temp;
                    }
                    else if ((eventList[i].RequestedDate-eventList[k].RequestedDate).Days>7)
                    {
                        temp = eventList[i];
                        eventList[i] = eventList[k];
                        eventList[k] = temp;
                    }
                    
                }
            }
            foreach (RequestedEvents item in eventList)
            {
                item.ScheduleOrder = eventOrder;
                item.NewEvent();
                eventOrder++;
            }


        }
    }
}
