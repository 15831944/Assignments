using BricscadApp;
using BricscadDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RibbonBricscad
{
    public class TBButton
    {
        public string Name { get; set; }
        
        public string Macro { get; set; }

        public string HelpString { get; set; }

        public string SmallIconName { get; set; }

        public string LargeIconName { get; set; }

        public TBButton(string Name, string Macro, string HelpString, string SmallIconName, string LargeIconName)
        {
            this.Name = Name;
            this.Macro = Macro;
            this.HelpString = HelpString;
            this.SmallIconName = SmallIconName;
            this.LargeIconName = LargeIconName;
        }
    }
}
