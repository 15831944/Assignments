using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WpfApp1.ViewModels;

namespace WpfApp1.Models
{
    public class Model {
        public ObservableCollection<Student> students = new ObservableCollection<Student>();
        public Model()
        {
            students = new ObservableCollection<Student>()
            {
                new Student() { Name = "9104402" },
                new Student() { Name = "8066499" },
                new Student() { Name = "5965308" },
                new Student() { Name = "9646411" },
                new Student() { Name = "222380" },
                new Student() { Name = "2986276" }
            };
        }
    }
    public class Student
    {   
        private string name;
      
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                }
            }
        }
    }
}
