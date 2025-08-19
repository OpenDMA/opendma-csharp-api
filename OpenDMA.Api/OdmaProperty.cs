using System;
using System.Collections.Generic;
using System.Text;
using static OpenDMA.Api.IOdmaProperty;

namespace OpenDMA.Api
{

    /// <summary>
    /// Standard implementation of the IOdmaProperty interface.
    /// </summary>
    public class OdmaProperty : IOdmaProperty
    {

        /// <summary>
        /// The qualified name of this property.
        /// </summary>
        protected OdmaQName _name;
        
        /// <summary>
        /// The data type of this property.
        /// </summary>
        protected OdmaType _type;
        
        /// <summary>
        /// Flag indicating whether this property is a multi-value property.
        /// </summary>
        protected bool _multiValue;
        
        /// <summary>
        /// The value of this property.
        /// </summary>
        protected object? _value;
        
        /// <summary>
        /// Flag indicating whether this property has unsaved changes
        /// </summary>
        protected bool _dirty;
        
        /// <summary>
        /// Flag indicating whether this property is read-only.
        /// </summary>
        protected bool _readOnly;

        /// <summary>
        /// Property value provider for lazy property resolution
        /// </summary>
        protected IOdmaLazyPropertyValueProvider? _valueProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="OdmaProperty"/> class with a specified type and value.
        /// </summary>
        /// <param name="name">The qualified name of this property.</param>
        /// <param name="value">The value of this property.</param>
        /// <param name="valueProvider">The provider of the propertie's value for lazy resolution.</param>
        /// <param name="type">The data type of this property.</param>
        /// <param name="multiValue">Flag indicating whether this property is a multi-value property.</param>
        /// <param name="readOnly">Flag indicating whether this property is read-only.</param>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the type of <paramref name="value"/> does not match the property's data type.
        /// </exception>
        public OdmaProperty(OdmaQName name, object? value, IOdmaLazyPropertyValueProvider? valueProvider, OdmaType type, bool multiValue, bool readOnly)
        {
            this._name = name;
            this._type = type;
            this._multiValue = multiValue;
            this._readOnly = readOnly;
            if(valueProvider != null)
            {
                if(value != null)
                {
                    throw new ArgumentException("If a value provider is given, the value must be null.");
                }
                this._valueProvider = valueProvider;
            }
            else
            {
                SetValueInternal(value);
                this._dirty = false;
            }
        }

        /// <summary>
        /// The qualified name of this property.
        /// </summary>
        public OdmaQName Name { get => _name; }

        /// <summary>
        /// The data type of this property.
        /// </summary>
        public OdmaType Type { get => _type; }

        /// <summary>
        /// Indicates whether this property is a multi-value property.
        /// </summary>
        public bool IsMultiValue { get => _multiValue; }

        /// <summary>
        /// Indicates whether this property has unsaved changes
        /// </summary>
        public bool IsDirty { get => _dirty; }

        /// <summary>
        /// Indicates whether this property is read-only.
        /// </summary>
        public bool IsReadOnly { get => _readOnly; }
        
        /// <summary>
        /// Indicates if the value of this property is immediately available can be read without a round-trip to a back-end system.
        /// </summary>
        public PropertyResolutionState ResolutionState { get => 
            _valueProvider == null ? PropertyResolutionState.Resolved :
            _valueProvider.HasReferenceId() ? PropertyResolutionState.IdResolved :
            PropertyResolutionState.Unresolved; 
        }

        /// <summary>
        /// The value of this property. The concrete <see cref="object"/> of this property depends on the data type of this OdmaProperty.
        /// </summary>
        /// <exception cref="OdmaInvalidDataTypeException">If the type of the assigned value does not match the data type of this OdmaProperty.</exception>
        /// <exception cref="OdmaAccessDeniedException">If this OdmaProperty is read-only or cannot be set by the current user.</exception>
        public object? Value
        {
            get
            {
                EnforceValue();
                return this._value;
            }
            set
            {
                SetValue(value);
            }
        }

        protected void EnforceValue()
        {
            if (_valueProvider != null)
            {
                try
                {
                    SetValueInternal(_valueProvider.ResolvePropertyValue());
                    _dirty = false;
                    _valueProvider = null;
                }
                catch (OdmaInvalidDataTypeException ex)
                {
                    throw new OdmaServiceException("Lazy property resolution failed. Provider delivered wrong type or cardinality.", ex);
                }
            }
        }

        protected void SetValue(object? newValue)
        {
            if (_readOnly)
            {
                throw new OdmaAccessDeniedException();
            }
            SetValueInternal(newValue);
            _valueProvider = null;
        }

