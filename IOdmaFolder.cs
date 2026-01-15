using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDMA.Api
{

    /// <summary>
    /// The Folder specific version of the <see cref="OdmaContainer"/> interface
    /// offering short-cuts to all defined OpenDMA properties.
    ///
    /// A Folder is an extension of the Container forming one single rooted loop-free tree.
    /// </summary>
    public interface IOdmaFolder : IOdmaContainer
    {

        /// <summary>
        /// The parent folder this folder is contained in.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_PARENT).GetReference()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_PARENT).Value</c>.
        /// 
        /// Property opendma:Parent: Reference to Folder (opendma)
        /// [SingleValue] [Writable] [Optional]
        /// Following this property from folder object to folder object will ultimately lead to the single root folder of the Repository. This is the only folder having a null value for this property
        /// </summary>
        IOdmaFolder? Parent { get; set; }

        /// <summary>
        /// The set of Folder objects that contain this folder in their opendma:Parent property.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_SUBFOLDERS).GetReferenceEnumerable()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_SUBFOLDERS).Value</c>.
        /// 
        /// Property opendma:SubFolders: Reference to Folder (opendma)
        /// [MultiValue] [ReadOnly] [Optional]
        /// Using this property for a tree walk is safe. A folder is guaranteed to be loop free. It is neither defined if this set of objects is also part of the opendma:Containees property nor if there are corresponding association objects in opendma:Associations for each folder in this set.
        /// </summary>
        IEnumerable<IOdmaFolder> SubFolders { get; }

    }

}
