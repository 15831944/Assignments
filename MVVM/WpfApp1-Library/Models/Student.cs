﻿using System;
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
                new Student() { Name = "9104402", Type = "int" },
                new Student() { Name = "robert", Type = "string" },
                new Student() { Name = "2.5", Type = "float" }
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

        private string type;
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                if (type != value)
                {
                    type = value;
                }
            }
        }
    }
}
