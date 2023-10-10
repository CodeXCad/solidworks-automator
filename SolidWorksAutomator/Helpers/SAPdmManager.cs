using EPDM.Interop.epdm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SolidWorksAutomator.Helpers
{
    internal class SAPdmManager
    {
        /// <summary>
        /// Get the username from PDM
        /// </summary>
        /// <param name="pdmValut">The istance to the Vault</param>
        /// <returns>The string of the username connected to the Vault</returns>
        public static string GetPdmUserName(IEdmVault5 pdmValut)
        {
            try
            {
                pdmValut.LoginAuto(GlobalConfig.VaultName, 0);
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show(ex.Message);
                return GlobalConfig.AuthorDefault;
            }


            if (pdmValut.IsLoggedIn)
            {

                IEdmUserMgr5 userMgr = (IEdmUserMgr5)pdmValut;

                IEdmUser6 user = (IEdmUser6)userMgr.GetLoggedInUser();

                return (string)user.UserData;

            }
            else
            {
                return GlobalConfig.AuthorDefault;
            }

        }
    }
}
