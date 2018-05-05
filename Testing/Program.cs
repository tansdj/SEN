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
            Vendor v = new Vendor("", "ABC Stationers", new Address("", "21 Riverside", "Wallmansthal", "Pretoria"), new Contact("", "0798264300", "tansdj@gmail.com"));
            v.InsertVendor();
            Console.WriteLine(v.ToString());
        }
    }
}
