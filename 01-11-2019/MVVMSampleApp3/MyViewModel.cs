using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MVVMSampleApp3
{
    public class Student 
    {
        public string age;
        public string name;
        
    }
    public class MyViewModel : INotifyPropertyChanged
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
                    //updateStudent(name, value, "Age");
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
                    //updateStudent(name, value, "Name");
                    name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }
        public List<Student> students = new List<Student>();
        public List<Student> Students
        {
            get
            {
                return students;
            }
        }
        public void LoadStudents()
        {
            List<Student> students_ = new List<Student>();

            students_.Add(new Student() { age = "24", name = "Mark" });
            students_.Add(new Student() { age = "35", name = "Steve" });
            students_.Add(new Student() { age = "16", name = "Michael" });
            students_.Add(new Student() { age = "70", name = "Bill" });
            students_.Add(new Student() { age = "48", name = "Kelvin" });

            this.students = students_;
        }

        

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private void updateStudent(string val, string newval, string props)
        {
            for(int i = 0; i < students.Count; i++)
            {
                if (props == "Name")
                {
                    if (students[i].name == val)
                    {
                        students[i].name = newval;
                        break;
                    }
                }
                if (props == "Age")
                {
                    if (students[i].age == val)
                    {
                        students[i].age = newval;
                        break;
                    }
                }
            }
        }
    }
}
