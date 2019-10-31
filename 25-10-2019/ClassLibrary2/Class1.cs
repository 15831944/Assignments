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

namespace ClassLibrary2
{
    public class Class1
    {
        public RadWindow radWindow = new RadWindow();
        public RadRibbonView radRibbonView = new RadRibbonView();
        XmlNodeList XmlNodeList;
        public Class1()
        {
            radWindow.Height = 500;
            radWindow.Width = 600;
            radWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            StyleManager.ApplicationTheme = new MaterialTheme();
            //radWindow.Content = InitRibbonView();
            //radWindow.ResizeMode = ResizeMode.NoResize;
            //radWindow.Show();
            //this.DataContext = InitRibbonView();

        }

        public void InitRbControl()
        {
            RibbonControl rbnCtrl = ComponentManager.Ribbon;
            // Init Panel Source
            RibbonPanelSource srcPanel = new RibbonPanelSource();
            srcPanel.Title = "";
            srcPanel.Id = "CustomPanel";

            RibbonPanel panel = new RibbonPanel();
            panel.Source = srcPanel;

            RibbonTab tab = new RibbonTab();
            tab.Title = "Custom Tab Telerik";
            tab.Id = "CustomTab";
            tab.Panels.Add(panel);
            rbnCtrl.Tabs.Add(tab);

            System.Windows.Controls.StackPanel wrapPanel = new System.Windows.Controls.StackPanel();

            string XMLName = "//Data_UI.xml";
            string CurrentDirectory = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(CurrentDirectory + XMLName);
            XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/RadRibbonView/RadRibbonTab");
            ReadXml(XmlNodeList);
            wrapPanel.Children.Add(radRibbonView);
            wrapPanel.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            panel.SetWPFControl(wrapPanel, "test");
        }

