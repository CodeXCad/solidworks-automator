using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SolidWorksAutomator
{
    public class SetAuthorLogic
    {
        /// <summary>
        /// Write the author in the custom properties
        /// </summary>
        public static void SetAuthor()
        {
            // Check if there is an open file
            ModelDoc2 swModel = SolidWorksAutomatorAddIn.swApp.IActiveDoc2;

            if (swModel is null)
            {
                MessageBox.Show("Open a document to set the author.");
            }
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
