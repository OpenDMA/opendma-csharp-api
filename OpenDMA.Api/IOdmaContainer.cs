using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDMA.Api
{

    /// <summary>
    /// A Container holds a set of containable objects that are said to be contained in this Container. This list of containees is build up with Association objects based on references to the containmer and the containee. This allows an object to be contained in multiple Containers or in no Container at all. A Container does not enforce a loop-free single rooted tree. Use a folder instead for this requirement.
    /// </summary>
    public interface IOdmaContainer : IOdmaObject
    {

        /// <summary>
        /// The title of this container.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_TITLE).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_TITLE).Value</c>.
        /// 
        /// Property opendma:Title: String
        /// [SingleValue] [Writable] [Optional]
        /// </summary>
        string? Title { get; set; }

        /// <summary>
        /// The set of containable objects contained in this container.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_CONTAINEES).GetReferenceEnumerable()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_CONTAINEES).Value</c>.
        /// 
        /// Property opendma:Containees: Reference to Containable (opendma)
        /// [MultiValue] [ReadOnly] [Optional]
        /// </summary>
        IEnumerable<IOdmaContainable> Containees { get; }

        /// <summary>
        /// The set of associations between this container and the contained objects.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_ASSOCIATIONS).GetReferenceEnumerable()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_ASSOCIATIONS).Value</c>.
        /// 
        /// Property opendma:Associations: Reference to Association (opendma)
        /// [MultiValue] [ReadOnly] [Optional]
        /// </summary>
        IEnumerable<IOdmaAssociation> Associations { get; }

    }

}
