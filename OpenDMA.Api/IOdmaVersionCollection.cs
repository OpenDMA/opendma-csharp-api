using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDMA.Api
{

    /// <summary>
    /// A VersionCollection represents the set of all versions of a Document. Based on the actual document management system, it can represent a single series of versions, a tree of version, or any other versioning concept.
    /// </summary>
    public interface IOdmaVersionCollection : IOdmaObject
    {

        /// <summary>
        /// Set of all versions of a document.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_VERSIONS).GetReferenceEnumerable()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_VERSIONS).Value</c>.
        /// 
        /// Property opendma:Versions: Reference to Document (opendma)
        /// [MultiValue] [ReadOnly] [Required]
        /// </summary>
        IEnumerable<IOdmaDocument> Versions { get; }

        /// <summary>
        /// Latest version of a document.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_LATEST).GetReference()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_LATEST).Value</c>.
        /// 
        /// Property opendma:Latest: Reference to Document (opendma)
        /// [SingleValue] [ReadOnly] [Optional]
        /// </summary>
        IOdmaDocument? Latest { get; }

        /// <summary>
        /// Latest released version of a document if a version has been released.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_RELEASED).GetReference()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_RELEASED).Value</c>.
        /// 
        /// Property opendma:Released: Reference to Document (opendma)
        /// [SingleValue] [ReadOnly] [Optional]
        /// </summary>
        IOdmaDocument? Released { get; }

        /// <summary>
        /// Latest checked out working copy of a document.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_INPROGRESS).GetReference()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_INPROGRESS).Value</c>.
        /// 
        /// Property opendma:InProgress: Reference to Document (opendma)
        /// [SingleValue] [ReadOnly] [Optional]
        /// </summary>
        IOdmaDocument? InProgress { get; }

    }

}
