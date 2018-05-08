using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHSApplication.Business_Layer;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Vendor v = new Vendor("VENDORABC#", "ABC Stationer", new Address("ADDRESSVENDORABC#", "21 Riverside", "Downbern", "Pretoria"), new Contact("CONTACTVENDORABC#", "0798264300", "tansdj1@gmail.com"));
            //v.UpdateVendor();
            //Console.WriteLine(v.ToString());

            Client c = new Client("9711160103084", "Tanya", "de Jager", new Address("", "21 Riverside", "Downbern", "Pretoria"), new Contact("", "0798264300", "tansdj1@gmail.com"), "Self", "Active");
            //c.NewClient();
            //c.Surname = "De Jager";
            //c.PersonAddress.AddressLine2 = "Wallmantshal";
            //c.PersonContact.Email = "tansdj@gmail.com";
            //c.UpdateClient();
            //c.Status = "Inactive";
            //c.UpdateClient();
            List<Client> clients = new Client().GetAllClients();
            foreach (Client item in clients)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }
    }
}
