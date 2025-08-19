using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDMA.Api
{

    /// <summary>
    /// Root of the class hierarchy. Every class in OpenDMA extends this class. All objects in OpenDMA have the properties defined for this class.
    /// </summary>
    public interface IOdmaObject : IOdmaCoreObject
    {

        /// <summary>
        /// Reference to a valid class object describing this object.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_CLASS).GetReference()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_CLASS).Value</c>.
        /// 
        /// Property opendma:Class: Reference to Class (opendma)
        /// [SingleValue] [ReadOnly] [Required]
        /// The opendma:Class describes the layout and features of this object. Here you can find a set of odma:PropertyInfo objects that describe all the properties with their qualified name, data type and cardinality. It also provides the text to be displayed to users to refer to these objects as well as flags indicating if these objects are system owner or should be hidden from end users.
        /// </summary>
        IOdmaClass OdmaClass { get; }

        /// <summary>
        /// The unique object identifier.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_ID).GetId()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_ID).Value</c>.
        /// 
        /// Property opendma:Id: String
        /// [SingleValue] [ReadOnly] [Required]
        /// This identifier is unique within it's Repository and  must be immutable during the lifetime of this object. You can use it to refer to this object and retrieve it again at a later time.
        /// </summary>
        OdmaId Id { get; }

        /// <summary>
        /// The global unique object identifier.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_GUID).GetGuid()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_GUID).Value</c>.
        /// 
        /// Property opendma:Guid: String
        /// [SingleValue] [ReadOnly] [Required]
        /// A combination of the unique object identifier and the unique repository identifier. Use it to refer to this object across multiple repositories.
        /// </summary>
        OdmaGuid Guid { get; }

        /// <summary>
        /// The Repository this object belongs to.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_REPOSITORY).GetReference()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_REPOSITORY).Value</c>.
        /// 
        /// Property opendma:Repository: Reference to Repository (opendma)
        /// [SingleValue] [ReadOnly] [Required]
        /// </summary>
        IOdmaRepository Repository { get; }

    }

}
