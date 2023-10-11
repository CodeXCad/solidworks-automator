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
        [Description("A collection of SolidWorks macro")]
        public enum SWACommands_e
        {
            [Title("Set author")]
            [Description("Write the author in the custom properties")]
            SetAuthor,
            [Title("Export file")]
            [Description("Export the open file in multiple formats")]
            ExportFile
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
                case SWACommands_e.SetAuthor:
                    SetAuthorMacro.SetAuthor();
                    break;
                case SWACommands_e.ExportFile:
                    ExportFileMacro.ExportFile();
                    break;
            }
        }
    }
}
