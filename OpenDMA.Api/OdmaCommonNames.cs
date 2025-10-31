using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDMA.Api
{

    /// <summary>Static declaration of all common names used in the OpenDMA specification.</summary>
    public static class OdmaCommonNames
    {

        // -----< class Object >--------------------------------------------------------------------

        /// <summary>qualified name of the OpenDMA system class <c>Object</c></summary>
        public static readonly OdmaQName CLASS_OBJECT = new OdmaQName("opendma", "Object");

        /// <summary>qualified name of the OpenDMA system property <c>Class</c><summary>
        public static readonly OdmaQName PROPERTY_CLASS = new OdmaQName("opendma", "Class");

        /// <summary>qualified name of the OpenDMA system property <c>Id</c><summary>
        public static readonly OdmaQName PROPERTY_ID = new OdmaQName("opendma", "Id");

        /// <summary>qualified name of the OpenDMA system property <c>Guid</c><summary>
        public static readonly OdmaQName PROPERTY_GUID = new OdmaQName("opendma", "Guid");

        /// <summary>qualified name of the OpenDMA system property <c>Repository</c><summary>
        public static readonly OdmaQName PROPERTY_REPOSITORY = new OdmaQName("opendma", "Repository");

        // -----< class Class >---------------------------------------------------------------------

        /// <summary>qualified name of the OpenDMA system class <c>Class</c></summary>
        public static readonly OdmaQName CLASS_CLASS = new OdmaQName("opendma", "Class");

        /// <summary>qualified name of the OpenDMA system property <c>Name</c><summary>
        public static readonly OdmaQName PROPERTY_NAME = new OdmaQName("opendma", "Name");

        /// <summary>qualified name of the OpenDMA system property <c>Namespace</c><summary>
        public static readonly OdmaQName PROPERTY_NAMESPACE = new OdmaQName("opendma", "Namespace");

        /// <summary>qualified name of the OpenDMA system property <c>DisplayName</c><summary>
        public static readonly OdmaQName PROPERTY_DISPLAYNAME = new OdmaQName("opendma", "DisplayName");

        /// <summary>qualified name of the OpenDMA system property <c>SuperClass</c><summary>
        public static readonly OdmaQName PROPERTY_SUPERCLASS = new OdmaQName("opendma", "SuperClass");

        /// <summary>qualified name of the OpenDMA system property <c>IncludedAspects</c><summary>
        public static readonly OdmaQName PROPERTY_INCLUDEDASPECTS = new OdmaQName("opendma", "IncludedAspects");

        /// <summary>qualified name of the OpenDMA system property <c>DeclaredProperties</c><summary>
        public static readonly OdmaQName PROPERTY_DECLAREDPROPERTIES = new OdmaQName("opendma", "DeclaredProperties");

        /// <summary>qualified name of the OpenDMA system property <c>Properties</c><summary>
        public static readonly OdmaQName PROPERTY_PROPERTIES = new OdmaQName("opendma", "Properties");

        /// <summary>qualified name of the OpenDMA system property <c>Aspect</c><summary>
        public static readonly OdmaQName PROPERTY_ASPECT = new OdmaQName("opendma", "Aspect");

        /// <summary>qualified name of the OpenDMA system property <c>Hidden</c><summary>
        public static readonly OdmaQName PROPERTY_HIDDEN = new OdmaQName("opendma", "Hidden");

        /// <summary>qualified name of the OpenDMA system property <c>System</c><summary>
        public static readonly OdmaQName PROPERTY_SYSTEM = new OdmaQName("opendma", "System");

        /// <summary>qualified name of the OpenDMA system property <c>Retrievable</c><summary>
        public static readonly OdmaQName PROPERTY_RETRIEVABLE = new OdmaQName("opendma", "Retrievable");

        /// <summary>qualified name of the OpenDMA system property <c>Searchable</c><summary>
        public static readonly OdmaQName PROPERTY_SEARCHABLE = new OdmaQName("opendma", "Searchable");

        /// <summary>qualified name of the OpenDMA system property <c>SubClasses</c><summary>
        public static readonly OdmaQName PROPERTY_SUBCLASSES = new OdmaQName("opendma", "SubClasses");

        // -----< class PropertyInfo >--------------------------------------------------------------

        /// <summary>qualified name of the OpenDMA system class <c>PropertyInfo</c></summary>
        public static readonly OdmaQName CLASS_PROPERTYINFO = new OdmaQName("opendma", "PropertyInfo");

        // Property Name already defined previously

        // Property Namespace already defined previously

        // Property DisplayName already defined previously

        /// <summary>qualified name of the OpenDMA system property <c>DataType</c><summary>
        public static readonly OdmaQName PROPERTY_DATATYPE = new OdmaQName("opendma", "DataType");

        /// <summary>qualified name of the OpenDMA system property <c>ReferenceClass</c><summary>
        public static readonly OdmaQName PROPERTY_REFERENCECLASS = new OdmaQName("opendma", "ReferenceClass");

        /// <summary>qualified name of the OpenDMA system property <c>MultiValue</c><summary>
        public static readonly OdmaQName PROPERTY_MULTIVALUE = new OdmaQName("opendma", "MultiValue");

        /// <summary>qualified name of the OpenDMA system property <c>Required</c><summary>
        public static readonly OdmaQName PROPERTY_REQUIRED = new OdmaQName("opendma", "Required");

        /// <summary>qualified name of the OpenDMA system property <c>ReadOnly</c><summary>
        public static readonly OdmaQName PROPERTY_READONLY = new OdmaQName("opendma", "ReadOnly");

        // Property Hidden already defined previously

        // Property System already defined previously

        /// <summary>qualified name of the OpenDMA system property <c>Choices</c><summary>
        public static readonly OdmaQName PROPERTY_CHOICES = new OdmaQName("opendma", "Choices");

        // -----< class ChoiceValue >---------------------------------------------------------------

        /// <summary>qualified name of the OpenDMA system class <c>ChoiceValue</c></summary>
        public static readonly OdmaQName CLASS_CHOICEVALUE = new OdmaQName("opendma", "ChoiceValue");

        // Property DisplayName already defined previously

        /// <summary>qualified name of the OpenDMA system property <c>StringValue</c><summary>
        public static readonly OdmaQName PROPERTY_STRINGVALUE = new OdmaQName("opendma", "StringValue");

        /// <summary>qualified name of the OpenDMA system property <c>IntegerValue</c><summary>
        public static readonly OdmaQName PROPERTY_INTEGERVALUE = new OdmaQName("opendma", "IntegerValue");

        /// <summary>qualified name of the OpenDMA system property <c>ShortValue</c><summary>
        public static readonly OdmaQName PROPERTY_SHORTVALUE = new OdmaQName("opendma", "ShortValue");

        /// <summary>qualified name of the OpenDMA system property <c>LongValue</c><summary>
        public static readonly OdmaQName PROPERTY_LONGVALUE = new OdmaQName("opendma", "LongValue");

        /// <summary>qualified name of the OpenDMA system property <c>FloatValue</c><summary>
        public static readonly OdmaQName PROPERTY_FLOATVALUE = new OdmaQName("opendma", "FloatValue");

        /// <summary>qualified name of the OpenDMA system property <c>DoubleValue</c><summary>
        public static readonly OdmaQName PROPERTY_DOUBLEVALUE = new OdmaQName("opendma", "DoubleValue");

        /// <summary>qualified name of the OpenDMA system property <c>BooleanValue</c><summary>
        public static readonly OdmaQName PROPERTY_BOOLEANVALUE = new OdmaQName("opendma", "BooleanValue");

        /// <summary>qualified name of the OpenDMA system property <c>DateTimeValue</c><summary>
        public static readonly OdmaQName PROPERTY_DATETIMEVALUE = new OdmaQName("opendma", "DateTimeValue");

        /// <summary>qualified name of the OpenDMA system property <c>BinaryValue</c><summary>
        public static readonly OdmaQName PROPERTY_BINARYVALUE = new OdmaQName("opendma", "BinaryValue");

        /// <summary>qualified name of the OpenDMA system property <c>ReferenceValue</c><summary>
        public static readonly OdmaQName PROPERTY_REFERENCEVALUE = new OdmaQName("opendma", "ReferenceValue");

        // -----< class Repository >----------------------------------------------------------------

        /// <summary>qualified name of the OpenDMA system class <c>Repository</c></summary>
        public static readonly OdmaQName CLASS_REPOSITORY = new OdmaQName("opendma", "Repository");

        // Property Name already defined previously

        // Property DisplayName already defined previously

        /// <summary>qualified name of the OpenDMA system property <c>RootClass</c><summary>
        public static readonly OdmaQName PROPERTY_ROOTCLASS = new OdmaQName("opendma", "RootClass");

        /// <summary>qualified name of the OpenDMA system property <c>RootAspects</c><summary>
        public static readonly OdmaQName PROPERTY_ROOTASPECTS = new OdmaQName("opendma", "RootAspects");

        /// <summary>qualified name of the OpenDMA system property <c>RootFolder</c><summary>
        public static readonly OdmaQName PROPERTY_ROOTFOLDER = new OdmaQName("opendma", "RootFolder");

        // -----< class AuditStamped >--------------------------------------------------------------

        /// <summary>qualified name of the OpenDMA system class <c>AuditStamped</c></summary>
        public static readonly OdmaQName CLASS_AUDITSTAMPED = new OdmaQName("opendma", "AuditStamped");

        /// <summary>qualified name of the OpenDMA system property <c>CreatedAt</c><summary>
        public static readonly OdmaQName PROPERTY_CREATEDAT = new OdmaQName("opendma", "CreatedAt");

        /// <summary>qualified name of the OpenDMA system property <c>CreatedBy</c><summary>
        public static readonly OdmaQName PROPERTY_CREATEDBY = new OdmaQName("opendma", "CreatedBy");

        /// <summary>qualified name of the OpenDMA system property <c>LastModifiedAt</c><summary>
        public static readonly OdmaQName PROPERTY_LASTMODIFIEDAT = new OdmaQName("opendma", "LastModifiedAt");

        /// <summary>qualified name of the OpenDMA system property <c>LastModifiedBy</c><summary>
        public static readonly OdmaQName PROPERTY_LASTMODIFIEDBY = new OdmaQName("opendma", "LastModifiedBy");

        // -----< class Document >------------------------------------------------------------------

        /// <summary>qualified name of the OpenDMA system class <c>Document</c></summary>
        public static readonly OdmaQName CLASS_DOCUMENT = new OdmaQName("opendma", "Document");

        /// <summary>qualified name of the OpenDMA system property <c>Title</c><summary>
        public static readonly OdmaQName PROPERTY_TITLE = new OdmaQName("opendma", "Title");

        /// <summary>qualified name of the OpenDMA system property <c>Version</c><summary>
        public static readonly OdmaQName PROPERTY_VERSION = new OdmaQName("opendma", "Version");

        /// <summary>qualified name of the OpenDMA system property <c>VersionCollection</c><summary>
        public static readonly OdmaQName PROPERTY_VERSIONCOLLECTION = new OdmaQName("opendma", "VersionCollection");

        /// <summary>qualified name of the OpenDMA system property <c>VersionIndependentId</c><summary>
        public static readonly OdmaQName PROPERTY_VERSIONINDEPENDENTID = new OdmaQName("opendma", "VersionIndependentId");

        /// <summary>qualified name of the OpenDMA system property <c>VersionIndependentGuid</c><summary>
        public static readonly OdmaQName PROPERTY_VERSIONINDEPENDENTGUID = new OdmaQName("opendma", "VersionIndependentGuid");

        /// <summary>qualified name of the OpenDMA system property <c>ContentElements</c><summary>
        public static readonly OdmaQName PROPERTY_CONTENTELEMENTS = new OdmaQName("opendma", "ContentElements");

        /// <summary>qualified name of the OpenDMA system property <c>CombinedContentType</c><summary>
        public static readonly OdmaQName PROPERTY_COMBINEDCONTENTTYPE = new OdmaQName("opendma", "CombinedContentType");

        /// <summary>qualified name of the OpenDMA system property <c>PrimaryContentElement</c><summary>
        public static readonly OdmaQName PROPERTY_PRIMARYCONTENTELEMENT = new OdmaQName("opendma", "PrimaryContentElement");

        /// <summary>qualified name of the OpenDMA system property <c>CheckedOut</c><summary>
        public static readonly OdmaQName PROPERTY_CHECKEDOUT = new OdmaQName("opendma", "CheckedOut");

        /// <summary>qualified name of the OpenDMA system property <c>CheckedOutAt</c><summary>
        public static readonly OdmaQName PROPERTY_CHECKEDOUTAT = new OdmaQName("opendma", "CheckedOutAt");

        /// <summary>qualified name of the OpenDMA system property <c>CheckedOutBy</c><summary>
        public static readonly OdmaQName PROPERTY_CHECKEDOUTBY = new OdmaQName("opendma", "CheckedOutBy");

        // -----< class ContentElement >------------------------------------------------------------

        /// <summary>qualified name of the OpenDMA system class <c>ContentElement</c></summary>
        public static readonly OdmaQName CLASS_CONTENTELEMENT = new OdmaQName("opendma", "ContentElement");

        /// <summary>qualified name of the OpenDMA system property <c>ContentType</c><summary>
        public static readonly OdmaQName PROPERTY_CONTENTTYPE = new OdmaQName("opendma", "ContentType");

        /// <summary>qualified name of the OpenDMA system property <c>Position</c><summary>
        public static readonly OdmaQName PROPERTY_POSITION = new OdmaQName("opendma", "Position");

        // -----< class DataContentElement >--------------------------------------------------------

        /// <summary>qualified name of the OpenDMA system class <c>DataContentElement</c></summary>
        public static readonly OdmaQName CLASS_DATACONTENTELEMENT = new OdmaQName("opendma", "DataContentElement");

        /// <summary>qualified name of the OpenDMA system property <c>Content</c><summary>
        public static readonly OdmaQName PROPERTY_CONTENT = new OdmaQName("opendma", "Content");

        /// <summary>qualified name of the OpenDMA system property <c>Size</c><summary>
        public static readonly OdmaQName PROPERTY_SIZE = new OdmaQName("opendma", "Size");

        /// <summary>qualified name of the OpenDMA system property <c>FileName</c><summary>
        public static readonly OdmaQName PROPERTY_FILENAME = new OdmaQName("opendma", "FileName");

        // -----< class ReferenceContentElement >---------------------------------------------------

        /// <summary>qualified name of the OpenDMA system class <c>ReferenceContentElement</c></summary>
        public static readonly OdmaQName CLASS_REFERENCECONTENTELEMENT = new OdmaQName("opendma", "ReferenceContentElement");

        /// <summary>qualified name of the OpenDMA system property <c>Location</c><summary>
        public static readonly OdmaQName PROPERTY_LOCATION = new OdmaQName("opendma", "Location");

        // -----< class VersionCollection >---------------------------------------------------------

        /// <summary>qualified name of the OpenDMA system class <c>VersionCollection</c></summary>
        public static readonly OdmaQName CLASS_VERSIONCOLLECTION = new OdmaQName("opendma", "VersionCollection");

        /// <summary>qualified name of the OpenDMA system property <c>Versions</c><summary>
        public static readonly OdmaQName PROPERTY_VERSIONS = new OdmaQName("opendma", "Versions");

        /// <summary>qualified name of the OpenDMA system property <c>Latest</c><summary>
        public static readonly OdmaQName PROPERTY_LATEST = new OdmaQName("opendma", "Latest");

        /// <summary>qualified name of the OpenDMA system property <c>Released</c><summary>
        public static readonly OdmaQName PROPERTY_RELEASED = new OdmaQName("opendma", "Released");

        /// <summary>qualified name of the OpenDMA system property <c>InProgress</c><summary>
        public static readonly OdmaQName PROPERTY_INPROGRESS = new OdmaQName("opendma", "InProgress");

        // -----< class Container >-----------------------------------------------------------------

        /// <summary>qualified name of the OpenDMA system class <c>Container</c></summary>
        public static readonly OdmaQName CLASS_CONTAINER = new OdmaQName("opendma", "Container");

        // Property Title already defined previously

        /// <summary>qualified name of the OpenDMA system property <c>Containees</c><summary>
        public static readonly OdmaQName PROPERTY_CONTAINEES = new OdmaQName("opendma", "Containees");

        /// <summary>qualified name of the OpenDMA system property <c>Associations</c><summary>
        public static readonly OdmaQName PROPERTY_ASSOCIATIONS = new OdmaQName("opendma", "Associations");

        // -----< class Folder >--------------------------------------------------------------------

        /// <summary>qualified name of the OpenDMA system class <c>Folder</c></summary>
        public static readonly OdmaQName CLASS_FOLDER = new OdmaQName("opendma", "Folder");

        /// <summary>qualified name of the OpenDMA system property <c>Parent</c><summary>
        public static readonly OdmaQName PROPERTY_PARENT = new OdmaQName("opendma", "Parent");

        /// <summary>qualified name of the OpenDMA system property <c>SubFolders</c><summary>
        public static readonly OdmaQName PROPERTY_SUBFOLDERS = new OdmaQName("opendma", "SubFolders");

        // -----< class Containable >---------------------------------------------------------------

        /// <summary>qualified name of the OpenDMA system class <c>Containable</c></summary>
        public static readonly OdmaQName CLASS_CONTAINABLE = new OdmaQName("opendma", "Containable");

        /// <summary>qualified name of the OpenDMA system property <c>ContainedIn</c><summary>
        public static readonly OdmaQName PROPERTY_CONTAINEDIN = new OdmaQName("opendma", "ContainedIn");

        /// <summary>qualified name of the OpenDMA system property <c>ContainedInAssociations</c><summary>
        public static readonly OdmaQName PROPERTY_CONTAINEDINASSOCIATIONS = new OdmaQName("opendma", "ContainedInAssociations");

        // -----< class Association >---------------------------------------------------------------

        /// <summary>qualified name of the OpenDMA system class <c>Association</c></summary>
        public static readonly OdmaQName CLASS_ASSOCIATION = new OdmaQName("opendma", "Association");

        // Property Name already defined previously

        /// <summary>qualified name of the OpenDMA system property <c>Container</c><summary>
        public static readonly OdmaQName PROPERTY_CONTAINER = new OdmaQName("opendma", "Container");

        /// <summary>qualified name of the OpenDMA system property <c>Containable</c><summary>
        public static readonly OdmaQName PROPERTY_CONTAINABLE = new OdmaQName("opendma", "Containable");

    }

}
