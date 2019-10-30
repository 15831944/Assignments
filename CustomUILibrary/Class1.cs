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

using System.Collections.Generic;
using System.Windows.Controls;

namespace CustomUILibrary
{
    public class Class1 : RadWindow
    {
        public Class1(int Width, int Height)
        {
            StyleManager.ApplicationTheme = new MaterialTheme();
            this.Height = Height;
            this.Width = Width;
            //this.DataContext = InitRibbonView();
            this.Content = InitRibbonView();
            this.ResizeMode = ResizeMode.NoResize;
        }

        public RadRibbonView InitRibbonView()
        {
            RadRibbonView ribbonView = new RadRibbonView();
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
            ListRibbon.Add(new RadRibbonButton()
            {
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
