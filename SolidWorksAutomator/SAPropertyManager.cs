using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xarial.XCad.SolidWorks;

namespace SolidWorksAutomator
{
    /// <summary>
    /// Manage the SolidWorks custom properties
    /// </summary>
    internal class SAPropertyManager
    {
        #region Class properties

        /// <summary>
        /// The text to be showed to the user
        /// </summary>
        public string TextMessage {  get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public SAPropertyManager()
        {
            TextMessage = string.Empty;
        }
        #endregion

        public void TestFunction(ISwApplication app)
        {
            app.ShowMessageBox(this.TextMessage);
        }
    }
}
