using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xarial.XCad.Base.Attributes;
using Xarial.XCad.SolidWorks;
using Xarial.XCad.UI.Commands;

namespace SolidWorksAutomator
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public class SolidWorksAutomatorAddIn : Xarial.XCad.SolidWorks.SwAddInEx
    {
        [Title("SolidWorks Automator")]
        public enum SWACommands_e
        {
            [Title("Test command")]
            [Description("A test command to display a message to the user")]
            TestComand
        }
        public static SldWorks swApp { get; set; }

        public override void OnConnect()
        {
            CommandManager.AddCommandGroup<SWACommands_e>().CommandClick += OnCommandClick;

            swApp = (SldWorks)this.Application.Sw;
        }

        private void OnCommandClick(SWACommands_e spec)
        {
            switch (spec)
            {
                case SWACommands_e.TestComand:
                    var prpManager = new SAPropertyManager();

                    string PRP_NAME = "Disegnatore";
                    string PRP_VALUE = "Mollo A.";

                    prpManager.SetCustomProperty(PRP_NAME, PRP_VALUE);

                    break;
            }
        }
    }
}
