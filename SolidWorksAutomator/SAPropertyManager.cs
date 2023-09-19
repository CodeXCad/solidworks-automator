using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xarial.XCad.SolidWorks;
using static System.Net.Mime.MediaTypeNames;

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

        public void OpenDocument(ISwApplication app)
        {
            SldWorks swApp = (SldWorks)app.Sw;

            int err = -1;
            int warn = -1;

            swApp.OpenDoc6(@"C:\.test\Part1.SLDPRT", (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_Silent,"", err, warn);
        }
    }
}
