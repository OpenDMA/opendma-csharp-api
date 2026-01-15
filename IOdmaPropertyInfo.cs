using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDMA.Api
{

    /// <summary>
    /// The PropertyInfo specific version of the <see cref="OdmaObject"/> interface
    /// offering short-cuts to all defined OpenDMA properties.
    ///
    /// Describes a property in OpenmDMA. Every object in OpenDMA has a reference to an opendma:Class which has the opendma:Properties set of PropertyInfo objects. Each describes one of the properties on the object.
    /// </summary>
    public interface IOdmaPropertyInfo : IOdmaObject
    {

        /// <summary>
        /// The name part of the qualified name of this property.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_NAME).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_NAME).Value</c>.
        /// 
        /// Property opendma:Name: String
        /// [SingleValue] [Writable] [Required]
        /// The qualified name is a technical identifier that typically has some restrictions, e.g. for database table names. The DisplayName in contrast is tailored for end users.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The namespace part of the qualified name of this property.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_NAMESPACE).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_NAMESPACE).Value</c>.
        /// 
        /// Property opendma:Namespace: String
        /// [SingleValue] [Writable] [Optional]
        /// The qualified name is a technical identifier that typically has some restrictions, e.g. for database table names. The DisplayName in contrast is tailored for end users.
        /// </summary>
        string? Namespace { get; set; }

        /// <summary>
        /// Text shown to end users to refer to this property.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_DISPLAYNAME).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_DISPLAYNAME).Value</c>.
        /// 
        /// Property opendma:DisplayName: String
        /// [SingleValue] [Writable] [Required]
        /// The qualified name is a technical identifier that typically has some restrictions, e.g. for database table names. The DisplayName in contrast is tailored for end users.
        /// </summary>
        string DisplayName { get; set; }

        /// <summary>
        /// Numeric data type ID.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_DATATYPE).GetInteger()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_DATATYPE).Value</c>.
        /// 
        /// Property opendma:DataType: Integer
        /// [SingleValue] [Writable] [Required]
        /// The data type of the property described by this object. See also the OdmaType enumeration for a mapping between the numeric type id and the type.
        /// </summary>
        int DataType { get; set; }

        /// <summary>
        /// The opendma:Class values of the property described by this object must be an instance of if and only if the data type is "Reference" (8), null otherwise.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_REFERENCECLASS).GetReference()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_REFERENCECLASS).Value</c>.
        /// 
        /// Property opendma:ReferenceClass: Reference to Class (opendma)
        /// [SingleValue] [Writable] [Optional]
        /// </summary>
        IOdmaClass? ReferenceClass { get; set; }

        /// <summary>
        /// Indicates if this property has single or multi cardinality.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_MULTIVALUE).GetBoolean()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_MULTIVALUE).Value</c>.
        /// 
        /// Property opendma:MultiValue: Boolean
        /// [SingleValue] [Writable] [Required]
        /// </summary>
        bool MultiValue { get; set; }

        /// <summary>
        /// Indicates if at least one value is required.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_REQUIRED).GetBoolean()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_REQUIRED).Value</c>.
        /// 
        /// Property opendma:Required: Boolean
        /// [SingleValue] [Writable] [Required]
        /// </summary>
        bool Required { get; set; }

        /// <summary>
        /// Indicates if this property can be updated.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_READONLY).GetBoolean()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_READONLY).Value</c>.
        /// 
        /// Property opendma:ReadOnly: Boolean
        /// [SingleValue] [Writable] [Required]
        /// </summary>
        bool ReadOnly { get; set; }

        /// <summary>
        /// Indicates if this class should be hidden from end users and probably administrators.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_HIDDEN).GetBoolean()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_HIDDEN).Value</c>.
        /// 
        /// Property opendma:Hidden: Boolean
        /// [SingleValue] [Writable] [Required]
        /// </summary>
        bool Hidden { get; set; }

        /// <summary>
        /// Indicates if instances of this property are owned and managed by the system.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_SYSTEM).GetBoolean()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_SYSTEM).Value</c>.
        /// 
        /// Property opendma:System: Boolean
        /// [SingleValue] [Writable] [Required]
        /// </summary>
        bool System { get; set; }

        /// <summary>
        /// List of opendma:ChoiceValue instances each describing one valid value for this property.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_CHOICES).GetReferenceEnumerable()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_CHOICES).Value</c>.
        /// 
        /// Property opendma:Choices: Reference to ChoiceValue (opendma)
        /// [MultiValue] [Writable] [Optional]
        /// OpenDMA can restrict values of a property to a predefined set of valid values. In this case, this set is not empty and each opendma:ChoiceValue describes one valid option. If this set is empty, any value is allowed.
        /// </summary>
        IEnumerable<IOdmaChoiceValue> Choices { get; }

        /// <summary>
        /// The qualified name of this class.
        /// A convenience shortcut to getting the name and namespace separately
        /// </summary>
        /// <returns>the qualified name of this class.</returns>
        OdmaQName QName { get; }

    }

}
