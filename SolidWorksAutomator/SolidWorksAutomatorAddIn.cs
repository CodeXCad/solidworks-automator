using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xarial.XCad.Base.Attributes;
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
        
        public override void OnConnect()
        {
            CommandManager.AddCommandGroup<SWACommands_e>().CommandClick += OnCommandClick;
        }

        private void OnCommandClick(SWACommands_e spec)
        {
            switch (spec)
            {
                case SWACommands_e.TestComand:
                    var prpManager = new SAPropertyManager();

                    var swApp = this.Application;

                    prpManager.TextMessage = "You pressed a button!";

                    prpManager.TestFunction(swApp);

                    break;
            }
        }
    }
}
