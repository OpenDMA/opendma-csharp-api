using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDMA.Api
{

    /// <summary>
    /// Interface for lazy property resolution.
    /// </summary>
    public interface IOdmaLazyPropertyValueProvider
    {

        /// <summary>
        /// Indicates of the OdmaId of a referenced object is available without a round-trip to a back-end system.
        /// </summary>
        bool HasReferenceId();
        
        /// <summary>
        /// Get the OdmaId of a referenced object, if available. Returns null otherwise.
        /// </summary>
        OdmaId? GetReferenceId();

        /// <summary>
        /// Resolves the value of the property when accessed.
        /// </summary>
        object? ResolvePropertyValue();
    }

    /// <summary>
    /// A <i>Property</i> of an <see cref="OdmaObject"/> in the OpenDMA architecture.
    /// It is always bound in name, data type, and cardinality and cannot change these.
    /// If this property is not read-only (i.e., <see cref="IsReadOnly"/> returns <c>false</c>),
    /// its value can be changed via the <see cref="Value"/> property.
    /// Changes are only persisted in the repository after a call to the
    /// <c>Save()</c> method of the containing object.
    /// </summary>
    public interface IOdmaProperty
    {

        /// <summary>
        /// The qualified name of this property.
        /// </summary>
        OdmaQName Name { get; }

        /// <summary>
        /// The data type of this property.
        /// </summary>
        OdmaType Type { get; }

        /// <summary>
        /// The value of this property. The concrete <see cref="object"/> of this property depends on the data type of this OdmaProperty.
        /// </summary>
        /// <exception cref="OdmaInvalidDataTypeException">If the type of the assigned value does not match the data type of this OdmaProperty.</exception>
        /// <exception cref="OdmaAccessDeniedException">If this OdmaProperty is read-only or cannot be set by the current user.</exception>
        object? Value { get; set; }

        /// <summary>
        /// Indicates whether this property is a multi-value property.
        /// </summary>
        bool IsMultiValue { get; }

        /// <summary>
        /// Indicates whether this property has unsaved changes
        /// </summary>
        bool IsDirty { get; }

        /// <summary>
        /// Indicates whether this property is read-only.
        /// </summary>
        bool IsReadOnly { get; }

        /// <summary>
        /// The availability state of a property value.
        /// </summary>
        public enum PropertyResolutionState
        {
            /// <summary>
            /// Reading this value requires a round-trip to a back-end system.
            /// </summary>
            Unresolved,

            /// <summary>
            /// The OdmaId of the referenced object is immediately available, but reading the object value requires a round-trip to a back-end system.
            /// </summary>
            IdResolved,

            /// <summary>
            /// The value is immediately available.
            /// </summary>
            Resolved
        }
        
        /// <summary>
        /// Indicates if the value of this property is immediately available can be read without a round-trip to a back-end system.
        /// </summary>
        PropertyResolutionState ResolutionState { get; }

        /// <summary>
        /// Retrieves the String value of this property if and only if
        /// the data type of this property is a single valued String.
        /// </summary>
        /// <returns>
        /// The string? value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a single-valued String.
        /// </exception>
        string? GetString();

        /// <summary>
        /// Retrieves the Integer value of this property if and only if
        /// the data type of this property is a single valued Integer.
        /// </summary>
        /// <returns>
        /// The int? value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a single-valued Integer.
        /// </exception>
        int? GetInteger();

        /// <summary>
        /// Retrieves the Short value of this property if and only if
        /// the data type of this property is a single valued Short.
        /// </summary>
        /// <returns>
        /// The short? value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a single-valued Short.
        /// </exception>
        short? GetShort();

        /// <summary>
        /// Retrieves the Long value of this property if and only if
        /// the data type of this property is a single valued Long.
        /// </summary>
        /// <returns>
        /// The long? value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a single-valued Long.
        /// </exception>
        long? GetLong();

        /// <summary>
        /// Retrieves the Float value of this property if and only if
        /// the data type of this property is a single valued Float.
        /// </summary>
        /// <returns>
        /// The float? value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a single-valued Float.
        /// </exception>
        float? GetFloat();

        /// <summary>
        /// Retrieves the Double value of this property if and only if
        /// the data type of this property is a single valued Double.
        /// </summary>
        /// <returns>
        /// The double? value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a single-valued Double.
        /// </exception>
        double? GetDouble();

        /// <summary>
        /// Retrieves the Boolean value of this property if and only if
        /// the data type of this property is a single valued Boolean.
        /// </summary>
        /// <returns>
        /// The bool? value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a single-valued Boolean.
        /// </exception>
        bool? GetBoolean();

        /// <summary>
        /// Retrieves the DateTime value of this property if and only if
        /// the data type of this property is a single valued DateTime.
        /// </summary>
        /// <returns>
        /// The DateTime? value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a single-valued DateTime.
        /// </exception>
        DateTime? GetDateTime();

        /// <summary>
        /// Retrieves the Binary value of this property if and only if
        /// the data type of this property is a single valued Binary.
        /// </summary>
        /// <returns>
        /// The byte[]? value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a single-valued Binary.
        /// </exception>
        byte[]? GetBinary();

        /// <summary>
        /// Retrieves the Reference value of this property if and only if
        /// the data type of this property is a single valued Reference.
        /// </summary>
        /// <returns>
        /// The IOdmaObject? value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a single-valued Reference.
        /// </exception>
        IOdmaObject? GetReference();

        /// <summary>
        /// Retrieves the OdmaId of the Reference value of this property if and only if
        /// the data type of this property is a single valued Reference.
        /// Based on the PropertyResolutionState, it is possible that this OdmaId is immediately available
        /// while the OdmaObject requires an additional round-trip to the server.
        /// </summary>
        /// <returns>
        /// The OdmaId of the IOdmaObject? value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a single-valued Reference.
        /// </exception>
        OdmaId? GetReferenceId();

        /// <summary>
        /// Retrieves the Content value of this property if and only if
        /// the data type of this property is a single valued Content.
        /// </summary>
        /// <returns>
        /// The IOdmaContent? value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a single-valued Content.
        /// </exception>
        IOdmaContent? GetContent();

        /// <summary>
        /// Retrieves the Id value of this property if and only if
        /// the data type of this property is a single valued Id.
        /// </summary>
        /// <returns>
        /// The OdmaId? value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a single-valued Id.
        /// </exception>
        OdmaId? GetId();

        /// <summary>
        /// Retrieves the Guid value of this property if and only if
        /// the data type of this property is a single valued Guid.
        /// </summary>
        /// <returns>
        /// The OdmaGuid? value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a single-valued Guid.
        /// </exception>
        OdmaGuid? GetGuid();

        /// <summary>
        /// Retrieves the String value of this property if and only if
        /// the data type of this property is a multi valued String.
        /// </summary>
        /// <returns>
        /// The IList<string> value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a multi-valued String.
        /// </exception>
        IList<string> GetStringList();

        /// <summary>
        /// Retrieves the Integer value of this property if and only if
        /// the data type of this property is a multi valued Integer.
        /// </summary>
        /// <returns>
        /// The IList<int> value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a multi-valued Integer.
        /// </exception>
        IList<int> GetIntegerList();

        /// <summary>
        /// Retrieves the Short value of this property if and only if
        /// the data type of this property is a multi valued Short.
        /// </summary>
        /// <returns>
        /// The IList<short> value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a multi-valued Short.
        /// </exception>
        IList<short> GetShortList();

        /// <summary>
        /// Retrieves the Long value of this property if and only if
        /// the data type of this property is a multi valued Long.
        /// </summary>
        /// <returns>
        /// The IList<long> value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a multi-valued Long.
        /// </exception>
        IList<long> GetLongList();

        /// <summary>
        /// Retrieves the Float value of this property if and only if
        /// the data type of this property is a multi valued Float.
        /// </summary>
        /// <returns>
        /// The IList<float> value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a multi-valued Float.
        /// </exception>
        IList<float> GetFloatList();

        /// <summary>
        /// Retrieves the Double value of this property if and only if
        /// the data type of this property is a multi valued Double.
        /// </summary>
        /// <returns>
        /// The IList<double> value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a multi-valued Double.
        /// </exception>
        IList<double> GetDoubleList();

        /// <summary>
        /// Retrieves the Boolean value of this property if and only if
        /// the data type of this property is a multi valued Boolean.
        /// </summary>
        /// <returns>
        /// The IList<bool> value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a multi-valued Boolean.
        /// </exception>
        IList<bool> GetBooleanList();

        /// <summary>
        /// Retrieves the DateTime value of this property if and only if
        /// the data type of this property is a multi valued DateTime.
        /// </summary>
        /// <returns>
        /// The IList<DateTime> value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a multi-valued DateTime.
        /// </exception>
        IList<DateTime> GetDateTimeList();

        /// <summary>
        /// Retrieves the Binary value of this property if and only if
        /// the data type of this property is a multi valued Binary.
        /// </summary>
        /// <returns>
        /// The IList<byte[]> value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a multi-valued Binary.
        /// </exception>
        IList<byte[]> GetBinaryList();

        /// <summary>
        /// Retrieves the Reference value of this property if and only if
        /// the data type of this property is a multi valued Reference.
        /// </summary>
        /// <returns>
        /// The IEnumerable<IOdmaObject> value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a multi-valued Reference.
        /// </exception>
        IEnumerable<IOdmaObject> GetReferenceEnumerable();

        /// <summary>
        /// Retrieves the Content value of this property if and only if
        /// the data type of this property is a multi valued Content.
        /// </summary>
        /// <returns>
        /// The IList<IOdmaContent> value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a multi-valued Content.
        /// </exception>
        IList<IOdmaContent> GetContentList();

        /// <summary>
        /// Retrieves the Id value of this property if and only if
        /// the data type of this property is a multi valued Id.
        /// </summary>
        /// <returns>
        /// The IList<OdmaId> value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a multi-valued Id.
        /// </exception>
        IList<OdmaId> GetIdList();

        /// <summary>
        /// Retrieves the Guid value of this property if and only if
        /// the data type of this property is a multi valued Guid.
        /// </summary>
        /// <returns>
        /// The IList<OdmaGuid> value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a multi-valued Guid.
        /// </exception>
        IList<OdmaGuid> GetGuidList();

    }

}
