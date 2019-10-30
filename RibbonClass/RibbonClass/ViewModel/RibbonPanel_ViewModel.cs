using RibbonClass.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Telerik.Windows.Controls;

namespace RibbonClass.ViewModel
{
    class RibbonPanel_ViewModel
    {
        public ObservableCollection<RibbonPanelCustom> ribbonPanelCustoms { get; set; }
        public void ReadXML(XmlNodeList ListPanel)
        {
            ObservableCollection<RibbonPanelCustom> _ribbonPanelCustoms = new ObservableCollection<RibbonPanelCustom>();
            foreach (XmlNode panelnode in ListPanel)
            {
                //string tab = panelnode.SelectSingleNode("Items").InnerText;
                String name = panelnode.Attributes.GetNamedItem("Name").Value;
                String title = panelnode.Attributes.GetNamedItem("Header").Value;
                String id = panelnode.Attributes.GetNamedItem("Name").Value;
                String isEnabled = panelnode.Attributes.GetNamedItem("IsEnabled").Value;
                //XmlNodeList panelSources = panelnode.SelectNodes("/Items");

                XmlNode panelSource = panelnode.SelectSingleNode("Items");
                RibbonPanelSource_ViewModel panelSource_ViewModel = new RibbonPanelSource_ViewModel();
                panelSource_ViewModel.ReadXml(panelSource);
                //foreach (XmlNode panelSource in panelSources)
                //{
                //    panelSource_ViewModel.ReadXml(panelSource);
                //}


                RibbonPanelCustom ribbonPanelCustom = new RibbonPanelCustom();
                //ribbonPanelCustom.Tab = tab;
                ribbonPanelCustom.IsEnabled = isEnabled.Equals("True");
                ribbonPanelCustom.RibbonPanelSourceCustom = panelSource_ViewModel.ribbonPanelSource;
                _ribbonPanelCustoms.Add(ribbonPanelCustom);

                //string tab = panelnode.SelectSingleNode("Tab").InnerText;
                //string isEnabled = panelnode.SelectSingleNode("IsEnabled").InnerText;
                //XmlNode panelSource = panelnode.SelectSingleNode("PanelSource");
                //RibbonPanelSource_ViewModel panelSource_ViewModel = new RibbonPanelSource_ViewModel();
                //panelSource_ViewModel.ReadXml(panelSource);
                //RibbonPanelCustom ribbonPanelCustom = new RibbonPanelCustom();
                //ribbonPanelCustom.Tab = tab;
                //ribbonPanelCustom.IsEnabled = isEnabled.Equals("True");
                //ribbonPanelCustom.RibbonPanelSourceCustom = panelSource_ViewModel.ribbonPanelSource;
                //_ribbonPanelCustoms.Add(ribbonPanelCustom);
            }
            ribbonPanelCustoms = _ribbonPanelCustoms;
        }
        public static ObservableCollection<RadRibbonGroup> ConverToTelerik(ObservableCollection<RibbonPanelCustom> panelCustoms)
        {
            ObservableCollection<RadRibbonGroup> temp = new ObservableCollection<RadRibbonGroup>();
            foreach(RibbonPanelCustom panelCustom in panelCustoms)
            {
                RibbonPanelSourceCustom source = panelCustom.RibbonPanelSourceCustom;
                RibbonItem_ViewModel.ConverToTelerik(source.RibbonItemsCustom);
                temp.Add(new RadRibbonGroup() { Header = source.Title, ItemsSource = RibbonItem_ViewModel.RadControl });
            }
            return temp;
        }

    }
}
