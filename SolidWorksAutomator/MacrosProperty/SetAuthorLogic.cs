using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidWorksAutomator.MacrosProperty
{
    public class SetAuthorLogic
    {
        
        public static void SetAuthor()
        {
            var prpManager = new SAPropertyManager();

            string PRP_NAME = "Disegnatore";
            string PRP_VALUE = "Mollo A.";

            prpManager.SetCustomProperty(PRP_NAME, PRP_VALUE);
        }
    }
}
