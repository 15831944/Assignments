using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMSampleApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /* Example 5 Code */
        public ObservableCollection<User> users = new ObservableCollection<User>();
        /* Example 5 Code */
        public MainWindow()
        {
            InitializeComponent();
            /* Example 2 Code */
            //this.DataContext = this;
            /* Example 2 Code */

            /* Example 3 Code */
            //Binding binding = new Binding("Text");
            //binding.Source = txtValue;
            //lblValue.SetBinding(TextBlock.TextProperty, binding);
            /* Example 3 Code */

            /* Example 4 Code */
            //this.DataContext = this;
            /* Example 4 Code */

            /* Example 5 Code */
            users.Add(new User() { Name = "John Doe" });
            users.Add(new User() { Name = "Jane Doe" });

            lbUsers.ItemsSource = users;
            /* Example 5 Code */
        }



        /* Example 2 Code */
        //private void TbTitle_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    BindingExpression binding = tbTitle.GetBindingExpression(TextBox.TextProperty);
        //    binding.UpdateSource();
        //}
        /* Example 2 Code */

        /* Example 4 Code */
        //private void BtnUpdateSource_Click(object sender, RoutedEventArgs e)
        //{
        //    BindingExpression binding = txtWindowTitle.GetBindingExpression(TextBox.TextProperty);
        //    binding.UpdateSource();
        //}
        /* Example 4 Code */

        /* Example 5 Code */
        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            users.Add(new User() { Name = "New user" });
        }

        private void BtnChangeUser_Click(object sender, RoutedEventArgs e)
        {
            if (lbUsers.SelectedItem != null)
            {
                (lbUsers.SelectedItem as User).Name = "Random Name";
            }
        }

        private void BtnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (lbUsers.SelectedItem != null)
            {
                users.Remove(lbUsers.SelectedItem as User);
            }
        }
        /* Example 5 Code */
    }

    public class User : INotifyPropertyChanged
    {
        private string name;
        public string Name {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
