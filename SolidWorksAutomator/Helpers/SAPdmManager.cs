using EPDM.Interop.epdm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public static string GetPdmUserName()
        {
            try
            {
                IEdmVault5 pdmValut = new EdmVault5();

                pdmValut.LoginAuto(GlobalConfig.VaultName, 0);

                if (pdmValut.IsLoggedIn)
                {
                    IEdmUserMgr5 userMgr = (IEdmUserMgr5)pdmValut;

                    IEdmUser6 user = (IEdmUser6)userMgr.GetLoggedInUser();

                    return (string)user.UserData;
                }
                else
                {
                    return Environment.UserName;
                }
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("Unable to connect to SolidWorks PDM. Author not set.", "Set author");
                Debug.WriteLine(ex.Message);
                return string.Empty;
            }
        }
    }
}
