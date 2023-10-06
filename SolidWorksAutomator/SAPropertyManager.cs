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
        /// The name of the property to update
        /// </summary>
        public string PrpName {  get; set; }

        public string PrpType { get; set; }

        public string PrpValue { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public SAPropertyManager()
        {
            
        }
        #endregion

        /// <summary>
        /// Set the value of the author custom property
        /// </summary>
        /// <param name="app"></param>
        public void SetCustomProperty(ISwApplication app, string prpName, string prpValue)
        {
            SldWorks swApp = (SldWorks)app.Sw;

            ModelDoc2 swModel = swApp.IActiveDoc2;

            CustomPropertyManager swCustProp = swModel.Extension.get_CustomPropertyManager("");

            swCustProp.Add3(prpName, (int)swCustomInfoType_e.swCustomInfoText, prpValue, (int)swCustomPropertyAddOption_e.swCustomPropertyReplaceValue);
        }
    }
}
