using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDMA.Api
{

    /// <summary>
    /// The Class specific version of the <see cref="OdmaObject"/> interface
    /// offering short-cuts to all defined OpenDMA properties.
    ///
    /// Describes Classes and Aspects in OpenDMA. Every object in OpenDMA has a reference to an instance of this class describing it.
    /// </summary>
    public interface IOdmaClass : IOdmaObject
    {

        /// <summary>
        /// The name part of the qualified name of the class described by this object.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_NAME).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_NAME).Value</c>.
        /// 
        /// Property opendma:Name: String
        /// [SingleValue] [Writable] [Required]
        /// The qualified name is a technical identifier that typically has some restrictions, e.g. for database table names. The DisplayName in contrast is tailored for end users.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The namespace part of the qualified name of the class described by this object.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_NAMESPACE).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_NAMESPACE).Value</c>.
        /// 
        /// Property opendma:Namespace: String
        /// [SingleValue] [Writable] [Optional]
        /// The qualified name is a technical identifier that typically has some restrictions, e.g. for database table names. The DisplayName in contrast is tailored for end users.
        /// </summary>
        string? Namespace { get; set; }

        /// <summary>
        /// Text shown to end users to refer to this class.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_DISPLAYNAME).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_DISPLAYNAME).Value</c>.
        /// 
        /// Property opendma:DisplayName: String
        /// [SingleValue] [Writable] [Required]
        /// The qualified name is a technical identifier that typically has some restrictions, e.g. for database table names. The DisplayName in contrast is tailored for end users.
        /// </summary>
        string DisplayName { get; set; }

        /// <summary>
        /// Super class of this class or aspect..<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_SUPERCLASS).GetReference()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_SUPERCLASS).Value</c>.
        /// 
        /// Property opendma:SuperClass: Reference to Class (opendma)
        /// [SingleValue] [ReadOnly] [Optional]
        /// OpenDMA guarantees this relationship to be loop-free. You can use it to explore the class hierarchy starting from the class described by this object. All opendma:PropertyInfo objects contained in the opendma:Properties set of the super class are also part of the opendma:Properties set of this class.
        /// </summary>
        IOdmaClass? SuperClass { get; }

        /// <summary>
        /// List of aspects that are implemented by this class.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_ASPECTS).GetReferenceEnumerable()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_ASPECTS).Value</c>.
        /// 
        /// Property opendma:Aspects: Reference to Class (opendma)
        /// [MultiValue] [Writable] [Optional]
        /// If this object describes an Aspect, i.e. the opendma:Aspect property is true, it cannot have any Aspects itself. For classes, this set contains all elements of the opendma:Aspects set of the super class. All opendma:PropertyInfo objects contained in the opendma:Properties set of any of the opendma:Class objects in this set are also part of the opendma:Properties set of this class.
        /// </summary>
        IEnumerable<IOdmaClass> Aspects { get; }

        /// <summary>
        /// List of properties declared by this class.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_DECLAREDPROPERTIES).GetReferenceEnumerable()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_DECLAREDPROPERTIES).Value</c>.
        /// 
        /// Property opendma:DeclaredProperties: Reference to PropertyInfo (opendma)
        /// [MultiValue] [Writable] [Optional]
        /// Set of opendma:PropertyInfo objects describing properties newly introduced by this level in the class hierarchy. All elements of this set are also contained in the opendma:Properties set. Properties cannot be overwritten, i.e. the qualified nyme of any property described by an opendma:PropertyInfo object in this set cannot be used in the opendma:Properties sets of the super class or any Aspect.
        /// </summary>
        IEnumerable<IOdmaPropertyInfo> DeclaredProperties { get; }

        /// <summary>
        /// List of effective properties.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_PROPERTIES).GetReferenceEnumerable()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_PROPERTIES).Value</c>.
        /// 
        /// Property opendma:Properties: Reference to PropertyInfo (opendma)
        /// [MultiValue] [ReadOnly] [Optional]
        /// Set of opendma:PropertyInfo objects describing all properties of an object of this class. This set combines the opendma:DeclaredProperties set with the opendma:Properties of the super class as well as the opendma:Properties sets of all aspect objects listed in opendma:Aspects. Properties cannot be overwritten, i.e. the qualified nyme of any property described by an opendma:PropertyInfo object in the opendma:DeclaredProperties set cannot be used in the opendma:Properties sets of the super class or any Aspect.
        /// </summary>
        IEnumerable<IOdmaPropertyInfo> Properties { get; }

        /// <summary>
        /// Indicates if this object represents an Aspect (true) or a Class (false).<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_ASPECT).GetBoolean()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_ASPECT).Value</c>.
        /// 
        /// Property opendma:Aspect: Boolean
        /// [SingleValue] [ReadOnly] [Required]
        /// </summary>
        bool Aspect { get; }

        /// <summary>
        /// Indicates if this class should be hidden from end users and probably administrators.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_HIDDEN).GetBoolean()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_HIDDEN).Value</c>.
        /// 
        /// Property opendma:Hidden: Boolean
        /// [SingleValue] [Writable] [Required]
        /// </summary>
        bool Hidden { get; set; }

        /// <summary>
        /// Indicates if instances of this class are owned and managed by the system.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_SYSTEM).GetBoolean()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_SYSTEM).Value</c>.
        /// 
        /// Property opendma:System: Boolean
        /// [SingleValue] [Writable] [Required]
        /// </summary>
        bool System { get; set; }

        /// <summary>
        /// Indicates if instances of this class can by retrieved by their Id.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_RETRIEVABLE).GetBoolean()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_RETRIEVABLE).Value</c>.
        /// 
        /// Property opendma:Retrievable: Boolean
        /// [SingleValue] [ReadOnly] [Required]
        /// </summary>
        bool Retrievable { get; }

        /// <summary>
        /// Indicates if instances of this class can be retrieved in a search.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_SEARCHABLE).GetBoolean()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_SEARCHABLE).Value</c>.
        /// 
        /// Property opendma:Searchable: Boolean
        /// [SingleValue] [ReadOnly] [Required]
        /// </summary>
        bool Searchable { get; }

        /// <summary>
        /// List of classes or aspects that extend this class.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_SUBCLASSES).GetReferenceEnumerable()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_SUBCLASSES).Value</c>.
        /// 
        /// Property opendma:SubClasses: Reference to Class (opendma)
        /// [MultiValue] [ReadOnly] [Optional]
        /// The value of the `opendma:SubClasses` property is exactly the set of valid class objects whose `opendma:SuperClass` property contains a reference to this class info object
        /// </summary>
        IEnumerable<IOdmaClass> SubClasses { get; }

        /// <summary>
        /// The qualified name of this class.
        /// A convenience shortcut to getting the name and namespace separately
        /// </summary>
        /// <returns>the qualified name of this class.</returns>
        OdmaQName QName { get; }

    }

}
