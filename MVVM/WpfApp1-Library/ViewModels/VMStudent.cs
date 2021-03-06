﻿
using Microsoft.TeamFoundation.MVVM;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace WpfApp1.ViewModels
{
    public class VMStudent
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

                    //Regex regex = new Regex("[^0-9]+");
                    //if (regex.IsMatch(value))
                    //{
                    //    if (value.Length > name.Length)
                    //    {
                    //        name = value.Substring(0, name.Length);
                    //        value = name;
                    //    }
                    //    MessageBox.Show("Giá trị vừa nhập không hợp lệ!");
                    //}
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

        private TextBox textbox;
        public TextBox Textbox
        {
            get
            { return this.textbox; }
            set
            {
                this.textbox = value;
            }
        }
        private ICommand mButtonCommand;

        public ICommand ExitCommand
        {
            get
            {
                if (mButtonCommand == null)
                {
                    //mButtonCommand = new RelayCommand(Action => ExitFunc(Textbox), predicate => CanTest());
                    mButtonCommand = new RelayCommand(TextBoxPress);
                }
                return mButtonCommand;
            }
        }

        private void TextBoxPress(object textbox) {
            TextBox clickedtextbox = textbox as TextBox;
            if (clickedtextbox != null)
            {
                clickedtextbox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }

        public void ExitFunc(TextBox textbox)
        {

            textbox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        }

        public bool CanTest()
        {
            return true;
        }
    }
}
