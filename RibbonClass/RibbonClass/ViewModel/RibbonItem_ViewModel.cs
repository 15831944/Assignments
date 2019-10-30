using Bricscad.Windows;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.RibbonView;
using Label = Telerik.Windows.Controls.Label;

namespace RibbonClass.ViewModel
{
    public class RibbonItem_ViewModel
    {
        public ObservableCollection<RibbonItemCustom> RibbonItems { get; set; }
        public static ObservableCollection<object> RadControl { get; set; }

        //var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        static string PathImage = "\\res\\";
        static string binDebug = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
        //var currentDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        internal void ReadXML(XmlNodeList NodeItems)
        {
            if (NodeItems.Count == 1)
            {
                if (NodeItems.Item(0).Name == "StackPanel")
                {

                }
            }
            ObservableCollection<RibbonItemCustom> _ribbonItems = new ObservableCollection<RibbonItemCustom>();
            foreach (XmlNode node in NodeItems)
            {
                String id = node.Attributes.GetNamedItem("Name").Value;
                String tooltip = node.Attributes.GetNamedItem("ToolTipContent").Value;
                String text = node.Attributes.GetNamedItem("Text").Value;
                String imagePath = "";
                String externalImage = "true";
                String isVisible = node.Attributes.GetNamedItem("IsVisible").Value;
                String isInitialized = node.Attributes.GetNamedItem("IsInitialized").Value;
                String image = node.Attributes.GetNamedItem("Image").Value;
                String largeImage = node.Attributes.GetNamedItem("LargeImage").Value;
                //String width = node.SelectSingleNode("Width").InnerText;
                //String height = node.SelectSingleNode("Height").InnerText;
                String isEnabled = node.Attributes.GetNamedItem("IsEnabled").Value;
                String itemType = node.NodeType.ToString();
                //String size = node.SelectSingleNode("Size").InnerText;
                //String isAutoSize = node.SelectSingleNode("IsAutoSize").InnerText;
                RibbonItemCustom itemCustom = new RibbonItemCustom
                {
                    Id = id,
                    ToolTip = tooltip,
                    Text = text,
                    ImagePath = imagePath,
                    ExternalImage = externalImage.Equals("True"),
                    IsVisible = isVisible.Equals("True"),
                    IsInitialized = isInitialized.Equals("True"),
                    Image = image,
                    LargeImage = largeImage,
                };
                //try
                //{
                //    itemCustom.Width = int.Parse(width);
                //} catch { }
                //try
                //{
                //    itemCustom.Height = int.Parse(height);
                //}
                //catch { }
                itemCustom.IsEnabled = isEnabled.Equals("True");
                itemCustom.ItemType = itemType;
                //itemCustom.Size = size;
                //itemCustom.IsAutoSize = isAutoSize.Equals("True");
                _ribbonItems.Add(itemCustom);
            }
            RibbonItems = _ribbonItems;
        }

        public static void ConverToTelerik(ObservableCollection<RibbonItemCustom> ItemsCustom)
        {
            ObservableCollection<object> temp = new ObservableCollection<object>();
            
            foreach (RibbonItemCustom itemCustom in ItemsCustom)
            {
                RibbonControl control = ComponentManager.Ribbon;


                String Id = itemCustom.Id;
                String ToolTip = itemCustom.ToolTip;
                String text = itemCustom.Text;
                String ImagePath = itemCustom.ImagePath;
                Boolean ExternalImage = itemCustom.ExternalImage;
                Boolean IsVisible = itemCustom.IsVisible;
                Boolean IsInitialized = itemCustom.IsInitialized;
                String Image = itemCustom.Image;
                String LargeImage = itemCustom.LargeImage;
                int width = itemCustom.Width;
                int height = itemCustom.Height;
                Boolean IsEnabled = itemCustom.IsEnabled;
                String Size = itemCustom.Size;
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
                String Type = itemCustom.ItemType;
                Boolean IsAutoSize = itemCustom.ExternalImage;
                Image image = new Image();
                try
                {
                    image.Source = new BitmapImage(new Uri(binDebug + PathImage + itemCustom.Image));
                }
                catch { }
                switch (Type)
                {
                    case "Button":
                        temp.Add(new RadRibbonButton());
                        break;
                    case "SplitButton":
                        RadRibbonSplitButton splitButton = new RadRibbonSplitButton
                        {
                            Size = size,
                            Text = text,
                            LargeImage = image.Source,
                            SmallImage = image.Source,
                            Width = width,
                            Height = height,
                            VerticalAlignment = VerticalAlignment.Top
                        };
                        RadContextMenu contextMenu = new RadContextMenu();
                        RadMenuItem Item = new RadMenuItem() { Icon = image.Source, Header = text };
                        contextMenu.Items.Add(Item);
                        splitButton.DropDownContent = contextMenu;
                        temp.Add(splitButton);
                        break;
                    case "ToggleButton":
                        temp.Add(new RadRibbonToggleButton()
                        {
                            Content = text,
                            LargeImage = image.Source,
                            Size = size,
                            Width = width,
                            Height = height,
                            VerticalAlignment = VerticalAlignment.Top
                        });
                        break;
                    case "DropDownButton":
                        StackPanel stack = new StackPanel() { Orientation=Orientation.Horizontal };
                        Label Text = new Label() { Content = itemCustom.Text };
                        ComboBox ComboBox = new ComboBox();
                        stack.Children.Add(Text);
                        stack.Children.Add(ComboBox);
                        temp.Add(stack);
                        break;
                }
            }
            StackPanel row1 = new StackPanel();
            for (int i = 0; i < temp.Count / 2; i++)
            {
                string Type = temp[i].GetType().Name;
                switch (Type)
                {
                    case "Button":
                        row1.Children.Add((RadRibbonButton)temp[i]);
                        break;
                    case "SplitButton":
                        row1.Children.Add((RadRibbonSplitButton)temp[i]);
                        break;
                    case "ToggleButton":
                        row1.Children.Add((RadRibbonToggleButton)temp[i]);
                        break;
                    case "DropDownButton":
                        //row1.Children.Add((RadRibbonButton)temp[i]);
                        break;
                }
            }
            StackPanel row2 = new StackPanel();

            RadControl = temp;
        }
    }
}
