using RibbonClass.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;
using RibbonClass.Views;
using Telerik.Windows.Controls;

namespace RibbonClass.ViewModel
{
    public class RibbonTab_ViewModel
    {
        public ObservableCollection<RibbonTabCustom> _ribbonTabs { get; set; }
        public ObservableCollection<RadRibbonTab> _telerikTabs { get; set; }
        public void ReadXML()
        {
            ObservableCollection<RibbonTabCustom> ribbonTabCustoms = new ObservableCollection<RibbonTabCustom>();
            //string XMLName = "//Data_RibbonTab.xml";
            string XMLName = "//Data_UI.xml";
            string CurrentDirectory = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(CurrentDirectory + XMLName);
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/RadRibbonView/RadRibbonTab");// 
            //XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Tabs/Tab");
            foreach (XmlNode node in nodeList)
            {
                String name = node.Attributes.GetNamedItem("Name").Value;
                String title = node.Attributes.GetNamedItem("Header").Value;
                String id = node.Attributes.GetNamedItem("Name").Value;
                String isEnabled = node.Attributes.GetNamedItem("IsEnabled").Value;
                XmlNodeList temp = node.ChildNodes.Item(0).ChildNodes;
                XmlNodeList Panels = node.SelectNodes("/Items");// /RadRibbonGroup
                RibbonPanel_ViewModel ribbonPanel_ViewModel = new RibbonPanel_ViewModel();
                ribbonPanel_ViewModel.ReadXML(temp);
                ribbonTabCustoms.Add(new RibbonTabCustom()
                {
                    ID = id,
                    Name = name,
                    Title = title,
                    IsEnabled = isEnabled.Equals("True"),
                    ribbonPanelCustoms = ribbonPanel_ViewModel.ribbonPanelCustoms
                });

                //String name = node.SelectSingleNode("Name").InnerText;
                //String id = node.SelectSingleNode("ID").InnerText;
                //String title = node.SelectSingleNode("Title").InnerText;
                //String isEnabled = node.SelectSingleNode("IsEnabled").InnerText;
                //XmlNodeList Panels = node.SelectNodes("Panels/Panel");
                //RibbonPanel_ViewModel ribbonPanel_ViewModel = new RibbonPanel_ViewModel();
                //ribbonPanel_ViewModel.ReadXML(Panels);
                //ribbonTabCustoms.Add(new RibbonTabCustom()
                //{
                //    ID = id,
                //    Name = name,
                //    Title = title,
                //    IsEnabled = isEnabled.Equals("True"),
                //    ribbonPanelCustoms = ribbonPanel_ViewModel.ribbonPanelCustoms
                //});
            }
            _ribbonTabs = ribbonTabCustoms;
        }
        public void ConverToTelerik()
        {
            ObservableCollection<RadRibbonTab> temp = new ObservableCollection<RadRibbonTab>();
            foreach (RibbonTabCustom tabCustom in _ribbonTabs)
            {
                temp.Add(new RadRibbonTab() {Header=tabCustom.Title, ItemsSource = RibbonPanel_ViewModel.ConverToTelerik(tabCustom.ribbonPanelCustoms) });
            }
            _telerikTabs = temp;
        }
    }
}
