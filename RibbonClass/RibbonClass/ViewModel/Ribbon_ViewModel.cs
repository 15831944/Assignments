using RibbonClass.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.RibbonView;
using Label = Telerik.Windows.Controls.Label;

namespace RibbonClass.ViewModel
{
    public class Ribbon_ViewModel
    {
        static string PathImage = "\\res\\";
        static string binDebug = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
        public RadRibbonView InitRibbonView()
        {
            
            ViewModel.RibbonTab_ViewModel ribbonTab_ViewModel = new ViewModel.RibbonTab_ViewModel();
            ribbonTab_ViewModel.ReadXML();
            //ribbonTab_ViewModel.ConverToTelerik();
            ObservableCollection<RibbonTabCustom> Obc_Tab = ribbonTab_ViewModel._ribbonTabs;
            RadRibbonView ribbonView = new RadRibbonView() { };
            InitRibbonTab(Obc_Tab,ref ribbonView);
            return ribbonView;
        }
        public void InitRibbonTab(ObservableCollection<RibbonTabCustom> TabData, ref RadRibbonView ribbonView)
        {
            foreach (RibbonTabCustom tab in TabData)
            {
                RadRibbonTab tab_t = new RadRibbonTab()
                {
                    Header = tab.Title
                };
                InitRibbonGroups(tab.ribbonPanelCustoms, ref tab_t);
                ribbonView.Items.Add(tab_t);
            }
        }
        public void InitRibbonGroups(ObservableCollection<RibbonPanelCustom> GroupData, ref RadRibbonTab tab)
        {
            ObservableCollection<RadRibbonGroup> ribbonGroup = new ObservableCollection<RadRibbonGroup>();
            foreach (RibbonPanelCustom group in GroupData)
            {
                RadRibbonGroup group_t = new RadRibbonGroup()
                {
                    Header = group.RibbonPanelSourceCustom.Title
                };
                InitRibbonItems(group.RibbonPanelSourceCustom.RibbonItemsCustom,ref group_t);
                tab.Items.Add(group_t);
            }
        }
        //enum point {head };
        public void InitRibbonItems(ObservableCollection<RibbonItemCustom> ItemData,ref RadRibbonGroup group)
        {
            ObservableCollection<object> ribbonItems = new ObservableCollection<object>();
            StackPanel stackRow1 = new StackPanel() { Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Top };
            StackPanel stackRow2 = new StackPanel() { Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Top };
            int itemcount = ItemData.Count;
            if (itemcount <= 4)
            {
                group.Items.Add(LoopItemlist(ItemData, 0, itemcount));
            }
            else
            {
                StackPanel stack = new StackPanel() { Orientation=Orientation.Vertical };
                stack.Children.Add(LoopItemlist(ItemData, 0 , itemcount / 2));
                stack.Children.Add(LoopItemlist(ItemData, itemcount / 2, itemcount));
                group.Items.Add(stack);
            }
            //group.Items.Add(stackRow1);
        }
        public StackPanel LoopItemlist(ObservableCollection<RibbonItemCustom> ItemData ,int start , int end)
        {
            StackPanel stackpanel = new StackPanel() {Orientation = Orientation.Horizontal };
            for(int i=start ; i < end ; i++)
            {
                String Id = ItemData[i].Id;
                String ToolTip = ItemData[i].ToolTip;
                String text = ItemData[i].Text;
                String ImagePath = ItemData[i].ImagePath;
                Boolean ExternalImage = ItemData[i].ExternalImage;
                Boolean IsVisible = ItemData[i].IsVisible;
                Boolean IsInitialized = ItemData[i].IsInitialized;
                String Image = ItemData[i].Image;
                String LargeImage = ItemData[i].LargeImage;
                int width = ItemData[i].Width;
                int height = ItemData[i].Height;
                Boolean IsEnabled = ItemData[i].IsEnabled;
                String Size = ItemData[i].Size;
                ButtonSize size;
                switch (Size)
                {
                    case "Small":
                        size = ButtonSize.Small;
                        break;
                    case "Large":
                        size = ButtonSize.Large;
                        break;
                    default:
                        size = ButtonSize.Medium;
                        break;
                }
                String Type = ItemData[i].ItemType;
                Boolean IsAutoSize = ItemData[i].ExternalImage;
                Image image = new Image();
                try
                {
                    image.Source = new BitmapImage(new Uri(binDebug + PathImage + ItemData[i].Image));
                }
                catch { }
                Image largeImage = new Image();
                try
                {
                    largeImage.Source = new BitmapImage(new Uri(binDebug + PathImage + ItemData[i].Image));
                }
                catch { }
                switch (ItemData[i].ItemType)
                {
                    case "Button":
                        stackpanel.Children.Add(
                            new RadRibbonButton()
                            {
                                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                                SmallImage = image.Source,
                                LargeImage = largeImage.Source,
                                Size = size,
                                Text = text,
                            }
                            );
                        break;
                    case "SplitButton":
                        RadRibbonSplitButton splitButton = new RadRibbonSplitButton
                        {
                            Size = size,
                            Text = text,
                            LargeImage = largeImage.Source,
                            SmallImage = image.Source,
                            VerticalAlignment = VerticalAlignment.Top,
                        };
                        RadContextMenu contextMenu = new RadContextMenu();
                        RadMenuItem Item = new RadMenuItem() { Icon = image.Source, Header = text };
                        contextMenu.Items.Add(Item);
                        splitButton.DropDownContent = contextMenu;
                        stackpanel.Children.Add(splitButton);
                        break;
                    case "ToggleButton":
                        stackpanel.Children.Add(new RadRibbonToggleButton()
                        {
                            Content = text,
                            LargeImage = largeImage.Source,
                            Size = size,
                            VerticalAlignment = VerticalAlignment.Top
                        });
                        break;
                    case "DropDownButton":
                        StackPanel stack = new StackPanel() { Orientation = Orientation.Vertical };
                        Label Text = new Label() { Content = ItemData[i].Text };
                        ComboBox ComboBox = new ComboBox();
                        stack.Children.Add(Text);
                        stack.Children.Add(ComboBox);
                        stackpanel.Children.Add(stack);
                        break;
                }
            }
            return stackpanel;
        }
    }
}
