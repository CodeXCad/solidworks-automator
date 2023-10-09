using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
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

            // Check if something is selected
            // If something is selected get the list of model objects
            // If nothing is selected add the active model to the list of model object
            // SetCustomProperty to the list of model object
            var prpManager = new SAPropertyManager();

            string PRP_NAME = "Disegnatore";
            string PRP_VALUE = "Mollo A.";

            prpManager.SetCustomProperty(PRP_NAME, PRP_VALUE);
        }
    }
}
