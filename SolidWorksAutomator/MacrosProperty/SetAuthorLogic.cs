using EdmLib;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using SolidWorksAutomator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolidWorksAutomator
{
    public class SetAuthorLogic
    {
        /// <summary>
        /// Write the author in the custom properties
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

            // Connect to PDM
            IEdmVault5 valut = new EdmVault5();
            valut.LoginAuto(GlobalConfig.VaultName, 0);

            if (valut.IsLoggedIn)
            {
                IEdmUserMgr5 userMgr = (IEdmUserMgr5)valut;

                IEdmUser6 user = (IEdmUser6)userMgr.GetLoggedInUser();

                string userName = (string)user.UserData;
            }

            string PRP_VALUE = "Mollo A.";
            string PRP_NAME = "Disegnatore";

            // Check if something is selected and get the list of selected components
            List<Component2> vComp = new List<Component2>();

            vComp = SASelectionManager.GetSelectedComponents((SelectionMgr)swModel.SelectionManager);

            // If nothing is selected add the active model to the list of model object
            List<ModelDoc2> models = new List<ModelDoc2>();

            if (vComp.Count == 0)
            {
                models.Add(swModel);
                
            }
            else
            {
                for (int i = 0; i < vComp.Count; i++)
                {
                    ModelDoc2 selModel = (ModelDoc2)vComp[i].GetModelDoc2();
                    models.Add(selModel);
                }
            }

            // SetCustomProperty to the list of model object
            for (int i = 0; i < models.Count; i++)
            {
                var prpManager = new SAPropertyManager();

                prpManager.SetCustomProperty(models[i], PRP_NAME, PRP_VALUE);                
            }
        }
    }
}
