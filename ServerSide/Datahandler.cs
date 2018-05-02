using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHSApplication.Business_Layer;

namespace ServerSide
{
    public class Datahandler
    {
        public static Datahandler data = new Datahandler();
        private string connectionStringPrime;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter dataAdapter;
        private Datahandler(string connectionStringParam = "default")
        {
            connectionStringPrime = ConfigurationManager.ConnectionStrings[connectionStringParam].ConnectionString;
        }

        public static Datahandler getData()
        {
            return data;
        }

        public void NewClientWithPaymentDet(Client client,PaymentDetails payD) { }

        public void NewClientWithoutPaymentDet(Client client) { }

        public void UpdateClientWithPayDet(Client client,PaymentDetails payD) { }

        public void UpdateClientWithoutPayDet(Client client) { }

        public void NewProduct(Product product) { }

        public void UpdateProduct(Product product) { }

        public void NewComponent(SystemComponents comp) { }

        public void RemoveComponent(SystemComponents comp) { }

        public void NewConfig(Configurations config) { }

        public void UpdateConfig (Configurations config) { }

        public void RemoveConfig(Configurations config) { }

        public void NewTechnician(Technicians tech) { }

        public void UpdateTechnician(Technicians tech) { }

        public void NewTechDetail (TechnicalDetails td) { }

        public void RemoveTechDetail(TechnicalDetails td) { }

        public void LogTechEvent(TechnicalLog tl) { }

        public void NewClientProduct(ClientProducts cp) { }

        public void RemoveClientProduct (ClientProducts cp) { }

        public void NewClientCompConfig(ClientConfigurations cc) { }

        public void RemoveClientConfig (ClientConfigurations cc) { }
    }
}
