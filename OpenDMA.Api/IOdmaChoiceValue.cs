using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDMA.Api
{

    /// <summary>
    /// The ChoiceValue specific version of the <see cref="OdmaObject"/> interface
    /// offering short-cuts to all defined OpenDMA properties.
    ///
    /// Describes a possible value of a property
    /// </summary>
    public interface IOdmaChoiceValue : IOdmaObject
    {

        /// <summary>
        /// Text shown to end users to refer to this possible value option.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_DISPLAYNAME).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_DISPLAYNAME).Value</c>.
        /// 
        /// Property opendma:DisplayName: String
        /// [SingleValue] [Writable] [Required]
        /// This DisplayName indirections allows Administrators to define friendly descriptions for end users while storing internal numbers or abbreviation in the system
        /// </summary>
        string DisplayName { get; set; }

        /// <summary>
        /// The String value of this choice or null, if the property info this choice is assigned to is not of data type String.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_STRINGVALUE).GetString()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_STRINGVALUE).Value</c>.
        /// 
        /// Property opendma:StringValue: String
        /// [SingleValue] [Writable] [Optional]
        /// Full description follows.
        /// </summary>
        string? StringValue { get; set; }

        /// <summary>
        /// The Integer value of this choice or null, if the property info this choice is assigned to is not of data type Integer.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_INTEGERVALUE).GetInteger()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_INTEGERVALUE).Value</c>.
        /// 
        /// Property opendma:IntegerValue: Integer
        /// [SingleValue] [Writable] [Optional]
        /// Full description follows.
        /// </summary>
        int? IntegerValue { get; set; }

        /// <summary>
        /// The Short value of this choice or null, if the property info this choice is assigned to is not of data type Short.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_SHORTVALUE).GetShort()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_SHORTVALUE).Value</c>.
        /// 
        /// Property opendma:ShortValue: Short
        /// [SingleValue] [Writable] [Optional]
        /// Full description follows.
        /// </summary>
        short? ShortValue { get; set; }

        /// <summary>
        /// The Long value of this choice or null, if the property info this choice is assigned to is not of data type Long.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_LONGVALUE).GetLong()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_LONGVALUE).Value</c>.
        /// 
        /// Property opendma:LongValue: Long
        /// [SingleValue] [Writable] [Optional]
        /// Full description follows.
        /// </summary>
        long? LongValue { get; set; }

        /// <summary>
        /// The Float value of this choice or null, if the property info this choice is assigned to is not of data type Float.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_FLOATVALUE).GetFloat()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_FLOATVALUE).Value</c>.
        /// 
        /// Property opendma:FloatValue: Float
        /// [SingleValue] [Writable] [Optional]
        /// Full description follows.
        /// </summary>
        float? FloatValue { get; set; }

        /// <summary>
        /// The Double value of this choice or null, if the property info this choice is assigned to is not of data type Double.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_DOUBLEVALUE).GetDouble()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_DOUBLEVALUE).Value</c>.
        /// 
        /// Property opendma:DoubleValue: Double
        /// [SingleValue] [Writable] [Optional]
        /// Full description follows.
        /// </summary>
        double? DoubleValue { get; set; }

        /// <summary>
        /// The Boolean value of this choice or null, if the property info this choice is assigned to is not of data type Boolean.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_BOOLEANVALUE).GetBoolean()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_BOOLEANVALUE).Value</c>.
        /// 
        /// Property opendma:BooleanValue: Boolean
        /// [SingleValue] [Writable] [Optional]
        /// Full description follows.
        /// </summary>
        bool? BooleanValue { get; set; }

        /// <summary>
        /// The DateTime value of this choice or null, if the property info this choice is assigned to is not of data type DateTime.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_DATETIMEVALUE).GetDateTime()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_DATETIMEVALUE).Value</c>.
        /// 
        /// Property opendma:DateTimeValue: DateTime
        /// [SingleValue] [Writable] [Optional]
        /// Full description follows.
        /// </summary>
        DateTime? DateTimeValue { get; set; }

        /// <summary>
        /// The BLOB value of this choice or null, if the property info this choice is assigned to is not of data type BLOB.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_BLOBVALUE).GetBlob()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_BLOBVALUE).Value</c>.
        /// 
        /// Property opendma:BlobValue: Blob
        /// [SingleValue] [Writable] [Optional]
        /// Full description follows.
        /// </summary>
        byte[]? BlobValue { get; set; }

        /// <summary>
        /// The Reference value of this choice or null, if the property info this choice is assigned to is not of data type Reference.<br/>
        /// Shortcut for <c>GetProperty(OdmaCommonNames.PROPERTY_REFERENCEVALUE).GetReference()</c> or <c>GetProperty(OdmaCommonNames.PROPERTY_REFERENCEVALUE).Value</c>.
        /// 
        /// Property opendma:ReferenceValue: Reference to Object (opendma)
        /// [SingleValue] [Writable] [Optional]
        /// Full description follows.
        /// </summary>
        IOdmaObject? ReferenceValue { get; set; }

    }

}
