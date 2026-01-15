using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDMA.Api
{

    /// <summary>
    /// The ReferenceContentElement specific version of the <see cref="OdmaContentElement"/> interface
    /// offering short-cuts to all defined OpenDMA properties.
    ///
    /// A ReferenceContentElement represents a reference to external data. The reference is stored as URI to the content location.
    /// </summary>
    public interface IOdmaReferenceContentElement : IOdmaContentElement
    {

        /// <summary>
        /// The URI where the content is stored.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_LOCATION).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_LOCATION).Value</c>.
        /// 
        /// Property opendma:Location: String
        /// [SingleValue] [Writable] [Optional]
        /// </summary>
        string? Location { get; set; }

    }

}
