using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
                new Student() { Name = "aaaaaa" },
                new Student() { Name = "bbbbb" },
                new Student() { Name = "aaaaaa" },
                new Student() { Name = "bbbbb" },
                new Student() { Name = "aaaaaa" },
                new Student() { Name = "bbbbb" }
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
