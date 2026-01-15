using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDMA.Api
{

    /// <summary>
    /// Objects with this aspect record information about their creation and their last modification.
    /// </summary>
    public interface IOdmaAuditStamped : IOdmaObject
    {

        /// <summary>
        /// The timestamp when this object has been created.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_CREATEDAT).GetDateTime()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_CREATEDAT).Value</c>.
        /// 
        /// Property opendma:CreatedAt: DateTime
        /// [SingleValue] [ReadOnly] [Optional]
        /// </summary>
        DateTime? CreatedAt { get; }

        /// <summary>
        /// The User who created this object.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_CREATEDBY).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_CREATEDBY).Value</c>.
        /// 
        /// Property opendma:CreatedBy: String
        /// [SingleValue] [ReadOnly] [Optional]
        /// </summary>
        string? CreatedBy { get; }

        /// <summary>
        /// The timestamp when this object has been modified the last time.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_LASTMODIFIEDAT).GetDateTime()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_LASTMODIFIEDAT).Value</c>.
        /// 
        /// Property opendma:LastModifiedAt: DateTime
        /// [SingleValue] [ReadOnly] [Optional]
        /// </summary>
        DateTime? LastModifiedAt { get; }

        /// <summary>
        /// The user who modified this object the last time.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_LASTMODIFIEDBY).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_LASTMODIFIEDBY).Value</c>.
        /// 
        /// Property opendma:LastModifiedBy: String
        /// [SingleValue] [ReadOnly] [Optional]
        /// </summary>
        string? LastModifiedBy { get; }

    }

}