        public void ReadXml(XmlNodeList nodeList)
        {
            string name = "";
            string title = "";
            string isEnabled = "";
            string id = "";
            bool IsEnabled = false;
            foreach (XmlNode node in nodeList)
            {
                name = (node.Attributes.GetNamedItem("Header") != null) ? node.Attributes.GetNamedItem("Name").Value : "";
                title = (node.Attributes.GetNamedItem("Header") != null) ? node.Attributes.GetNamedItem("Header").Value : "";
                id = (node.Attributes.GetNamedItem("Name") != null) ? node.Attributes.GetNamedItem("Name").Value : "";
                isEnabled = (node.Attributes.GetNamedItem("IsEnabled") != null) ? node.Attributes.GetNamedItem("IsEnabled").Value : "true";
                IsEnabled = (isEnabled == "true") ? true : false;

                RadRibbonTab radRibbonTab = new RadRibbonTab() { Name = name, Header = title, IsEnabled = IsEnabled };
                
                if (node.ChildNodes.Count > 0)
                {
                    XmlNodeList ChildNode = node.ChildNodes;
                    foreach(XmlNode childNode in ChildNode)
                    {
                        name = (childNode.Attributes.GetNamedItem("Header") != null) ? childNode.Attributes.GetNamedItem("Name").Value : "";
                        title = (childNode.Attributes.GetNamedItem("Header") != null) ? childNode.Attributes.GetNamedItem("Header").Value : "";
                        id = (childNode.Attributes.GetNamedItem("Name") != null) ? childNode.Attributes.GetNamedItem("Name").Value : "";
                        isEnabled = (childNode.Attributes.GetNamedItem("IsEnabled") != null) ? childNode.Attributes.GetNamedItem("IsEnabled").Value : "true";
                        IsEnabled = (isEnabled == "true") ? true : false;
                        RadRibbonGroup radRibbonGroup = new RadRibbonGroup() { Name = name, Header = title, IsEnabled = IsEnabled };
                        if (childNode.ChildNodes.Count > 0)
                        {
                            XmlNodeList ChildChildNode = childNode.ChildNodes;
                            foreach(XmlNode childchildNode in ChildChildNode)
                            {
                                name = (childchildNode.Attributes.GetNamedItem("Name") != null) ? childchildNode.Attributes.GetNamedItem("Name").Value : "";
                                title = (childchildNode.Attributes.GetNamedItem("Header") != null) ? childchildNode.Attributes.GetNamedItem("Header").Value : "";
                                id = (childchildNode.Attributes.GetNamedItem("Name") != null) ? childchildNode.Attributes.GetNamedItem("Name").Value : "";
                                isEnabled = (childchildNode.Attributes.GetNamedItem("IsEnabled") != null) ? childchildNode.Attributes.GetNamedItem("IsEnabled").Value : "true";
                                IsEnabled = (isEnabled == "true") ? true : false;
                                RadCollapsiblePanel radCollapsiblePanel = new RadCollapsiblePanel() { Name = name, IsEnabled = IsEnabled };
                                if (childchildNode.ChildNodes.Count > 0)
                                {
                                    XmlNodeList ChildChildChildNode = childchildNode.ChildNodes;
                                    foreach (XmlNode childchildchildNode in ChildChildChildNode)
                                    {
                                        id = (childchildchildNode.Attributes.GetNamedItem("Name") != null) ? childchildchildNode.Attributes.GetNamedItem("Name").Value : "";
                                        String tooltip = (childchildchildNode.Attributes.GetNamedItem("ToolTipContent") != null) ? childchildchildNode.Attributes.GetNamedItem("ToolTipContent").Value : "";
                                        String text = (childchildchildNode.Attributes.GetNamedItem("Text") != null) ? childchildchildNode.Attributes.GetNamedItem("Text").Value : "";
                                        String imagePath = "";
                                        String externalImage = "true";
                                        String isVisible = (childchildchildNode.Attributes.GetNamedItem("IsVisible") != null) ? childchildchildNode.Attributes.GetNamedItem("IsVisible").Value : "";
                                        String isInitialized = childchildchildNode.Attributes.GetNamedItem("IsInitialized").Value;
                                        String image = (childchildchildNode.Attributes.GetNamedItem("Image") != null) ? childchildchildNode.Attributes.GetNamedItem("Image").Value : "";
                                        String largeImage = (childchildchildNode.Attributes.GetNamedItem("LargeImage") != null) ? childchildchildNode.Attributes.GetNamedItem("LargeImage").Value : "";
                                        //String width = childchildchildNode.SelectSingleNode("Width").InnerText;
                                        //String height = node.SelectSingleNode("Height").InnerText;
                                        isEnabled = (childchildchildNode.Attributes.GetNamedItem("IsEnabled") != null) ? childchildchildNode.Attributes.GetNamedItem("IsEnabled").Value : "";
                                        String itemType = childchildchildNode.Name.ToString();
                                        //String size = childchildchildNode.SelectSingleNode("Size").InnerText;
                                        //String isAutoSize = childchildchildNode.SelectSingleNode("IsAutoSize").InnerText;
                                        ImageSource itemImg = new BitmapImage(new Uri("../../res/" + image));
                                        ImageSource ime = IconToImageSource(Properties.Resources. + image);
                                        //string typeNode = childchildchildNode.NodeType.ToString();
                                        switch (itemType)
                                        {
                                            case "RadRibbonButton":
                                                radCollapsiblePanel.Children.Add(new RadRibbonButton() { SmallImage = itemImg, LargeImage = itemImg, Text = text, ToolTip = tooltip });
                                                break;
                                            case "RadRibbonToggleButton":
                                                radCollapsiblePanel.Children.Add(new RadRibbonToggleButton() { SmallImage = itemImg, LargeImage = itemImg, Text = text, ToolTip = tooltip });
                                                break;
                                            case "RadRibbonRadioButton":
                                                radCollapsiblePanel.Children.Add(new RadRibbonRadioButton() { SmallImage = itemImg, LargeImage = itemImg, Text = text, ToolTip = tooltip });
                                                break;
                                            case "RadRibbonDropDownButton":
                                                radCollapsiblePanel.Children.Add(new RadRibbonDropDownButton() { SmallImage = itemImg, LargeImage = itemImg, Text = text, ToolTip = tooltip });
                                                break;
                                            case "RadRibbonSplitButton":
                                                radCollapsiblePanel.Children.Add(new RadRibbonSplitButton() { SmallImage = itemImg, LargeImage = itemImg, Text = text, ToolTip = tooltip });
                                                // ERROR
                                                break;
                                            case "RadButton":
                                                radCollapsiblePanel.Children.Add(new RadButton() { Content = text, Name = name, ToolTip = tooltip });
                                                break;
                                            case "RadPathButton":
                                                radCollapsiblePanel.Children.Add(new RadPathButton() { Content = text, Name = name, ToolTip = tooltip });
                                                break;
                                            case "RadDropDownButton":
                                                radCollapsiblePanel.Children.Add(new RadDropDownButton() { Content = text, Name = name, ToolTip = tooltip });
                                                break;
                                            case "RadRadioButton":
                                                radCollapsiblePanel.Children.Add(new RadRadioButton() { Content = text, Name = name, ToolTip = tooltip });
                                                break;
                                            case "RadSplitButton":
                                                radCollapsiblePanel.Children.Add(new RadSplitButton() { Content = text, Name = name, ToolTip = tooltip });
                                                break;
                                            case "RadToggleButton":
                                                radCollapsiblePanel.Children.Add(new RadToggleButton() { Content = text, Name = name, ToolTip = tooltip });
                                                break;
                                            case "RadToggleSwitchButton":
                                                radCollapsiblePanel.Children.Add(new RadToggleSwitchButton() { Content = text, Name = name, ToolTip = tooltip });
                                                break;
                                            case "RadComboBox":
                                                radCollapsiblePanel.Children.Add(new RadComboBox() { Text = text,  });
                                                break;
                                        }
                                    }
                                }
                                radRibbonGroup.Items.Add(radCollapsiblePanel);
                            }
                        }
                        radRibbonTab.Items.Add(radRibbonGroup);
                    }
                    
                }
                radRibbonView.Items.Add(radRibbonTab);
                //Parse(node, radRibbonView);
            }
            //panel.SetWPFControl(wrapPanel, "test");
        }

