using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSampleApp5
{
    public class Customer
    {
        public string CustomerName;
        public double Amount;
        public string Married;

        public Customer()
        {
            Customer obj = new Customer();
            obj.CustomerName = "Shiv";
            obj.Amount = 2000;
            obj.Married = "Married";
        }
    }
}
