using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMSampleApp
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private int myVar;
        private String myString = "Some text from MainWindowViewModel";
            //Double
        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public string MyString
        {
            get { return myString; }
            set
            {
                myString = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region iCommand example
        private ICommand changeText;

        public ICommand ChangeText
            {
                get
                {
                    return changeText;
                }
                set
                {
                    changeText = value;
                }
            }

            public MainWindowViewModel()
            {
                changeText = new ChangeTextCommand { mwv = this };
            }
        #endregion
    }
}