        protected void SetValueInternal(object? newValue)
        {
            if(newValue == null)
            {
                if(_multiValue)
                {
                    throw new OdmaInvalidDataTypeException("Multi-valued properties must not be `null`. If a value is not required, the collection can be empty.");
                }
                _value = null;
                _dirty = true;
                return;
            }
            if(_multiValue)
            {
                switch(_type)
                {
                case OdmaType.STRING:
                    if(newValue is IList<string>)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a multi-valued String data type. It can only be set to values assignable to `IList<string>`");
                    }
                    break;
                case OdmaType.INTEGER:
                    if(newValue is IList<int>)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a multi-valued Integer data type. It can only be set to values assignable to `IList<int>`");
                    }
                    break;
                case OdmaType.SHORT:
                    if(newValue is IList<short>)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a multi-valued Short data type. It can only be set to values assignable to `IList<short>`");
                    }
                    break;
                case OdmaType.LONG:
                    if(newValue is IList<long>)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a multi-valued Long data type. It can only be set to values assignable to `IList<long>`");
                    }
                    break;
                case OdmaType.FLOAT:
                    if(newValue is IList<float>)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a multi-valued Float data type. It can only be set to values assignable to `IList<float>`");
                    }
                    break;
                case OdmaType.DOUBLE:
                    if(newValue is IList<double>)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a multi-valued Double data type. It can only be set to values assignable to `IList<double>`");
                    }
                    break;
                case OdmaType.BOOLEAN:
                    if(newValue is IList<bool>)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a multi-valued Boolean data type. It can only be set to values assignable to `IList<bool>`");
                    }
                    break;
                case OdmaType.DATETIME:
                    if(newValue is IList<DateTime>)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a multi-valued DateTime data type. It can only be set to values assignable to `IList<DateTime>`");
                    }
                    break;
                case OdmaType.BLOB:
                    if(newValue is IList<byte[]>)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a multi-valued Blob data type. It can only be set to values assignable to `IList<byte[]>`");
                    }
                    break;
                case OdmaType.REFERENCE:
                    if(newValue is IEnumerable<IOdmaObject>)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a multi-valued Reference data type. It can only be set to values assignable to `IEnumerable<IOdmaObject>`");
                    }
                    break;
                case OdmaType.CONTENT:
                    if(newValue is IList<IOdmaContent>)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a multi-valued Content data type. It can only be set to values assignable to `IList<IOdmaContent>`");
                    }
                    break;
                case OdmaType.ID:
                    if(newValue is IList<OdmaId>)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a multi-valued Id data type. It can only be set to values assignable to `IList<OdmaId>`");
                    }
                    break;
                case OdmaType.GUID:
                    if(newValue is IList<OdmaGuid>)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a multi-valued Guid data type. It can only be set to values assignable to `IList<OdmaGuid>`");
                    }
                    break;
                default:
                    throw new InvalidOperationException("OdmaProperty initialized with unknown data type "+_type);
                }
            }
            else
            {
                switch(_type)
                {
                case OdmaType.STRING:
                    if(newValue is string)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a single-valued String data type. It can only be set to values assignable to `string?`");
                    }
                    break;
                case OdmaType.INTEGER:
                    if(newValue is int)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a single-valued Integer data type. It can only be set to values assignable to `int?`");
                    }
                    break;
                case OdmaType.SHORT:
                    if(newValue is short)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a single-valued Short data type. It can only be set to values assignable to `short?`");
                    }
                    break;
                case OdmaType.LONG:
                    if(newValue is long)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a single-valued Long data type. It can only be set to values assignable to `long?`");
                    }
                    break;
                case OdmaType.FLOAT:
                    if(newValue is float)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a single-valued Float data type. It can only be set to values assignable to `float?`");
                    }
                    break;
                case OdmaType.DOUBLE:
                    if(newValue is double)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a single-valued Double data type. It can only be set to values assignable to `double?`");
                    }
                    break;
                case OdmaType.BOOLEAN:
                    if(newValue is bool)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a single-valued Boolean data type. It can only be set to values assignable to `bool?`");
                    }
                    break;
                case OdmaType.DATETIME:
                    if(newValue is DateTime)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a single-valued DateTime data type. It can only be set to values assignable to `DateTime?`");
                    }
                    break;
                case OdmaType.BLOB:
                    if(newValue is byte[])
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a single-valued Blob data type. It can only be set to values assignable to `byte[]?`");
                    }
                    break;
                case OdmaType.REFERENCE:
                    if(newValue is IOdmaObject)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a single-valued Reference data type. It can only be set to values assignable to `IOdmaObject?`");
                    }
                    break;
                case OdmaType.CONTENT:
                    if(newValue is IOdmaContent)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a single-valued Content data type. It can only be set to values assignable to `IOdmaContent?`");
                    }
                    break;
                case OdmaType.ID:
                    if(newValue is OdmaId)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a single-valued Id data type. It can only be set to values assignable to `OdmaId?`");
                    }
                    break;
                case OdmaType.GUID:
                    if(newValue is OdmaGuid)
                    {
                        _value = newValue;
                    }
                    else
                    {
                        throw new OdmaInvalidDataTypeException("This property has a single-valued Guid data type. It can only be set to values assignable to `OdmaGuid?`");
                    }
                    break;
                default:
                    throw new InvalidOperationException("OdmaProperty initialized with unknown data type "+_type);
                }
            }
            _dirty = true;
        }

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
        public string? GetString()
        {
            if( (_multiValue == false) && (_type == OdmaType.STRING) )
            {
                EnforceValue();
                return (string?)_value;
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetString()`");
            }
        }

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
        public int? GetInteger()
        {
            if( (_multiValue == false) && (_type == OdmaType.INTEGER) )
            {
                EnforceValue();
                return (int?)_value;
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetInteger()`");
            }
        }

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
        public short? GetShort()
        {
            if( (_multiValue == false) && (_type == OdmaType.SHORT) )
            {
                EnforceValue();
                return (short?)_value;
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetShort()`");
            }
        }

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
        public long? GetLong()
        {
            if( (_multiValue == false) && (_type == OdmaType.LONG) )
            {
                EnforceValue();
                return (long?)_value;
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetLong()`");
            }
        }

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
        public float? GetFloat()
        {
            if( (_multiValue == false) && (_type == OdmaType.FLOAT) )
            {
                EnforceValue();
                return (float?)_value;
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetFloat()`");
            }
        }

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
        public double? GetDouble()
        {
            if( (_multiValue == false) && (_type == OdmaType.DOUBLE) )
            {
                EnforceValue();
                return (double?)_value;
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetDouble()`");
            }
        }

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
        public bool? GetBoolean()
        {
            if( (_multiValue == false) && (_type == OdmaType.BOOLEAN) )
            {
                EnforceValue();
                return (bool?)_value;
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetBoolean()`");
            }
        }

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
        public DateTime? GetDateTime()
        {
            if( (_multiValue == false) && (_type == OdmaType.DATETIME) )
            {
                EnforceValue();
                return (DateTime?)_value;
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetDateTime()`");
            }
        }

        /// <summary>
        /// Retrieves the Blob value of this property if and only if
        /// the data type of this property is a single valued Blob.
        /// </summary>
        /// <returns>
        /// The byte[]? value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a single-valued Blob.
        /// </exception>
        public byte[]? GetBlob()
        {
            if( (_multiValue == false) && (_type == OdmaType.BLOB) )
            {
                EnforceValue();
                return (byte[]?)_value;
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetBlob()`");
            }
        }

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
        public IOdmaObject? GetReference()
        {
            if( (_multiValue == false) && (_type == OdmaType.REFERENCE) )
            {
                EnforceValue();
                return (IOdmaObject?)_value;
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetReference()`");
            }
        }

        /// <summary>
        /// Retrieves the OdmaId of the Reference value of this property if and only if
        /// the data type of this property is a single valued Reference.
        /// Based on the PropertyResolutionState, it is possible that this OdmaId is immediately available
        /// while the OdmaObject requires an additional round-trip to the server.
        /// </summary>
        /// <returns>
        /// The OdmaId of the IOdmaObject value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a single-valued Reference.
        /// </exception>
        public OdmaId? GetReferenceId()
        {
            if( (_multiValue == false) && (_type == OdmaType.REFERENCE) )
            {
                if(_valueProvider == null)
                {
                    if(_value != null)
                    {
                        if (_value is IOdmaObject odmaObject)
                        {
                             return odmaObject.Id;
                        }
                        else
                        {
                            throw new OdmaException("Internal error. Reference value is expected to be instance of OdmaObject");
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else if(_valueProvider.HasReferenceId())
                {
                    return _valueProvider.GetReferenceId();
                }
                else
                {
                    EnforceValue();
                    if(_value != null)
                    {
                        if (_value is IOdmaObject odmaObject)
                        {
                             return odmaObject.Id;
                        }
                        else
                        {
                            throw new OdmaException("Internal error. Reference value is expected to be instance of OdmaObject");
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetReference()`");
            }
        }

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
        public IOdmaContent? GetContent()
        {
            if( (_multiValue == false) && (_type == OdmaType.CONTENT) )
            {
                EnforceValue();
                return (IOdmaContent?)_value;
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetContent()`");
            }
        }

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
        public OdmaId? GetId()
        {
            if( (_multiValue == false) && (_type == OdmaType.ID) )
            {
                EnforceValue();
                return (OdmaId?)_value;
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetId()`");
            }
        }

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
        public OdmaGuid? GetGuid()
        {
            if( (_multiValue == false) && (_type == OdmaType.GUID) )
            {
                EnforceValue();
                return (OdmaGuid?)_value;
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetGuid()`");
            }
        }

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
        public IList<string> GetStringList()
        {
            if( (_multiValue == true) && (_type == OdmaType.STRING) )
            {
                EnforceValue();
                return _value is IList<string> ret ? ret : throw new InvalidOperationException("Implementation error.");
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetStringList()`");
            }
        }

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
        public IList<int> GetIntegerList()
        {
            if( (_multiValue == true) && (_type == OdmaType.INTEGER) )
            {
                EnforceValue();
                return _value is IList<int> ret ? ret : throw new InvalidOperationException("Implementation error.");
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetIntegerList()`");
            }
        }

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
        public IList<short> GetShortList()
        {
            if( (_multiValue == true) && (_type == OdmaType.SHORT) )
            {
                EnforceValue();
                return _value is IList<short> ret ? ret : throw new InvalidOperationException("Implementation error.");
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetShortList()`");
            }
        }

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
        public IList<long> GetLongList()
        {
            if( (_multiValue == true) && (_type == OdmaType.LONG) )
            {
                EnforceValue();
                return _value is IList<long> ret ? ret : throw new InvalidOperationException("Implementation error.");
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetLongList()`");
            }
        }

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
        public IList<float> GetFloatList()
        {
            if( (_multiValue == true) && (_type == OdmaType.FLOAT) )
            {
                EnforceValue();
                return _value is IList<float> ret ? ret : throw new InvalidOperationException("Implementation error.");
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetFloatList()`");
            }
        }

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
        public IList<double> GetDoubleList()
        {
            if( (_multiValue == true) && (_type == OdmaType.DOUBLE) )
            {
                EnforceValue();
                return _value is IList<double> ret ? ret : throw new InvalidOperationException("Implementation error.");
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetDoubleList()`");
            }
        }

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
        public IList<bool> GetBooleanList()
        {
            if( (_multiValue == true) && (_type == OdmaType.BOOLEAN) )
            {
                EnforceValue();
                return _value is IList<bool> ret ? ret : throw new InvalidOperationException("Implementation error.");
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetBooleanList()`");
            }
        }

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
        public IList<DateTime> GetDateTimeList()
        {
            if( (_multiValue == true) && (_type == OdmaType.DATETIME) )
            {
                EnforceValue();
                return _value is IList<DateTime> ret ? ret : throw new InvalidOperationException("Implementation error.");
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetDateTimeList()`");
            }
        }

        /// <summary>
        /// Retrieves the Blob value of this property if and only if
        /// the data type of this property is a multi valued Blob.
        /// </summary>
        /// <returns>
        /// The IList<byte[]> value of this property
        /// </returns>
        /// <exception cref="OdmaInvalidDataTypeException">
        /// Thrown if the data type of this property is not a multi-valued Blob.
        /// </exception>
        public IList<byte[]> GetBlobList()
        {
            if( (_multiValue == true) && (_type == OdmaType.BLOB) )
            {
                EnforceValue();
                return _value is IList<byte[]> ret ? ret : throw new InvalidOperationException("Implementation error.");
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetBlobList()`");
            }
        }

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
        public IEnumerable<IOdmaObject> GetReferenceEnumerable()
        {
            if( (_multiValue == true) && (_type == OdmaType.REFERENCE) )
            {
                EnforceValue();
                return _value is IEnumerable<IOdmaObject> ret ? ret : throw new InvalidOperationException("Implementation error.");
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetReferenceEnumerable()`");
            }
        }

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
        public IList<IOdmaContent> GetContentList()
        {
            if( (_multiValue == true) && (_type == OdmaType.CONTENT) )
            {
                EnforceValue();
                return _value is IList<IOdmaContent> ret ? ret : throw new InvalidOperationException("Implementation error.");
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetContentList()`");
            }
        }

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
        public IList<OdmaId> GetIdList()
        {
            if( (_multiValue == true) && (_type == OdmaType.ID) )
            {
                EnforceValue();
                return _value is IList<OdmaId> ret ? ret : throw new InvalidOperationException("Implementation error.");
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetIdList()`");
            }
        }

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
        public IList<OdmaGuid> GetGuidList()
        {
            if( (_multiValue == true) && (_type == OdmaType.GUID) )
            {
                EnforceValue();
                return _value is IList<OdmaGuid> ret ? ret : throw new InvalidOperationException("Implementation error.");
            }
            else
            {
                throw new OdmaInvalidDataTypeException("This property has a different data type and/or cardinality. It cannot return values with `GetGuidList()`");
            }
        }

    }

}
