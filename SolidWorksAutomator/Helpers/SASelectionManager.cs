using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;

namespace SolidWorksAutomator.Helpers
{
    internal class SASelectionManager
    {
        /// <summary>
        /// Get the selected components
        /// </summary>
        /// <param name="selMgr">The model selection manager object</param>
        public static List<Component2> GetSelectedComponents(SelectionMgr selMgr)
        {
            List<Component2> swComp = new List<Component2>();

            for (int i = 0; i < selMgr.GetSelectedObjectCount2(-1); i++)
            {
                Component2 swComponent = (Component2)selMgr.GetSelectedObjectsComponent4(i + 1, -1);
                swComp.Add(swComponent);
            }

            return swComp;
        }
    }
}
