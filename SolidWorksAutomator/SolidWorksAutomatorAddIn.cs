using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xarial.XCad.UI.Commands;

namespace SolidWorksAutomator
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public class SolidWorksAutomatorAddIn : Xarial.XCad.SolidWorks.SwAddInEx
    {
        public enum SWACommands_e
        {
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
                    Application.ShowMessageBox("Test command");
                    break;
            }
        }
    }
}
