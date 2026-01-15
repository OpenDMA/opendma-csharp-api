using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDMA.Api
{

    /// <summary>
    /// The Repository specific version of the <see cref="OdmaObject"/> interface
    /// offering short-cuts to all defined OpenDMA properties.
    ///
    /// A Repository represents a place where all Objects are stored. It often constitues a data isolation boundary where objects with different management requirements or access restrictions are separated into different repositories. Qualified names of classes and properties as well as unique object identifiers are only unique within a repository. They can be reused across different repositories. Object references are limited in scope within a single repository.
    /// </summary>
    public interface IOdmaRepository : IOdmaObject
    {

        /// <summary>
        /// The internal technical name of this repository.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_NAME).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_NAME).Value</c>.
        /// 
        /// Property opendma:Name: String
        /// [SingleValue] [Writable] [Required]
        /// The name is a technical identifier that typically has some restrictions, e.g. for database table names. The DisplayName in contrast is tailored for end users.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The text shown to end users to refer to this repository.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_DISPLAYNAME).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_DISPLAYNAME).Value</c>.
        /// 
        /// Property opendma:DisplayName: String
        /// [SingleValue] [Writable] [Required]
        /// The name is a technical identifier that typically has some restrictions, e.g. for database table names. The DisplayName in contrast is tailored for end users.
        /// </summary>
        string DisplayName { get; set; }

        /// <summary>
        /// Valid class object describing the class hierarchy root.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_ROOTCLASS).GetReference()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_ROOTCLASS).Value</c>.
        /// 
        /// Property opendma:RootClass: Reference to Class (opendma)
        /// [SingleValue] [ReadOnly] [Required]
        /// </summary>
        IOdmaClass RootClass { get; }

        /// <summary>
        /// Set of valid aspect objects without a super class.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_ROOTASPECTS).GetReferenceEnumerable()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_ROOTASPECTS).Value</c>.
        /// 
        /// Property opendma:RootAspects: Reference to Class (opendma)
        /// [MultiValue] [ReadOnly] [Optional]
        /// </summary>
        IEnumerable<IOdmaClass> RootAspects { get; }

        /// <summary>
        /// Object that has the opendma:Folder aspect representing the single root if this repository has a dedicated folder tree, null otherwise.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_ROOTFOLDER).GetReference()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_ROOTFOLDER).Value</c>.
        /// 
        /// Property opendma:RootFolder: Reference to Folder (opendma)
        /// [SingleValue] [ReadOnly] [Optional]
        /// Full description follows.
        /// </summary>
        IOdmaFolder? RootFolder { get; }

    }

}
