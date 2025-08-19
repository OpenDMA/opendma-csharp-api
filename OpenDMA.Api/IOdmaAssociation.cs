using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDMA.Api
{

    /// <summary>
    /// An Association represents the directed link between an opendma:Container and an opendma:Containable object.
    /// </summary>
    public interface IOdmaAssociation : IOdmaObject
    {

        /// <summary>
        /// The name of this association.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_NAME).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_NAME).Value</c>.
        /// 
        /// Property opendma:Name: String
        /// [SingleValue] [Writable] [Required]
        /// This name is used to refer to this specific association in the context of it's container and tell tem apart. Many systems pose additional constraints on this name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The source of this directed link.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_CONTAINER).GetReference()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_CONTAINER).Value</c>.
        /// 
        /// Property opendma:Container: Reference to Container (opendma)
        /// [SingleValue] [Writable] [Required]
        /// </summary>
        IOdmaContainer Container { get; set; }

        /// <summary>
        /// The destination of this directed link.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_CONTAINABLE).GetReference()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_CONTAINABLE).Value</c>.
        /// 
        /// Property opendma:Containable: Reference to Containable (opendma)
        /// [SingleValue] [Writable] [Required]
        /// </summary>
        IOdmaContainable Containable { get; set; }

        /// <summary>
        /// The timestamp when this association has been created.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_CREATEDAT).GetDateTime()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_CREATEDAT).Value</c>.
        /// 
        /// Property opendma:CreatedAt: DateTime
        /// [SingleValue] [ReadOnly] [Optional]
        /// </summary>
        DateTime? CreatedAt { get; }

        /// <summary>
        /// The user who created this association.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_CREATEDBY).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_CREATEDBY).Value</c>.
        /// 
        /// Property opendma:CreatedBy: String
        /// [SingleValue] [ReadOnly] [Optional]
        /// </summary>
        string? CreatedBy { get; }

        /// <summary>
        /// The timestamp when this association has been modified the last time.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_LASTMODIFIEDAT).GetDateTime()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_LASTMODIFIEDAT).Value</c>.
        /// 
        /// Property opendma:LastModifiedAt: DateTime
        /// [SingleValue] [ReadOnly] [Optional]
        /// </summary>
        DateTime? LastModifiedAt { get; }

        /// <summary>
        /// The user who modified this association the last time.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_LASTMODIFIEDBY).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_LASTMODIFIEDBY).Value</c>.
        /// 
        /// Property opendma:LastModifiedBy: String
        /// [SingleValue] [ReadOnly] [Optional]
        /// </summary>
        string? LastModifiedBy { get; }

    }

}
