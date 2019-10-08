using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class People
    {
        public int age { get; set; }
        public string name { get; set; }
        public int address { get; set; }
        public void addPeople(ref List<People> people, int age, string name, int address)
        {
            people.Add(new People() { age = age, name = name, address = address });
        }
        public static Sort<People>.CompareRet CompareByPeopleAge(People s1, People s2)
        {
            Sort<People>.CompareRet result = Sort<People>.CompareRet.kEQUAL;
            if (s1.age.CompareTo(s2.age) < Sort<People>.COMPARE_EQUAL_VAL)
            {
                result = Sort<People>.CompareRet.kLESSTHAN;
            }
            else if (s1.age.CompareTo(s2.age) > Sort<People>.COMPARE_EQUAL_VAL)
            {
                result = Sort<People>.CompareRet.kGREATER;
            }
            else
            {
                result = Sort<People>.CompareRet.kEQUAL;
            }
            return result;
        }

        public static Sort<People>.CompareRet CompareByPeopleAddress(People s1, People s2)
        {
            Sort<People>.CompareRet result = new Sort<People>.CompareRet { };
            if (s1.address.CompareTo(s2.address) < 0)
            {
                result = Sort<People>.CompareRet.kLESSTHAN;
            }
            else if (s1.address.CompareTo(s2.address) > 0)
            {
                result = Sort<People>.CompareRet.kGREATER;
            }
            else
            {
                result = Sort<People>.CompareRet.kEQUAL;
            }
            return result;
        }

        public static Sort<People>.CompareRet CompareByPeopleName(People s1, People s2)
        {
            Sort<People>.CompareRet result = new Sort<People>.CompareRet { };
            if (s1.name.CompareTo(s2.name) < 0)
            {
                result = Sort<People>.CompareRet.kLESSTHAN;
            }
            else if (s1.name.CompareTo(s2.name) > 0)
            {
                result = Sort<People>.CompareRet.kGREATER;
            }
            else
            {
                result = Sort<People>.CompareRet.kEQUAL;
            }
            return result;
        }

    }
}
