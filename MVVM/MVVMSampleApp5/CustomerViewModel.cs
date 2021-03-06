﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSampleApp5
{
    public class CustomerViewModel
    {
        private Customer obj = new Customer();

        public string TxtCustomerName
        {
            get
            {
                return obj.CustomerName;
            }
            set
            {
                obj.CustomerName = value;
            }
        }

        public string TxtAmount
        {
            get
            {
                return Convert.ToString(obj.Amount);
            }
            set
            {
                obj.Amount = Convert.ToDouble(value);
            }
        }

        public string LblAmountColor
        {
            get
            {
                if (obj.Amount > 2000)
                {
                    return "Blue";
                }
                else if (obj.Amount > 1500)
                {
                    return "Red";
                }
                return "Yellow";
            }
        }

        public bool IsMarried
        {
            get
            {
                if (obj.Married == "Married")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
