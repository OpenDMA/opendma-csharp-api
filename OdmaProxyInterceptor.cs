using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OpenDMA.Api
{

    public class OdmaProxyInterceptor : IInterceptor
    {

        private static readonly Dictionary<string, PropertyMapping> PROPERTY_DICT = new Dictionary<string, PropertyMapping>();

        private class PropertyMapping
        {
            public OdmaQName QName { get; }
            public OdmaType Type { get; }
            public bool MultiValue { get; }

            public PropertyMapping(OdmaQName qname, OdmaType type, bool multiValue)
            {
                QName = qname;
                Type = type;
                MultiValue = multiValue;
            }
        }
        static OdmaProxyInterceptor()
        {
            PROPERTY_DICT["get_OdmaClass"] = new PropertyMapping(OdmaCommonNames.PROPERTY_CLASS, OdmaType.REFERENCE, false);
            PROPERTY_DICT["get_Aspects"] = new PropertyMapping(OdmaCommonNames.PROPERTY_ASPECTS, OdmaType.REFERENCE, true);
            PROPERTY_DICT["get_Id"] = new PropertyMapping(OdmaCommonNames.PROPERTY_ID, OdmaType.ID, false);
            PROPERTY_DICT["get_Guid"] = new PropertyMapping(OdmaCommonNames.PROPERTY_GUID, OdmaType.GUID, false);
            PROPERTY_DICT["get_Repository"] = new PropertyMapping(OdmaCommonNames.PROPERTY_REPOSITORY, OdmaType.REFERENCE, false);
            PROPERTY_DICT["get_Name"] = new PropertyMapping(OdmaCommonNames.PROPERTY_NAME, OdmaType.STRING, false);
            PROPERTY_DICT["set_Name"] = new PropertyMapping(OdmaCommonNames.PROPERTY_NAME, OdmaType.STRING, false);
            PROPERTY_DICT["get_Namespace"] = new PropertyMapping(OdmaCommonNames.PROPERTY_NAMESPACE, OdmaType.STRING, false);
            PROPERTY_DICT["set_Namespace"] = new PropertyMapping(OdmaCommonNames.PROPERTY_NAMESPACE, OdmaType.STRING, false);
            PROPERTY_DICT["get_DisplayName"] = new PropertyMapping(OdmaCommonNames.PROPERTY_DISPLAYNAME, OdmaType.STRING, false);
            PROPERTY_DICT["set_DisplayName"] = new PropertyMapping(OdmaCommonNames.PROPERTY_DISPLAYNAME, OdmaType.STRING, false);
            PROPERTY_DICT["get_SuperClass"] = new PropertyMapping(OdmaCommonNames.PROPERTY_SUPERCLASS, OdmaType.REFERENCE, false);
            PROPERTY_DICT["get_IncludedAspects"] = new PropertyMapping(OdmaCommonNames.PROPERTY_INCLUDEDASPECTS, OdmaType.REFERENCE, true);
            PROPERTY_DICT["get_DeclaredProperties"] = new PropertyMapping(OdmaCommonNames.PROPERTY_DECLAREDPROPERTIES, OdmaType.REFERENCE, true);
            PROPERTY_DICT["get_Properties"] = new PropertyMapping(OdmaCommonNames.PROPERTY_PROPERTIES, OdmaType.REFERENCE, true);
            PROPERTY_DICT["get_Aspect"] = new PropertyMapping(OdmaCommonNames.PROPERTY_ASPECT, OdmaType.BOOLEAN, false);
            PROPERTY_DICT["get_Hidden"] = new PropertyMapping(OdmaCommonNames.PROPERTY_HIDDEN, OdmaType.BOOLEAN, false);
            PROPERTY_DICT["set_Hidden"] = new PropertyMapping(OdmaCommonNames.PROPERTY_HIDDEN, OdmaType.BOOLEAN, false);
            PROPERTY_DICT["get_System"] = new PropertyMapping(OdmaCommonNames.PROPERTY_SYSTEM, OdmaType.BOOLEAN, false);
            PROPERTY_DICT["set_System"] = new PropertyMapping(OdmaCommonNames.PROPERTY_SYSTEM, OdmaType.BOOLEAN, false);
            PROPERTY_DICT["get_Retrievable"] = new PropertyMapping(OdmaCommonNames.PROPERTY_RETRIEVABLE, OdmaType.BOOLEAN, false);
            PROPERTY_DICT["get_Searchable"] = new PropertyMapping(OdmaCommonNames.PROPERTY_SEARCHABLE, OdmaType.BOOLEAN, false);
            PROPERTY_DICT["get_SubClasses"] = new PropertyMapping(OdmaCommonNames.PROPERTY_SUBCLASSES, OdmaType.REFERENCE, true);
            PROPERTY_DICT["get_DataType"] = new PropertyMapping(OdmaCommonNames.PROPERTY_DATATYPE, OdmaType.INTEGER, false);
            PROPERTY_DICT["set_DataType"] = new PropertyMapping(OdmaCommonNames.PROPERTY_DATATYPE, OdmaType.INTEGER, false);
            PROPERTY_DICT["get_ReferenceClass"] = new PropertyMapping(OdmaCommonNames.PROPERTY_REFERENCECLASS, OdmaType.REFERENCE, false);
            PROPERTY_DICT["set_ReferenceClass"] = new PropertyMapping(OdmaCommonNames.PROPERTY_REFERENCECLASS, OdmaType.REFERENCE, false);
            PROPERTY_DICT["get_MultiValue"] = new PropertyMapping(OdmaCommonNames.PROPERTY_MULTIVALUE, OdmaType.BOOLEAN, false);
            PROPERTY_DICT["set_MultiValue"] = new PropertyMapping(OdmaCommonNames.PROPERTY_MULTIVALUE, OdmaType.BOOLEAN, false);
            PROPERTY_DICT["get_Required"] = new PropertyMapping(OdmaCommonNames.PROPERTY_REQUIRED, OdmaType.BOOLEAN, false);
            PROPERTY_DICT["set_Required"] = new PropertyMapping(OdmaCommonNames.PROPERTY_REQUIRED, OdmaType.BOOLEAN, false);
            PROPERTY_DICT["get_ReadOnly"] = new PropertyMapping(OdmaCommonNames.PROPERTY_READONLY, OdmaType.BOOLEAN, false);
            PROPERTY_DICT["set_ReadOnly"] = new PropertyMapping(OdmaCommonNames.PROPERTY_READONLY, OdmaType.BOOLEAN, false);
            PROPERTY_DICT["get_Choices"] = new PropertyMapping(OdmaCommonNames.PROPERTY_CHOICES, OdmaType.REFERENCE, true);
            PROPERTY_DICT["get_StringValue"] = new PropertyMapping(OdmaCommonNames.PROPERTY_STRINGVALUE, OdmaType.STRING, false);
            PROPERTY_DICT["set_StringValue"] = new PropertyMapping(OdmaCommonNames.PROPERTY_STRINGVALUE, OdmaType.STRING, false);
            PROPERTY_DICT["get_IntegerValue"] = new PropertyMapping(OdmaCommonNames.PROPERTY_INTEGERVALUE, OdmaType.INTEGER, false);
            PROPERTY_DICT["set_IntegerValue"] = new PropertyMapping(OdmaCommonNames.PROPERTY_INTEGERVALUE, OdmaType.INTEGER, false);
            PROPERTY_DICT["get_ShortValue"] = new PropertyMapping(OdmaCommonNames.PROPERTY_SHORTVALUE, OdmaType.SHORT, false);
            PROPERTY_DICT["set_ShortValue"] = new PropertyMapping(OdmaCommonNames.PROPERTY_SHORTVALUE, OdmaType.SHORT, false);
            PROPERTY_DICT["get_LongValue"] = new PropertyMapping(OdmaCommonNames.PROPERTY_LONGVALUE, OdmaType.LONG, false);
            PROPERTY_DICT["set_LongValue"] = new PropertyMapping(OdmaCommonNames.PROPERTY_LONGVALUE, OdmaType.LONG, false);
            PROPERTY_DICT["get_FloatValue"] = new PropertyMapping(OdmaCommonNames.PROPERTY_FLOATVALUE, OdmaType.FLOAT, false);
            PROPERTY_DICT["set_FloatValue"] = new PropertyMapping(OdmaCommonNames.PROPERTY_FLOATVALUE, OdmaType.FLOAT, false);
            PROPERTY_DICT["get_DoubleValue"] = new PropertyMapping(OdmaCommonNames.PROPERTY_DOUBLEVALUE, OdmaType.DOUBLE, false);
            PROPERTY_DICT["set_DoubleValue"] = new PropertyMapping(OdmaCommonNames.PROPERTY_DOUBLEVALUE, OdmaType.DOUBLE, false);
            PROPERTY_DICT["get_BooleanValue"] = new PropertyMapping(OdmaCommonNames.PROPERTY_BOOLEANVALUE, OdmaType.BOOLEAN, false);
            PROPERTY_DICT["set_BooleanValue"] = new PropertyMapping(OdmaCommonNames.PROPERTY_BOOLEANVALUE, OdmaType.BOOLEAN, false);
            PROPERTY_DICT["get_DateTimeValue"] = new PropertyMapping(OdmaCommonNames.PROPERTY_DATETIMEVALUE, OdmaType.DATETIME, false);
            PROPERTY_DICT["set_DateTimeValue"] = new PropertyMapping(OdmaCommonNames.PROPERTY_DATETIMEVALUE, OdmaType.DATETIME, false);
            PROPERTY_DICT["get_BinaryValue"] = new PropertyMapping(OdmaCommonNames.PROPERTY_BINARYVALUE, OdmaType.BINARY, false);
            PROPERTY_DICT["set_BinaryValue"] = new PropertyMapping(OdmaCommonNames.PROPERTY_BINARYVALUE, OdmaType.BINARY, false);
            PROPERTY_DICT["get_ReferenceValue"] = new PropertyMapping(OdmaCommonNames.PROPERTY_REFERENCEVALUE, OdmaType.REFERENCE, false);
            PROPERTY_DICT["set_ReferenceValue"] = new PropertyMapping(OdmaCommonNames.PROPERTY_REFERENCEVALUE, OdmaType.REFERENCE, false);
            PROPERTY_DICT["get_RootClass"] = new PropertyMapping(OdmaCommonNames.PROPERTY_ROOTCLASS, OdmaType.REFERENCE, false);
            PROPERTY_DICT["get_RootAspects"] = new PropertyMapping(OdmaCommonNames.PROPERTY_ROOTASPECTS, OdmaType.REFERENCE, true);
            PROPERTY_DICT["get_RootFolder"] = new PropertyMapping(OdmaCommonNames.PROPERTY_ROOTFOLDER, OdmaType.REFERENCE, false);
            PROPERTY_DICT["get_CreatedAt"] = new PropertyMapping(OdmaCommonNames.PROPERTY_CREATEDAT, OdmaType.DATETIME, false);
            PROPERTY_DICT["get_CreatedBy"] = new PropertyMapping(OdmaCommonNames.PROPERTY_CREATEDBY, OdmaType.STRING, false);
            PROPERTY_DICT["get_LastModifiedAt"] = new PropertyMapping(OdmaCommonNames.PROPERTY_LASTMODIFIEDAT, OdmaType.DATETIME, false);
            PROPERTY_DICT["get_LastModifiedBy"] = new PropertyMapping(OdmaCommonNames.PROPERTY_LASTMODIFIEDBY, OdmaType.STRING, false);
            PROPERTY_DICT["get_Title"] = new PropertyMapping(OdmaCommonNames.PROPERTY_TITLE, OdmaType.STRING, false);
            PROPERTY_DICT["set_Title"] = new PropertyMapping(OdmaCommonNames.PROPERTY_TITLE, OdmaType.STRING, false);
            PROPERTY_DICT["get_Version"] = new PropertyMapping(OdmaCommonNames.PROPERTY_VERSION, OdmaType.STRING, false);
            PROPERTY_DICT["get_VersionCollection"] = new PropertyMapping(OdmaCommonNames.PROPERTY_VERSIONCOLLECTION, OdmaType.REFERENCE, false);
            PROPERTY_DICT["get_VersionIndependentId"] = new PropertyMapping(OdmaCommonNames.PROPERTY_VERSIONINDEPENDENTID, OdmaType.ID, false);
            PROPERTY_DICT["get_VersionIndependentGuid"] = new PropertyMapping(OdmaCommonNames.PROPERTY_VERSIONINDEPENDENTGUID, OdmaType.GUID, false);
            PROPERTY_DICT["get_ContentElements"] = new PropertyMapping(OdmaCommonNames.PROPERTY_CONTENTELEMENTS, OdmaType.REFERENCE, true);
            PROPERTY_DICT["get_CombinedContentType"] = new PropertyMapping(OdmaCommonNames.PROPERTY_COMBINEDCONTENTTYPE, OdmaType.STRING, false);
            PROPERTY_DICT["set_CombinedContentType"] = new PropertyMapping(OdmaCommonNames.PROPERTY_COMBINEDCONTENTTYPE, OdmaType.STRING, false);
            PROPERTY_DICT["get_PrimaryContentElement"] = new PropertyMapping(OdmaCommonNames.PROPERTY_PRIMARYCONTENTELEMENT, OdmaType.REFERENCE, false);
            PROPERTY_DICT["set_PrimaryContentElement"] = new PropertyMapping(OdmaCommonNames.PROPERTY_PRIMARYCONTENTELEMENT, OdmaType.REFERENCE, false);
            PROPERTY_DICT["get_CheckedOut"] = new PropertyMapping(OdmaCommonNames.PROPERTY_CHECKEDOUT, OdmaType.BOOLEAN, false);
            PROPERTY_DICT["get_CheckedOutAt"] = new PropertyMapping(OdmaCommonNames.PROPERTY_CHECKEDOUTAT, OdmaType.DATETIME, false);
            PROPERTY_DICT["get_CheckedOutBy"] = new PropertyMapping(OdmaCommonNames.PROPERTY_CHECKEDOUTBY, OdmaType.STRING, false);
            PROPERTY_DICT["get_ContentType"] = new PropertyMapping(OdmaCommonNames.PROPERTY_CONTENTTYPE, OdmaType.STRING, false);
            PROPERTY_DICT["set_ContentType"] = new PropertyMapping(OdmaCommonNames.PROPERTY_CONTENTTYPE, OdmaType.STRING, false);
            PROPERTY_DICT["get_Position"] = new PropertyMapping(OdmaCommonNames.PROPERTY_POSITION, OdmaType.INTEGER, false);
            PROPERTY_DICT["get_Content"] = new PropertyMapping(OdmaCommonNames.PROPERTY_CONTENT, OdmaType.CONTENT, false);
            PROPERTY_DICT["set_Content"] = new PropertyMapping(OdmaCommonNames.PROPERTY_CONTENT, OdmaType.CONTENT, false);
            PROPERTY_DICT["get_Size"] = new PropertyMapping(OdmaCommonNames.PROPERTY_SIZE, OdmaType.LONG, false);
            PROPERTY_DICT["get_FileName"] = new PropertyMapping(OdmaCommonNames.PROPERTY_FILENAME, OdmaType.STRING, false);
            PROPERTY_DICT["set_FileName"] = new PropertyMapping(OdmaCommonNames.PROPERTY_FILENAME, OdmaType.STRING, false);
            PROPERTY_DICT["get_Location"] = new PropertyMapping(OdmaCommonNames.PROPERTY_LOCATION, OdmaType.STRING, false);
            PROPERTY_DICT["set_Location"] = new PropertyMapping(OdmaCommonNames.PROPERTY_LOCATION, OdmaType.STRING, false);
            PROPERTY_DICT["get_Versions"] = new PropertyMapping(OdmaCommonNames.PROPERTY_VERSIONS, OdmaType.REFERENCE, true);
            PROPERTY_DICT["get_Latest"] = new PropertyMapping(OdmaCommonNames.PROPERTY_LATEST, OdmaType.REFERENCE, false);
            PROPERTY_DICT["get_Released"] = new PropertyMapping(OdmaCommonNames.PROPERTY_RELEASED, OdmaType.REFERENCE, false);
            PROPERTY_DICT["get_InProgress"] = new PropertyMapping(OdmaCommonNames.PROPERTY_INPROGRESS, OdmaType.REFERENCE, false);
            PROPERTY_DICT["get_Containees"] = new PropertyMapping(OdmaCommonNames.PROPERTY_CONTAINEES, OdmaType.REFERENCE, true);
            PROPERTY_DICT["get_Associations"] = new PropertyMapping(OdmaCommonNames.PROPERTY_ASSOCIATIONS, OdmaType.REFERENCE, true);
            PROPERTY_DICT["get_Parent"] = new PropertyMapping(OdmaCommonNames.PROPERTY_PARENT, OdmaType.REFERENCE, false);
            PROPERTY_DICT["set_Parent"] = new PropertyMapping(OdmaCommonNames.PROPERTY_PARENT, OdmaType.REFERENCE, false);
            PROPERTY_DICT["get_SubFolders"] = new PropertyMapping(OdmaCommonNames.PROPERTY_SUBFOLDERS, OdmaType.REFERENCE, true);
            PROPERTY_DICT["get_ContainedIn"] = new PropertyMapping(OdmaCommonNames.PROPERTY_CONTAINEDIN, OdmaType.REFERENCE, true);
            PROPERTY_DICT["get_ContainedInAssociations"] = new PropertyMapping(OdmaCommonNames.PROPERTY_CONTAINEDINASSOCIATIONS, OdmaType.REFERENCE, true);
            PROPERTY_DICT["get_Container"] = new PropertyMapping(OdmaCommonNames.PROPERTY_CONTAINER, OdmaType.REFERENCE, false);
            PROPERTY_DICT["set_Container"] = new PropertyMapping(OdmaCommonNames.PROPERTY_CONTAINER, OdmaType.REFERENCE, false);
            PROPERTY_DICT["get_Containable"] = new PropertyMapping(OdmaCommonNames.PROPERTY_CONTAINABLE, OdmaType.REFERENCE, false);
            PROPERTY_DICT["set_Containable"] = new PropertyMapping(OdmaCommonNames.PROPERTY_CONTAINABLE, OdmaType.REFERENCE, false);
        }

        private readonly IOdmaCoreObject _coreObject;

        public OdmaProxyInterceptor(IOdmaCoreObject coreObject)
        {
            _coreObject = coreObject;
        }

        public void Intercept(IInvocation invocation)
        {

            if (invocation.Method.DeclaringType == typeof(IOdmaCoreObject))
            {
                invocation.ReturnValue = invocation.Method.Invoke(_coreObject, invocation.Arguments);
                return;
            }

            string methodName = invocation.Method.Name;
            if (methodName.Equals("get_QName"))
            {
                object? ns = HandlePropertyGetter("get_Namespace", typeof(string));
                object? name = HandlePropertyGetter("get_Name", typeof(string));
                if (ns == null || !(ns is string nsStr))
                {
                    throw new OdmaException("Required property `opemdma:Namespace` does not have a string value.");
                }

                if (name == null || !(name is string nameStr))
                {
                    throw new OdmaException("Required property `opendma:Name` does not have a string value.");
                }
                invocation.ReturnValue = new OdmaQName(nsStr, nameStr);
            }
            else if (methodName.StartsWith("get_"))
            {
                invocation.ReturnValue = HandlePropertyGetter(methodName, invocation.Method.ReturnType);
            }
            else if (methodName.StartsWith("set_"))
            {
                HandlePropertySetter(methodName, invocation.Arguments[0]);
                invocation.ReturnValue = null;
            }
            else
            {
                throw new OdmaException($"Unsupported method: {methodName}");
            }

        }

        private object? HandlePropertyGetter(string methodName, Type returnType)
        {
            if (!PROPERTY_DICT.TryGetValue(methodName, out PropertyMapping? mapping))
            {
                throw new OdmaException($"No property mapping found for method: {methodName}");
            }

            try
            {
                var property = _coreObject.GetProperty(mapping.QName);
                if (mapping.MultiValue)
                {
                    return HandleMultiValueGetter(property, mapping.Type, returnType);
                }
                else
                {
                    return HandleSingleValueGetter(property, mapping.Type);
                }
            }
            catch (OdmaPropertyNotFoundException)
            {
                throw new OdmaServiceException($"Predefined OpenDMA property missing: {mapping.QName}");
            }
            catch (OdmaInvalidDataTypeException)
            {
                throw new OdmaServiceException($"Predefined OpenDMA property has wrong type or cardinality: {mapping.QName}");
            }
        }

        private object? HandleMultiValueGetter(IOdmaProperty property, OdmaType type, Type returnType)
        {
            switch (type)
            {
                case OdmaType.STRING:
                    return property.GetStringList();
                case OdmaType.INTEGER:
                    return property.GetIntegerList();
                case OdmaType.SHORT:
                    return property.GetShortList();
                case OdmaType.LONG:
                    return property.GetLongList();
                case OdmaType.FLOAT:
                    return property.GetFloatList();
                case OdmaType.DOUBLE:
                    return property.GetDoubleList();
                case OdmaType.BOOLEAN:
                    return property.GetBooleanList();
                case OdmaType.DATETIME:
                    return property.GetDateTimeList();
                case OdmaType.BINARY:
                    return property.GetBinaryList();
                case OdmaType.REFERENCE:
                    var enumerable = property.GetReferenceEnumerable();
                    if (returnType.IsGenericType &&
                        returnType.GetGenericTypeDefinition() == typeof(IEnumerable<>) &&
                        returnType.GetGenericArguments()[0] != typeof(IOdmaObject))
                    {
                        var targetElementType = returnType.GetGenericArguments()[0];
                        var castMethod = typeof(Enumerable).GetMethod("Cast").MakeGenericMethod(targetElementType);
                        return castMethod.Invoke(null, new object[] { enumerable });
                    }
                    return enumerable;
                case OdmaType.CONTENT:
                    return property.GetContentList();
                case OdmaType.ID:
                    return property.GetIdList();
                case OdmaType.GUID:
                    return property.GetGuidList();
                default:
                    throw new OdmaException($"Unsupported multi-value type: {type}");
            }
        }

        private object? HandleSingleValueGetter(IOdmaProperty property, OdmaType type)
        {
            switch (type)
            {
                case OdmaType.STRING:
                    return property.GetString();
                case OdmaType.INTEGER:
                    return property.GetInteger();
                case OdmaType.SHORT:
                    return property.GetShort();
                case OdmaType.LONG:
                    return property.GetLong();
                case OdmaType.FLOAT:
                    return property.GetFloat();
                case OdmaType.DOUBLE:
                    return property.GetDouble();
                case OdmaType.BOOLEAN:
                    return property.GetBoolean();
                case OdmaType.DATETIME:
                    return property.GetDateTime();
                case OdmaType.BINARY:
                    return property.GetBinary();
                case OdmaType.REFERENCE:
                    return property.GetReference();
                case OdmaType.CONTENT:
                    return property.GetContent();
                case OdmaType.ID:
                    return property.GetId();
                case OdmaType.GUID:
                    return property.GetGuid();
                default:
                    throw new OdmaException($"Unsupported single-value type: {type}");
            }
        }

        private void HandlePropertySetter(string methodName, object? value)
        {
            string getterName = "get" + methodName.Substring(3);
            if (!PROPERTY_DICT.TryGetValue(getterName, out PropertyMapping? mapping))
            {
                throw new OdmaException($"No property mapping found for method: {methodName}");
            }

            try
            {
                _coreObject.SetProperty(mapping.QName, value);
            }
            catch (OdmaPropertyNotFoundException)
            {
                throw new OdmaServiceException($"Predefined OpenDMA property missing: {mapping.QName}");
            }
            catch (OdmaInvalidDataTypeException)
            {
                throw new OdmaServiceException($"Predefined OpenDMA property has wrong type or cardinality: {mapping.QName}");
            }
        }

    }

}
