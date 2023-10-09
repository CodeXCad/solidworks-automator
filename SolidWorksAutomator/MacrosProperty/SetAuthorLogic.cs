using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidWorksAutomator
{
    public class SetAuthorLogic
    {
        /// <summary>
        /// Write the author in the custom properties
        /// </summary>
        public static void SetAuthor()
        {
            var prpManager = new SAPropertyManager();

            string PRP_NAME = "Disegnatore";
            string PRP_VALUE = "Mollo A.";

            prpManager.SetCustomProperty(PRP_NAME, PRP_VALUE);
        }
    }
}
