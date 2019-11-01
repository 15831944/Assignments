using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MVVMSampleApp3
{
    public class Student
    {
        public string age;
        public string name;

        public string Age
        {
            get
            {
                return age;
            }
            set
            {
                if (age != value)
                {
                    age = value;
                    //RaisePropertyChanged("Age");
                }
            }
        }

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
                    //RaisePropertyChanged("Name");
                }
            }
        }
    }
    public class MyViewModel : INotifyPropertyChanged
    {
        public List<Student> students = new List<Student>();
        public List<Student> Students
        {
            get
            {
                return students;
            }
            set
            {
                if (students != value)
                {
                    
                }
            }
        }
        public void LoadStudents()
        {
            List<Student> students = new List<Student>();

            students.Add(new Student() { age = "24", name = "Mark" });
            students.Add(new Student() { age = "35", name = "Steve" });
            students.Add(new Student() { age = "16", name = "Michael" });
            students.Add(new Student() { age = "70", name = "Bill" });
            students.Add(new Student() { age = "48", name = "Kelvin" });

            this.students = students;
        }

        public string age;
        public string name;

        public string Age
        {
            get
            {
                return age;
            }
            set
            {
                if (age != value)
                {
                    age = value;
                    RaisePropertyChanged("Age");
                }
            }
        }

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
                    RaisePropertyChanged("Name");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        
    }
}
