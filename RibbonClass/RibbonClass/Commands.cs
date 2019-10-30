using Teigha.Runtime;
using Bricscad.ApplicationServices;
using Bricscad.EditorInput;
using System.Reflection;
using System.IO;
using Bricscad.Windows;
using Application = Bricscad.ApplicationServices.Application;
using RibbonClass.Views;
using RibbonClass.Model;
using Telerik.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Interop;
using System.Windows;
using System.Windows.Media.Imaging;
using System;
using Telerik.Windows.Controls.RibbonView;
using Label = Telerik.Windows.Controls.Label;
using RibbonClass.ViewModel;

namespace RibbonClass
{
    public class Commands : IExtensionApplication
    {
        public void Initialize()
        {
            test_();
        }

        public void Terminate()
        {
            
        }
        public static object ViewModel { get; private set; }

        public static Editor _editor()
        {
            Document document = Application.DocumentManager.MdiActiveDocument;
            return document.Editor;
        }
        [CommandMethod("Test")]
        public static void Test()
        {
            PaletteSet ps = new PaletteSet("Ribbon Custom")
            {
                //ps.Add("Ribbon", ribbon_Custom);
                // set some style parameters
                Style = PaletteSetStyles.NameEditable |
                PaletteSetStyles.ShowPropertiesMenu |
                PaletteSetStyles.ShowAutoHideButton |
                PaletteSetStyles.ShowCloseButton |
                PaletteSetStyles.Snappable,

                Visible = true,
                Dock = DockSides.None
            };
            System.Drawing.Point startPos = new System.Drawing.Point(50, 50);
            ps.SetLocation(startPos);
            ps.SetSize(new System.Drawing.Size(800, 145));
            ps.TitleBarLocation = PaletteSetTitleBarLocation.Left;
            Ribbon_ViewModel viewModel = new Ribbon_ViewModel();
            ps.AddVisual("Ribbon", viewModel.InitRibbonView());
        }
        [CommandMethod("Test1")]
        public static void test_()
        {
            PaletteSet ps = new PaletteSet("Ribbon Custom")
            {

                //ps.Add("Ribbon", ribbon_Custom);
                // set some style parameters

                Style = PaletteSetStyles.NameEditable |

                PaletteSetStyles.ShowPropertiesMenu |

                PaletteSetStyles.ShowAutoHideButton |

                PaletteSetStyles.ShowCloseButton |

                PaletteSetStyles.Snappable,

                Visible = true,
                Dock = DockSides.None
            };
            System.Drawing.Point startPos = new System.Drawing.Point(50, 50);
            ps.SetLocation(startPos);
            ps.SetSize(new System.Drawing.Size(700, 145));
            ps.TitleBarLocation = PaletteSetTitleBarLocation.Left;

            Ribbon_ViewModel viewModel = new Ribbon_ViewModel();
            ps.AddVisual("Ribbon", viewModel.InitRibbonView());
        }
        [CommandMethod("RemoveRibbon")]
        public static void _removeribbon()
        {
            //Ribbon_Bricscad ribbon_Bricscad = new Ribbon_Bricscad();
            
            //ribbonTab_MV_Bricscad.RemoveRibbons();
        }
        [CommandMethod("LoadRibbon")]
        public static void _loadribbon()
        {
           // RibbonTab_MV_Bricscad ribbonTab_MV_Bricscad = new RibbonTab_MV_Bricscad();
           // ribbonTab_MV_Bricscad.ReadXML();
        }
        
        [CommandMethod("LoadDLLTheme")]
        public static void MyNetLoad()
        {
            string DLLName = "\\Telerik.Windows.Themes.Windows8.dll";
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            var binDebug = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            //var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            try
            {
                Assembly.LoadFrom(binDebug + DLLName);
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage("\nCannot load {0}:", ex.Message);
            }

        }
        private ImageSource IconToImageSource(System.Drawing.Icon icon)
        {
            return Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle,
                new Int32Rect(0, 0, icon.Width, icon.Height),
                BitmapSizeOptions.FromEmptyOptions());
        }
        public static RadRibbonView InitRibbonView_()
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
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            ListRibbon.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            ListRibbon.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            ListRibbon.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            ListRibbon.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            ListRibbon.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            ListRibbon.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            ListRibbon.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
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
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel3.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel3.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel3.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel3.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel3.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel3.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel3.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel3.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel3.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });

            stackPanel4.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel4.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel4.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel4.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel4.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel4.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel4.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel4.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });
            stackPanel4.Children.Add(new RadRibbonButton()
            {
                CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
                Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            });

            ribbonView.Items.Add(new RadRibbonTab()
            {
                Header = "Home",
                Items =
                {
                    new RadRibbonGroup() { Header = "File", Items =
                    {
                        new RadRibbonSplitButton {
                            Text = "New",
                            VerticalAlignment = VerticalAlignment.Top },
                        new RadRibbonButton {
                            SplitText = true,
                            Text = "Open...",
                            Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large },
                        new RadRibbonSplitButton {
                            VerticalAlignment = VerticalAlignment.Top,
                            Text = "Save",
                            Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Medium
                             },
                    }},
                    new RadRibbonGroup() { Header = "Elements" , Items =
                        {
                            new StackPanel() {
                                Orientation = Orientation.Vertical,
                                Children = { stackPanel, stackPanel2
                                } }
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
                                            new RadRibbonButton {  Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Medium, Text = "Input"},
                                            new RadRibbonButton {  Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Medium},
                                        }
                                    },
                                    new RadRibbonButton {  Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Medium}
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
    }
}
