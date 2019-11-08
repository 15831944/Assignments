using Bricscad.ApplicationServices;
using Bricscad.EditorInput;
using Bricscad.Ribbon;
using BricscadApp;
using System;
using System.Windows.Media.Imaging;
using Telerik.Windows.Controls;
using Teigha.Runtime;
using Bricscad.Windows;
using System.Windows.Media;
using System.Windows.Interop;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ClassLibrary2.ViewModel
{
    public class Ribbon_ViewModel
    {
        public RadWindow radWindow = new RadWindow();
        public RadRibbonView radRibbonView { get; set; }
        
        public RadRibbonTab radRibbonTab = new RadRibbonTab();
        public List<RadRibbonTab> radRibbonTabs = new List<RadRibbonTab>();
        String imagePath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\res\\"; // Resource Folder

        public XmlNodeList XmlNodeList;

        public Ribbon_ViewModel()
        {
            InitRbControl();
        }

        public void InitRbControl()
        {
            RibbonControl rbnCtrl = ComponentManager.Ribbon;
            rbnCtrl.ClearAllTabs();

            // Init Panel Source
            RibbonPanelSource srcPanel = new RibbonPanelSource();
            srcPanel.Title = "";
            srcPanel.Id = "CustomPanel";

            RibbonPanel panel = new RibbonPanel();
            panel.Source = srcPanel;

            string XMLName = "//Data_UI.xml";
            string CurrentDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(CurrentDirectory + XMLName);
            XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/RadRibbonView/RadRibbonTab");
            ReadXml(XmlNodeList);

            
            StackPanel wrapPanel = new StackPanel();
            for (int i = 0; i < radRibbonTabs.Count; i++)
            {
                RibbonTab tab = new RibbonTab();
                tab.Title = radRibbonTabs[i].Header.ToString();
                tab.Id = radRibbonTabs[i].Name;
                tab.Panels.Add(panel);
                tab.Name = radRibbonTabs[i].Name;
                rbnCtrl.Tabs.Add(tab);
                wrapPanel.Children.Add(radRibbonTabs[i]);
                wrapPanel.HorizontalAlignment = HorizontalAlignment.Stretch;

                panel.SetWPFControl(wrapPanel, "test");
            }
            
        }

        public void ReadXml(XmlNodeList nodeList)
        {
            foreach (XmlNode node in nodeList)
            {
                RadRibbonTab radRibbonTab = CreateRibbonTab(node);
                if (node.ChildNodes.Count > 0)
                {
                    XmlNodeList ChildNode = node.ChildNodes;
                    foreach (XmlNode childNode in ChildNode)
                    {
                        RadRibbonGroup radRibbonGroup = CreateRibbonGroup(childNode);
                        if (childNode.ChildNodes.Count > 0)
                        {
                            XmlNodeList ChildChildNode = childNode.ChildNodes;
                            foreach (XmlNode childchildNode in ChildChildNode)
                            {
                                RadCollapsiblePanel radCollapsiblePanel = CreateRibbonPanel(childchildNode);
                                if (childchildNode.ChildNodes.Count > 0)
                                {
                                    XmlNodeList ChildChildChildNode = childchildNode.ChildNodes;
                                    foreach (XmlNode childchildchildNode in ChildChildChildNode)
                                    {
                                        CreateRibbonItem(childchildchildNode, radCollapsiblePanel);
                                    }
                                }
                                radRibbonGroup.Items.Add(radCollapsiblePanel);
                            }
                        }
                        radRibbonTab.Items.Add(radRibbonGroup);
                        //radRibbonTabs.Add(radRibbonGroup);
                    }
                }
                radRibbonTabs.Add(radRibbonTab);
                //radRibbonView.Items.Add(radRibbonTab);
                //Parse(node, radRibbonView);
            }
            //panel.SetWPFControl(wrapPanel, "test");
        }

        public RadRibbonTab CreateRibbonTab(XmlNode node)
        {
            String name = (node.Attributes.GetNamedItem("Header") != null) ? node.Attributes.GetNamedItem("Name").Value : "";
            String title = (node.Attributes.GetNamedItem("Header") != null) ? node.Attributes.GetNamedItem("Header").Value : "";
            String id = (node.Attributes.GetNamedItem("Name") != null) ? node.Attributes.GetNamedItem("Name").Value : "";
            bool IsEnabled = true;
            if (node.Attributes.GetNamedItem("IsEnabled") != null && node.Attributes.GetNamedItem("IsEnabled").Value == "false")
            {
                IsEnabled = false;
            }

            RadRibbonTab radRibbonTab = new RadRibbonTab() { Name = name, Header = title, IsEnabled = IsEnabled };
            return radRibbonTab;
        }

        public RadRibbonGroup CreateRibbonGroup(XmlNode node)
        {
            String name = (node.Attributes.GetNamedItem("Header") != null) ? node.Attributes.GetNamedItem("Name").Value : "";
            String title = (node.Attributes.GetNamedItem("Header") != null) ? node.Attributes.GetNamedItem("Header").Value : "";
            String id = (node.Attributes.GetNamedItem("Name") != null) ? node.Attributes.GetNamedItem("Name").Value : "";
            bool IsEnabled = true;
            if (node.Attributes.GetNamedItem("IsEnabled") != null && node.Attributes.GetNamedItem("IsEnabled").Value == "false")
            {
                IsEnabled = false;
            }
            RadRibbonGroup radRibbonGroup = new RadRibbonGroup() { Name = name, Header = title, IsEnabled = IsEnabled };
            return radRibbonGroup;
        }

        public RadCollapsiblePanel CreateRibbonPanel(XmlNode node)
        {
            String name = (node.Attributes.GetNamedItem("Name") != null) ? node.Attributes.GetNamedItem("Name").Value : "";
            String title = (node.Attributes.GetNamedItem("Header") != null) ? node.Attributes.GetNamedItem("Header").Value : "";
            String id = (node.Attributes.GetNamedItem("Name") != null) ? node.Attributes.GetNamedItem("Name").Value : "";
            bool IsEnabled = true;
            if (node.Attributes.GetNamedItem("IsEnabled") != null && node.Attributes.GetNamedItem("IsEnabled").Value == "false")
            {
                IsEnabled = false;
            }
            RadCollapsiblePanel radCollapsiblePanel = new RadCollapsiblePanel() { Name = name, IsEnabled = IsEnabled };
            return radCollapsiblePanel;
        }

        public void CreateRibbonItem(XmlNode node, RadCollapsiblePanel radCollapsiblePanel)
        {
            String id = (node.Attributes.GetNamedItem("Name") != null) ? node.Attributes.GetNamedItem("Name").Value : "";
            String name = (node.Attributes.GetNamedItem("Name") != null) ? node.Attributes.GetNamedItem("Name").Value : "";
            String tooltip = (node.Attributes.GetNamedItem("ToolTipContent") != null) ? node.Attributes.GetNamedItem("ToolTipContent").Value : "";
            String text = (node.Attributes.GetNamedItem("Text") != null) ? node.Attributes.GetNamedItem("Text").Value : "";

            bool isVisible = true;
            if (node.Attributes.GetNamedItem("IsVisible") != null && node.Attributes.GetNamedItem("IsVisible").Value == "false")
            {
                isVisible = false;
            }
            bool isInitialized = true;
            if (node.Attributes.GetNamedItem("IsInitialized") != null && node.Attributes.GetNamedItem("IsInitialized").Value == "false")
            {
                isInitialized = false;
            }
            bool isEnabled = true;
            if (node.Attributes.GetNamedItem("IsEnabled") != null && node.Attributes.GetNamedItem("IsEnabled").Value == "false")
            {
                isEnabled = false;
            }
            bool splitText = false;
            if (node.Attributes.GetNamedItem("SplitText") != null && node.Attributes.GetNamedItem("SplitText").Value == "true")
            {
                splitText = true;
            }

            VerticalAlignment verticalAlignmentItem = VerticalAlignment.Center;
            if (node.Attributes.GetNamedItem("VerticalAlignment") != null)
            {
                if (node.Attributes.GetNamedItem("VerticalAlignment").Value == "Top")
                {
                    verticalAlignmentItem = VerticalAlignment.Top;
                }
                else if (node.Attributes.GetNamedItem("VerticalAlignment").Value == "Bottom")
                {
                    verticalAlignmentItem = VerticalAlignment.Bottom;
                }
                else if (node.Attributes.GetNamedItem("VerticalAlignment").Value == "Strech")
                {
                    verticalAlignmentItem = VerticalAlignment.Stretch;
                }
            }

            Telerik.Windows.Controls.RibbonView.ButtonSize itemSize = Telerik.Windows.Controls.RibbonView.ButtonSize.Medium;
            if (node.Attributes.GetNamedItem("Size") != null)
            {
                if (node.Attributes.GetNamedItem("Size").Value == "Small")
                {
                    itemSize = Telerik.Windows.Controls.RibbonView.ButtonSize.Small;
                }
                else if (node.Attributes.GetNamedItem("Size").Value == "Large")
                {
                    itemSize = Telerik.Windows.Controls.RibbonView.ButtonSize.Large;
                }
            }

            String largeImage = (node.Attributes.GetNamedItem("LargeImage") != null) ? node.Attributes.GetNamedItem("LargeImage").Value : "";
            String smallImage = (node.Attributes.GetNamedItem("SmallImage") != null) ? node.Attributes.GetNamedItem("SmallImage").Value : "";

            ImageSource itemImg = null;
            if (node.Attributes.GetNamedItem("Image") == null)
            {
                if (itemSize == Telerik.Windows.Controls.RibbonView.ButtonSize.Large)
                {
                    itemImg = IconToImageSource((System.Drawing.Icon)Properties.Resources.ResourceManager.GetObject(largeImage));
                }
                else if (itemSize == Telerik.Windows.Controls.RibbonView.ButtonSize.Small)
                {
                    itemImg = IconToImageSource((System.Drawing.Icon)Properties.Resources.ResourceManager.GetObject(smallImage));
                }
                else
                {
                    itemImg = IconToImageSource((System.Drawing.Icon)Properties.Resources.ResourceManager.GetObject(smallImage));
                }
            }
            else
            {
                itemImg = IconToImageSource((System.Drawing.Icon)Properties.Resources.ResourceManager.GetObject(node.Attributes.GetNamedItem("Image").Value));
            }

            String itemType = node.Name.ToString();
            switch (itemType)
            {
                case "RadRibbonButton":
                    radCollapsiblePanel.Children.Add(new RadRibbonButton() { SmallImage = itemImg, LargeImage = itemImg, Text = text, ToolTip = tooltip, Size = itemSize, VerticalAlignment = verticalAlignmentItem, IsEnabled = isEnabled, SplitText = splitText });
                    break;
                case "RadRibbonToggleButton":
                    radCollapsiblePanel.Children.Add(new RadRibbonToggleButton() { SmallImage = itemImg, LargeImage = itemImg, Text = text, ToolTip = tooltip, Size = itemSize, VerticalAlignment = verticalAlignmentItem, IsEnabled = isEnabled });
                    break;
                case "RadRibbonRadioButton":
                    radCollapsiblePanel.Children.Add(new RadRibbonRadioButton() { SmallImage = itemImg, LargeImage = itemImg, Text = text, ToolTip = tooltip, Size = itemSize, VerticalAlignment = verticalAlignmentItem, IsEnabled = isEnabled });
                    break;
                case "RadRibbonDropDownButton":
                    radCollapsiblePanel.Children.Add(new RadRibbonDropDownButton() { SmallImage = itemImg, LargeImage = itemImg, Text = text, ToolTip = tooltip, Size = itemSize, VerticalAlignment = verticalAlignmentItem, IsEnabled = isEnabled });
                    break;
                case "RadRibbonSplitButton":
                    radCollapsiblePanel.Children.Add(new RadRibbonSplitButton() { SmallImage = itemImg, LargeImage = itemImg, Text = text, ToolTip = tooltip, Size = itemSize, VerticalAlignment = verticalAlignmentItem, IsEnabled = isEnabled });
                    // ERROR
                    break;
                case "RadButton":
                    radCollapsiblePanel.Children.Add(new RadButton() { Content = text, Name = name, ToolTip = tooltip, IsEnabled = isEnabled });
                    break;
                case "RadPathButton":
                    radCollapsiblePanel.Children.Add(new RadPathButton() { Content = text, Name = name, ToolTip = tooltip, IsEnabled = isEnabled });
                    break;
                case "RadDropDownButton":
                    radCollapsiblePanel.Children.Add(new RadDropDownButton() { Content = text, Name = name, ToolTip = tooltip, IsEnabled = isEnabled });
                    break;
                case "RadRadioButton":
                    radCollapsiblePanel.Children.Add(new RadRadioButton() { Content = text, Name = name, ToolTip = tooltip, IsEnabled = isEnabled });
                    break;
                case "RadSplitButton":
                    radCollapsiblePanel.Children.Add(new RadSplitButton() { Content = text, Name = name, ToolTip = tooltip, IsEnabled = isEnabled });
                    break;
                case "RadToggleButton":
                    radCollapsiblePanel.Children.Add(new RadToggleButton() { Content = text, Name = name, ToolTip = tooltip, IsEnabled = isEnabled });
                    break;
                case "RadToggleSwitchButton":
                    radCollapsiblePanel.Children.Add(new RadToggleSwitchButton() { Content = text, Name = name, ToolTip = tooltip, IsEnabled = isEnabled });
                    break;
                case "RadComboBox":
                    radCollapsiblePanel.Children.Add(new RadComboBox() { Text = text });
                    break;
            }
        }

        private ImageSource IconToImageSource(System.Drawing.Icon icon)
        {
            return Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle,
                new Int32Rect(0, 0, icon.Width, icon.Height),
                BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
