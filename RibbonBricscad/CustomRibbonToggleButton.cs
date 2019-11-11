using Bricscad.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Bricscad;
using BricscadApp;
using BricscadDb;
using Bricscad.ApplicationServices;
using System.IO;

namespace RibbonBricscad
{
    public class CustomRibbonToggleButton : RibbonToggleButton
    {
        public CustomRibbonToggleButton(string btnText, string description, string img)
        {
            this.Text = btnText;
            this.LargeImage = img;
            this.ToolTip = description;
            this.ButtonStyle = RibbonButtonStyle.LargeWithText;
            this.Id = btnText.Replace(" ", "").Replace("-", "");
        }

        public static IEnumerable<CustomRibbonToggleButton> GetTabPanelButtons()
        {
            yield return new CustomRibbonToggleButton("Button 01", "Button 01 - Description", "");

            yield return new CustomRibbonToggleButton("Button 02", "Button 02 - Description", "");

            yield return new CustomRibbonToggleButton("Button 03", "Button 03 - Description", "");
        }
    }
}