        public void Parse(XmlNode Node, RadRibbonView radRibbonView)
        {
            string name = "";
            string title = "";
            string isEnabled = "";
            string id = "";
            bool IsEnabled = false;
            switch (Node.Name)
            {
                case "RadRibbonTab":
                    name = (Node.Attributes.GetNamedItem("Header") != null) ? Node.Attributes.GetNamedItem("Name").Value : "";
                    title = (Node.Attributes.GetNamedItem("Header") != null) ? Node.Attributes.GetNamedItem("Header").Value : "";
                    id = (Node.Attributes.GetNamedItem("Name") != null) ? Node.Attributes.GetNamedItem("Name").Value : "";
                    isEnabled = (Node.Attributes.GetNamedItem("IsEnabled") != null) ? Node.Attributes.GetNamedItem("IsEnabled").Value : "true";
                    IsEnabled = (isEnabled == "true") ? true : false;
                    RadRibbonTab radRibbonTab = new RadRibbonTab() { Name = name, Header = title, IsEnabled = IsEnabled };
                    break;
                case "RadRibbonGroup":
                    name = (Node.Attributes.GetNamedItem("Header") != null) ? Node.Attributes.GetNamedItem("Name").Value : "";
                    title = (Node.Attributes.GetNamedItem("Header") != null) ? Node.Attributes.GetNamedItem("Header").Value : "";
                    id = (Node.Attributes.GetNamedItem("Name") != null) ? Node.Attributes.GetNamedItem("Name").Value : "";
                    isEnabled = (Node.Attributes.GetNamedItem("IsEnabled") != null) ? Node.Attributes.GetNamedItem("IsEnabled").Value : "true";
                    IsEnabled = (isEnabled == "true") ? true : false;
                    RadRibbonGroup radRibbonGroup = new RadRibbonGroup() { Name = name, Header = title, IsEnabled = IsEnabled };
                    break;
                case "RadCollapsiblePanel":
                    name = (Node.Attributes.GetNamedItem("Header") != null) ? Node.Attributes.GetNamedItem("Name").Value : "";
                    title = (Node.Attributes.GetNamedItem("Header") != null) ? Node.Attributes.GetNamedItem("Header").Value : "";
                    id = (Node.Attributes.GetNamedItem("Name") != null) ? Node.Attributes.GetNamedItem("Name").Value : "";
                    isEnabled = (Node.Attributes.GetNamedItem("IsEnabled") != null) ? Node.Attributes.GetNamedItem("IsEnabled").Value : "true";
                    IsEnabled = (isEnabled == "true") ? true : false;
                    RadCollapsiblePanel radCollapsiblePanel = new RadCollapsiblePanel() { Name = name, IsEnabled = IsEnabled, Children = { } };
                    break;
                default:
                    id = Node.Attributes.GetNamedItem("Name").Value;
                    String tooltip = Node.Attributes.GetNamedItem("ToolTipContent").Value;
                    String text = Node.Attributes.GetNamedItem("Text").Value;
                    String imagePath = "";
                    String externalImage = "true";
                    String isVisible = Node.Attributes.GetNamedItem("IsVisible").Value;
                    String isInitialized = Node.Attributes.GetNamedItem("IsInitialized").Value;
                    String image = Node.Attributes.GetNamedItem("Image").Value;
                    String largeImage = Node.Attributes.GetNamedItem("LargeImage").Value;
                    //String width = node.SelectSingleNode("Width").InnerText;
                    //String height = node.SelectSingleNode("Height").InnerText;
                    isEnabled = Node.Attributes.GetNamedItem("IsEnabled").Value;
                    String itemType = Node.NodeType.ToString();
                    //String size = node.SelectSingleNode("Size").InnerText;
                    //String isAutoSize = node.SelectSingleNode("IsAutoSize").InnerText;
                    break;
            }
        }

