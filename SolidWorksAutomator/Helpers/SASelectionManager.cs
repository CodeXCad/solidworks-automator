using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SolidWorksAutomator.Helpers
{
    internal class SASelectionManager
    {
        /// <summary>
        /// Get the selected components
        /// </summary>
        /// <param name="selMgr">The model selection manager object</param>
        /// <returns>A list of Component2</returns>
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

        /// <summary>
        /// Get the list of selected models or the active model if the selection is empty
        /// </summary>
        /// <param name="model">The active ModelDoc2 istance</param>
        /// <returns>The list of selected models</returns>
        public static List<ModelDoc2> GetSelectedModels(ModelDoc2 model)
        {
            // Get the list of selected components
            List<Component2> vComp = new List<Component2>();

            vComp = GetSelectedComponents((SelectionMgr)model.SelectionManager);

            List<ModelDoc2> models = new List<ModelDoc2>();

            if (vComp.Count == 0)
            {
                models.Add(model);

            }
            else
            {
                for (int i = 0; i < vComp.Count; i++)
                {
                    ModelDoc2 selModel = (ModelDoc2)vComp[i].GetModelDoc2();
                    models.Add(selModel);
                }
            }
            
            return models;
        }
    }
}
