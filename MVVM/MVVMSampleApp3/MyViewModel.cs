using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMSampleApp3
{
    public class MyViewModel : INotifyPropertyChanged
    {
        public string age;
        public string name;
        public List<Student> student;
        public List<Student> Students
        {
            get
            {
                return student;
            }
            set
            {
                SetProperty(ref student, value);
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Age
        {
            get
            {
                return age;
            }
        }

        public MyViewModel()
        {
            Students = new List<Student>();
            Students.Add(new Student() { age = "24", name = "Mark" });
            Students.Add(new Student() { age = "35", name = "Steve" });
            Students.Add(new Student() { age = "16", name = "Michael" });
            Students.Add(new Student() { age = "70", name = "Bill" });
            Students.Add(new Student() { age = "48", name = "Kelvin" });
        }

        public bool SetProperty(ref List<Student> storage, List<Student> value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            this.RaisePropertyChanged(propertyName);
            return true;
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
