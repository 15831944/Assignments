using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bricscad;
using BricscadApp;
using BricscadDb;
using Bricscad.ApplicationServices;
using Bricscad.Windows;
using Teigha.Runtime;
using System.ComponentModel;

namespace ClassLibrary2.Model
{
    public class RibbonTab_CS : DisposableWrapper, ICloneable
    {
        RibbonTab ribbonTab = new RibbonTab();
        public string Name { get; set; }
        public string Title { get; set; }
        public RibbonPanelCollection Panels { get; }
        public bool IsEnabled { get; set; }
        public string Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        
        public RibbonTab_CS()
        {
            this.Name = ribbonTab.Name;
            this.Title = ribbonTab.Title;
            this.IsEnabled = ribbonTab.IsEnabled;
            this.Id = ribbonTab.Id;
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        protected override void DeleteUnmanagedObject()
        {
            throw new NotImplementedException();
        }
    }
}
