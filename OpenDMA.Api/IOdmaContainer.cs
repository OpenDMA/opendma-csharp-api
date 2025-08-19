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

        /// <summary>
        /// The timestamp when this container has been created.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_CREATEDAT).GetDateTime()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_CREATEDAT).Value</c>.
        /// 
        /// Property opendma:CreatedAt: DateTime
        /// [SingleValue] [ReadOnly] [Optional]
        /// </summary>
        DateTime? CreatedAt { get; }

        /// <summary>
        /// The user who created this container.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_CREATEDBY).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_CREATEDBY).Value</c>.
        /// 
        /// Property opendma:CreatedBy: String
        /// [SingleValue] [ReadOnly] [Optional]
        /// </summary>
        string? CreatedBy { get; }

        /// <summary>
        /// The timestamp when this container has been modified the last time.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_LASTMODIFIEDAT).GetDateTime()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_LASTMODIFIEDAT).Value</c>.
        /// 
        /// Property opendma:LastModifiedAt: DateTime
        /// [SingleValue] [ReadOnly] [Optional]
        /// There is no definition what counts as a modification. Some systems update this timestamp when objects are added or removed, other systems only update this timestamp when properties of this object get changed.
        /// </summary>
        DateTime? LastModifiedAt { get; }

        /// <summary>
        /// The user who modified this container the last time.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_LASTMODIFIEDBY).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_LASTMODIFIEDBY).Value</c>.
        /// 
        /// Property opendma:LastModifiedBy: String
        /// [SingleValue] [ReadOnly] [Optional]
        /// There is no definition what counts as a modification. Some systems update this timestamp when objects are added or removed, other systems only update this timestamp when properties of this object get changed.
        /// </summary>
        string? LastModifiedBy { get; }

    }

}
