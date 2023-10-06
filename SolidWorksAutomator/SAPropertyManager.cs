﻿using SolidWorks.Interop.sldworks;
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

        #region Methods
        /// <summary>
        /// Set the value of a custom property
        /// </summary>
        /// <param name="app">The istance of SolidWorks app</param>
        /// <param name="prpName">The name of the property to be changed</param>
        /// <param name="prpValue">The value of the property to be changed</param>
        public void SetCustomProperty(string prpName, string prpValue)
        {

            ModelDoc2 swModel = SolidWorksAutomatorAddIn.swApp.IActiveDoc2;

            CustomPropertyManager swCustProp = swModel.Extension.get_CustomPropertyManager("");

            swCustProp.Add3(prpName, (int)swCustomInfoType_e.swCustomInfoText, prpValue, (int)swCustomPropertyAddOption_e.swCustomPropertyReplaceValue);
        }

        /// <summary>
        /// Set the value of a custom property to an empty string
        /// </summary>
        /// <param name="app">The istance of SolidWorks app</param>
        /// <param name="prpName">The name of the property to be changed</param>
        /// <param name="prpValue">The value of the property to be changed</param>
        public void SetCustomPropertyEmpty(string prpName)
        {

            ModelDoc2 swModel = SolidWorksAutomatorAddIn.swApp.IActiveDoc2;

            CustomPropertyManager swCustProp = swModel.Extension.get_CustomPropertyManager("");

            swCustProp.Add3(prpName, (int)swCustomInfoType_e.swCustomInfoText, "", (int)swCustomPropertyAddOption_e.swCustomPropertyReplaceValue);
        }

        #endregion
    }
}
