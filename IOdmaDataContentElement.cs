using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDMA.Api
{

    /// <summary>
    /// The DataContentElement specific version of the <see cref="OdmaContentElement"/> interface
    /// offering short-cuts to all defined OpenDMA properties.
    ///
    /// A DataContentElement represents one atomic octet stream. The binary data is stored together with meta data like size and filename
    /// </summary>
    public interface IOdmaDataContentElement : IOdmaContentElement
    {

        /// <summary>
        /// The binary data of this content element.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_CONTENT).GetContent()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_CONTENT).Value</c>.
        /// 
        /// Property opendma:Content: Content
        /// [SingleValue] [Writable] [Optional]
        /// </summary>
        IOdmaContent? Content { get; set; }

        /// <summary>
        /// The size of the data in number of octets.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_SIZE).GetLong()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_SIZE).Value</c>.
        /// 
        /// Property opendma:Size: Long
        /// [SingleValue] [ReadOnly] [Optional]
        /// </summary>
        long? Size { get; }

        /// <summary>
        /// The optional file name of the data.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_FILENAME).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_FILENAME).Value</c>.
        /// 
        /// Property opendma:FileName: String
        /// [SingleValue] [Writable] [Optional]
        /// </summary>
        string? FileName { get; set; }

    }

}
