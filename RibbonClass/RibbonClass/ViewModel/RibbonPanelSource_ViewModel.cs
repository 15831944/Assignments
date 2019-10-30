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
    public class RibbonPanelSource_ViewModel
    {
        public RibbonPanelSourceCustom ribbonPanelSource { get; set; }
        public void ReadXml(XmlNode node)
        {

            String name = node.Attributes.GetNamedItem("Name").Value;
            String title = node.Attributes.GetNamedItem("Header").Value;
            String id = node.Attributes.GetNamedItem("Name").Value;
            String isEnabled = node.Attributes.GetNamedItem("IsEnabled").Value;

            //XmlNodeList Items = node.SelectNodes("Items");
            RibbonItem_ViewModel ribbonItems = new RibbonItem_ViewModel();
            ribbonItems.ReadXML(node.ChildNodes);
            ribbonPanelSource = new RibbonPanelSourceCustom()
            {
                Id = id,
                Name = name,
                Title = title,
                RibbonItemsCustom = ribbonItems.RibbonItems
            };

            //String name = node.SelectSingleNode("Name").InnerText;
            //String title = node.SelectSingleNode("Title").InnerText;
            //String id = node.SelectSingleNode("Id").InnerText;
            //XmlNodeList Items = node.SelectNodes("Items/Item");
            //RibbonItem_ViewModel ribbonItems = new RibbonItem_ViewModel();
            //ribbonItems.ReadXML(Items);
            //ribbonPanelSource = new RibbonPanelSourceCustom()
            //{
            //    Id = id,
            //    Name = name,
            //    Title = title,
            //    RibbonItemsCustom = ribbonItems.RibbonItems
            //};
        }

    }
}
