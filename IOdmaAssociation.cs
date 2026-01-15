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

    }

}
