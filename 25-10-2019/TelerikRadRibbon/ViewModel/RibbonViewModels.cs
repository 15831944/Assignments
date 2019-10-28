using System.Collections.ObjectModel;
using Telerik;
using Telerik.Windows.Controls;

namespace TelerikRadRibbon.ViewModel
{
    public class RibbonViewModels : ViewModelBase
    {
        public ObservableCollection<TabViewModel> Tabs
        {
            get
            {
                var tabs = new ObservableCollection<TabViewModel>();
                for (int i = 1; i <= 5; i++)
                {
                    tabs.Add(new TabViewModel() { Text = "Tab " + i });
                }
                return tabs;
            }
        }
    }

    public class TabViewModel
    {
        public string Text { get; set; }
        public ObservableCollection<GroupViewModel> Groups
        {
            get
            {
                var groups = new ObservableCollection<GroupViewModel>();
                for(int i = 1; i <= 2; i++)
                {
                    groups.Add(new GroupViewModel() { Text = "Group " + i });
                }
                return groups;
            }
        }
    }

    public class GroupViewModel
    {
        public string Text { get; set; }
        public ObservableCollection<ButtonViewModel> Buttons
        {
            get
            {
                var buttons = new ObservableCollection<ButtonViewModel>();
                for (int i = 1; i <= 2; i++)
                {
                    buttons.Add(new ButtonViewModel() { Text = "Button " + i });
                }
                return buttons;
            }
        }
    }
    public class ButtonViewModel
    {
        public string Text { get; set; }
    }
}
