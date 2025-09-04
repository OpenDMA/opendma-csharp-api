using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDMA.Api
{

    /// <summary>
    /// A Document is the atomic element users work on in a content based environment. It can be compared to a file in a file system. Unlike files, it may consist of multiple octet streams. These content streams can for example contain images of the individual pages that make up the document. A Document is able to keep track of its changes (versioning) and manage the access to it (checkin and checkout).
    /// </summary>
    public interface IOdmaDocument : IOdmaObject
    {

        /// <summary>
        /// The title of this document.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_TITLE).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_TITLE).Value</c>.
        /// 
        /// Property opendma:Title: String
        /// [SingleValue] [Writable] [Optional]
        /// Typically a human friendly readable description of this document. Does not need to be a file name, but can be the file name.
        /// </summary>
        string? Title { get; set; }

        /// <summary>
        /// Identifier of this version consisting of a set of numbers separated by a point (e.g. 1.2.3).<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_VERSION).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_VERSION).Value</c>.
        /// 
        /// Property opendma:Version: String
        /// [SingleValue] [ReadOnly] [Optional]
        /// This value is heavily vendor specific. You should not have any expectations of the format.
        /// </summary>
        string? Version { get; }

        /// <summary>
        /// Reference to a opendma:VersionCollection object representing all versions of this document or null if versioning is not supported.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_VERSIONCOLLECTION).GetReference()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_VERSIONCOLLECTION).Value</c>.
        /// 
        /// Property opendma:VersionCollection: Reference to VersionCollection (opendma)
        /// [SingleValue] [ReadOnly] [Optional]
        /// </summary>
        IOdmaVersionCollection? VersionCollection { get; }

        /// <summary>
        /// The unique object identifier identifying this logical document independent from the specific version inside its opendma:Repository.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_VERSIONINDEPENDENTID).GetId()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_VERSIONINDEPENDENTID).Value</c>.
        /// 
        /// Property opendma:VersionIndependentId: String
        /// [SingleValue] [ReadOnly] [Required]
        /// Retrieving this Id from the Repository will result in the latest version
        /// </summary>
        OdmaId VersionIndependentId { get; }

        /// <summary>
        /// The global unique object identifier globally identifying this logical document independent from the specific version.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_VERSIONINDEPENDENTGUID).GetGuid()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_VERSIONINDEPENDENTGUID).Value</c>.
        /// 
        /// Property opendma:VersionIndependentGuid: String
        /// [SingleValue] [ReadOnly] [Required]
        /// </summary>
        OdmaGuid VersionIndependentGuid { get; }

        /// <summary>
        /// Set of opendma:ContentElement objects representing the individual binary elements this document is made up of.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_CONTENTELEMENTS).GetReferenceEnumerable()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_CONTENTELEMENTS).Value</c>.
        /// 
        /// Property opendma:ContentElements: Reference to ContentElement (opendma)
        /// [MultiValue] [Writable] [Optional]
        /// Typically has only one element. Can contain more then one element in rare cases, e.g. if individual pages of a document are scanned as separate images
        /// </summary>
        IEnumerable<IOdmaContentElement> ContentElements { get; }

        /// <summary>
        /// The combined conent type of the whole Document, calculated from the content types of each ContentElement.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_COMBINEDCONTENTTYPE).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_COMBINEDCONTENTTYPE).Value</c>.
        /// 
        /// Property opendma:CombinedContentType: String
        /// [SingleValue] [Writable] [Optional]
        /// </summary>
        string? CombinedContentType { get; set; }

        /// <summary>
        /// The dedicated primary ContentElement. May only be null if ContentElements is empty..<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_PRIMARYCONTENTELEMENT).GetReference()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_PRIMARYCONTENTELEMENT).Value</c>.
        /// 
        /// Property opendma:PrimaryContentElement: Reference to ContentElement (opendma)
        /// [SingleValue] [Writable] [Optional]
        /// </summary>
        IOdmaContentElement? PrimaryContentElement { get; set; }

        /// <summary>
        /// The timestamp when this version of this document has been created.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_CREATEDAT).GetDateTime()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_CREATEDAT).Value</c>.
        /// 
        /// Property opendma:CreatedAt: DateTime
        /// [SingleValue] [ReadOnly] [Optional]
        /// </summary>
        DateTime? CreatedAt { get; }

        /// <summary>
        /// The User who created this version of this document.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_CREATEDBY).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_CREATEDBY).Value</c>.
        /// 
        /// Property opendma:CreatedBy: String
        /// [SingleValue] [ReadOnly] [Optional]
        /// </summary>
        string? CreatedBy { get; }

        /// <summary>
        /// The timestamp when this version of this document has been modified the last time.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_LASTMODIFIEDAT).GetDateTime()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_LASTMODIFIEDAT).Value</c>.
        /// 
        /// Property opendma:LastModifiedAt: DateTime
        /// [SingleValue] [ReadOnly] [Optional]
        /// </summary>
        DateTime? LastModifiedAt { get; }

        /// <summary>
        /// The user who modified this version of this document the last time.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_LASTMODIFIEDBY).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_LASTMODIFIEDBY).Value</c>.
        /// 
        /// Property opendma:LastModifiedBy: String
        /// [SingleValue] [ReadOnly] [Optional]
        /// </summary>
        string? LastModifiedBy { get; }

        /// <summary>
        /// Indicates if this document is checked out.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_CHECKEDOUT).GetBoolean()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_CHECKEDOUT).Value</c>.
        /// 
        /// Property opendma:CheckedOut: Boolean
        /// [SingleValue] [ReadOnly] [Required]
        /// </summary>
        bool CheckedOut { get; }

        /// <summary>
        /// The timestamp when this version of the document has been checked out, null if this document is not checked out.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_CHECKEDOUTAT).GetDateTime()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_CHECKEDOUTAT).Value</c>.
        /// 
        /// Property opendma:CheckedOutAt: DateTime
        /// [SingleValue] [ReadOnly] [Optional]
        /// </summary>
        DateTime? CheckedOutAt { get; }

        /// <summary>
        /// The user who checked out this version of this document, null if this document is not checked out.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_CHECKEDOUTBY).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_CHECKEDOUTBY).Value</c>.
        /// 
        /// Property opendma:CheckedOutBy: String
        /// [SingleValue] [ReadOnly] [Optional]
        /// Full description follows.
        /// </summary>
        string? CheckedOutBy { get; }

    }

}