        public RadRibbonView InitRibbonView(int width, int height)
        {
            RadRibbonView ribbonView = new RadRibbonView();
            ribbonView.IsMinimizable = false;
            ribbonView.Title = "Demo";
            
            StackPanel stackPanel = new StackPanel();
            StackPanel stackPanel2 = new StackPanel();
            StackPanel stackPanel3 = new StackPanel();
            StackPanel stackPanel4 = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel2.Orientation = stackPanel.Orientation;
            stackPanel3.Orientation = stackPanel2.Orientation;
            stackPanel4.Orientation = stackPanel3.Orientation;
            // loop for
            List<RadRibbonButton> ListRibbon = new List<RadRibbonButton>();
            ListRibbon.Add(new RadRibbonButton() {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Element_Cylinder),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            ListRibbon.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Element_Torisphere),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            ListRibbon.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Element_Cone),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            ListRibbon.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Element_Flange),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            ListRibbon.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Element_Ellipse),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            ListRibbon.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Element_Sphere),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            ListRibbon.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Element_WeldFlat),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            ListRibbon.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Element_Skirt),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });

            for (int i = 0; i < ListRibbon.Count / 2; i++)
            {
                stackPanel.Children.Add(ListRibbon[i]);
            }

            for (int i = ListRibbon.Count / 2; i < ListRibbon.Count; i++)
            {
                stackPanel2.Children.Add(ListRibbon[i]);
            }

            stackPanel3.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Detail_Ring),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel3.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Detail_Ring),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel3.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Detail_Platform),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel3.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PVE_Detail_Weight),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel3.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Detail_Lug),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel3.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Detail_Liquid),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel3.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Detail_Insulation),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel3.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Detail_TS),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel3.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Detail_Lift_Lug),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel3.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Detail_API_579),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });

            stackPanel4.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Detail_Nozzle),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel4.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Detail_Force),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel4.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Detail_Packing),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel4.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Detail_Trays),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel4.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Detail_Lug),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel4.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Detail_Lining),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel4.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Detail_HPJ),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel4.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Detail_Clip),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel4.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                SmallImage = IconToImageSource(Properties.Resources.PV_Detail_App9_Jacket),
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            
            ribbonView.Items.Add(new RadRibbonTab()
            {
                Header = "Home",
                Items =
                {
                    new RadRibbonGroup() { Header = "File", Items =
                    {
                        new RadRibbonSplitButton { Text = "New", VerticalAlignment = VerticalAlignment.Top, SmallImage = IconToImageSource(Properties.Resources._02_01_FileNew) },
                        new RadRibbonButton { SplitText = true, Text = "Open...", Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large, SmallImage = IconToImageSource(Properties.Resources._02_02_File_Open) },
                        new RadRibbonSplitButton { VerticalAlignment = VerticalAlignment.Top, Text = "Save", Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Medium,
                            SmallImage = IconToImageSource(Properties.Resources._02_03_File_Save) },
                    }},
                    new RadRibbonGroup() { Header = "Elements" , Items =
                        {
                            new StackPanel() { Orientation = Orientation.Vertical, Children = { stackPanel, stackPanel2 } }
                        }
                    },
                    new RadRibbonGroup() { Header = "Details" , Items =
                        {
                            new StackPanel() { Orientation = Orientation.Vertical, Children = { stackPanel3, stackPanel4 } }
                        }
                    },
                    new RadRibbonGroup()
                    {
                        Header = "Input / Output", Items =
                        {
                            new StackPanel() { Orientation = Orientation.Horizontal, Children =
                                {
                                    new StackPanel()
                                    {
                                        Orientation = Orientation.Vertical, Children =
                                        {
                                            new RadRibbonButton { SmallImage = IconToImageSource(Properties.Resources.Input), Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Medium, Text = "Input"},
                                            new RadRibbonButton { SmallImage = IconToImageSource(Properties.Resources.CodeCalc), Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Medium},
                                        }
                                    },
                                    new RadRibbonButton { SmallImage = IconToImageSource(Properties.Resources.Review_access_database), Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Medium}
                                }
                            }
                        }
                        //},
                        //new RadRibbonGroup()
                        //{
                        //    Header = "Utility", Items =
                        //    {
                        //        new StackPanel()
                        //        {
                        //            Orientation = Orientation.Vertical, Children =
                        //            {
                        //                new StackPanel()
                        //                {
                        //                    Children =
                        //                    {
                        //                        new RadRibbonButton()
                        //                        {
                        //                            CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                        //                            SmallImage = IconToImageSource(Properties.Resources.PV_Detail_Ring),
                        //                            Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
                        //                        },
                        //                        new RadRibbonButton()
                        //                        {
                        //                            CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                        //                            SmallImage = IconToImageSource(Properties.Resources.PV_Detail_Ring),
                        //                            Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
                        //                        },
                        //                        new RadRibbonButton()
                        //                        {
                        //                            CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                        //                            SmallImage = IconToImageSource(Properties.Resources.PV_Detail_Ring),
                        //                            Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
                        //                        },
                        //                        new RadRibbonButton()
                        //                        {
                        //                            CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                        //                            SmallImage = IconToImageSource(Properties.Resources.PV_Detail_Ring),
                        //                            Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
                        //                        },
                        //                        new RadRibbonButton()
                        //                        {
                        //                            CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                        //                            SmallImage = IconToImageSource(Properties.Resources.PV_Detail_Ring),
                        //                            Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
                        //                        },
                        //                    }
                        //                    ,Orientation = Orientation.Horizontal
                        //                }
                        //            }
                        //        }
                        //    }
                        //}
                    }
                }
            });
            ribbonView.Items.Add(new RadRibbonTab() { Header = "Tools" });
            ribbonView.Items.Add(new RadRibbonTab() { Header = "View" });
            ribbonView.Items.Add(new RadRibbonTab() { Header = "3D" });
            ribbonView.Items.Add(new RadRibbonTab() { Header = "Diagonostics" });
            ribbonView.Items.Add(new RadRibbonTab() { Header = "ESL" });
            ribbonView.Items.Add(new RadRibbonTab() { Header = "Help" });
            return ribbonView;
        }

        public static void RemoveRibbons()
        {
            RibbonControl ribbonControl = ComponentManager.Ribbon;
            foreach (var item in ribbonControl.Tabs)
            {
                ribbonControl.Tabs.Remove(item);
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
