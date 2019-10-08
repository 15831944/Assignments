using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static List<People> CreatePeople()
        {
            // create a List type People
            List<People> people = new List<People>();

            People pp = new People();
            pp.addPeople(ref people, 24, "Mark", 15);
            pp.addPeople(ref people, 35, "Steve", 258);
            pp.addPeople(ref people, 24, "Michael", 999);
            pp.addPeople(ref people, 16, "Bill", 748);
            pp.addPeople(ref people, 70, "Kelvin", 456);
            pp.addPeople(ref people, 24, "Michae", 666);
            return people;
        }

        //init people
        static List<People> people = CreatePeople();

        static void Main(string[] args)
        {
            // init sort
            Sort<People> sort = new BubbleSort<People>(people);

            /* Sort By Age */
            sort.DoSort(People.CompareByPeopleAge);
            sort.DoSort(People.CompareByPeopleName);
        }
    }
}
