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
            Vendor v = new Vendor("VENDORABC#", "ABC Stationer", new Address("ADDRESSVENDORABC#", "21 Riverside", "Downbern", "Pretoria"), new Contact("CONTACTVENDORABC#", "0798264300", "tansdj1@gmail.com"));
            v.UpdateVendor();
            Console.WriteLine(v.ToString());
        }
    }
}
