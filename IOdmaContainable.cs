using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDMA.Api
{

    /// <summary>
    /// The Containable aspect is used by all classes and aspects that can be contained in a Container.
    /// </summary>
    public interface IOdmaContainable : IOdmaObject
    {

        /// <summary>
        /// The set of container objects this Containable is contained in.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_CONTAINEDIN).GetReferenceEnumerable()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_CONTAINEDIN).Value</c>.
        /// 
        /// Property opendma:ContainedIn: Reference to Container (opendma)
        /// [MultiValue] [ReadOnly] [Optional]
        /// </summary>
        IEnumerable<IOdmaContainer> ContainedIn { get; }

        /// <summary>
        /// The set of associations that bind this Containable in the opendma:Conatiner objects.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_CONTAINEDINASSOCIATIONS).GetReferenceEnumerable()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_CONTAINEDINASSOCIATIONS).Value</c>.
        /// 
        /// Property opendma:ContainedInAssociations: Reference to Association (opendma)
        /// [MultiValue] [ReadOnly] [Optional]
        /// </summary>
        IEnumerable<IOdmaAssociation> ContainedInAssociations { get; }

    }

}
