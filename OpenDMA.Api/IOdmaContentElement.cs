using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDMA.Api
{

    /// <summary>
    /// A ContentElement represents one atomic content element the Documents are made of. This abstract (non instantiable) base class defines the type of content and the position of this element in the sequence of all content elements.
    /// </summary>
    public interface IOdmaContentElement : IOdmaObject
    {

        /// <summary>
        /// The content type (aka MIME type) of the content represented by this element.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_CONTENTTYPE).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_CONTENTTYPE).Value</c>.
        /// 
        /// Property opendma:ContentType: String
        /// [SingleValue] [Writable] [Optional]
        /// </summary>
        string? ContentType { get; set; }

        /// <summary>
        /// The position of this element in the list of all content elements of the containing document.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_POSITION).GetInteger()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_POSITION).Value</c>.
        /// 
        /// Property opendma:Position: Integer
        /// [SingleValue] [ReadOnly] [Optional]
        /// </summary>
        int? Position { get; }

    }

}
