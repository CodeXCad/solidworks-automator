using EPDM.Interop.epdm;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using SolidWorksAutomator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SolidWorksAutomator
{
    public class SetAuthorMacro
    {
        /// <summary>
        /// Write the username connected to PDM in the custom property of the selected file or in the active file if selection is empty
        /// </summary>
        public static void SetAuthor()
        {
            ModelDoc2 swModel = SolidWorksAutomatorAddIn.swApp.IActiveDoc2;

            #region Pre-conditions validation
            // Check if there is an open file
            if (swModel is null)
            {
                MessageBox.Show("Open a document to set the author.",
                    caption:"Set file author",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                // TODO ? Need to be move to a method?
                return;
            }

            // Check that open file isn't a drawing
            if (swModel.GetType() == (int)swDocumentTypes_e.swDocDRAWING)
            {
                MessageBox.Show("Open a part or an assembly file to set the author.",
                    caption: "Set file author",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            #endregion

            // Get user from PDM
            string userName = SAPdmManager.GetPdmUserName();

            // If nothing is selected add the active model to the list of model object
            List < ModelDoc2> models = SASelectionManager.GetSelectedModels(swModel);

            // Set author in each member of the list of model object
            if (userName != string.Empty)
            {
                for (int i = 0; i < models.Count; i++)
                {
                    var prpManager = new SAPropertyManager();

                    prpManager.SetCustomProperty(models[i], GlobalConfig.AuthorPropName, userName);
                }
            }
        }

        /// <summary>
        /// Write the username connected to PDM in the custom property of the selected file or in the active file if selection is empty
        /// </summary>
        /// <param name="swModel">The active ModelDoc2 istance</param>
        public static void SetAuthor(ModelDoc2 swModel)
        {
            // Get user from PDM
            string userName = SAPdmManager.GetPdmUserName();

            // If nothing is selected add the active model to the list of model object
            List<ModelDoc2> models = SASelectionManager.GetSelectedModels(swModel);

            // Set author in each member of the list of model object
            if (userName != string.Empty)
            {
                for (int i = 0; i < models.Count; i++)
                {
                    var prpManager = new SAPropertyManager();

                    prpManager.SetCustomProperty(models[i], GlobalConfig.AuthorPropName, userName);
                }
            }
        }
    }
}
