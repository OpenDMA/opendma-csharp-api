using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDMA.Api
{

    /// <summary>OpenDMA property data types.</summary>
    public enum OdmaType
    {
        STRING = 1,
        INTEGER = 2,
        SHORT = 3,
        LONG = 4,
        FLOAT = 5,
        DOUBLE = 6,
        BOOLEAN = 7,
        DATETIME = 8,
        BINARY = 9,
        REFERENCE = 10,
        CONTENT = 11,
        ID = 100,
        GUID = 101
    }

    public enum OdmaTypeHelper
    {
        public static OdmaType FromString(string value)
        {
            if (Enum.TryParse<OdmaType>(value, ignoreCase: true, out var result))
            {
                return result;
            }
            throw new ArgumentException($"Unknown OdmaType name: '{value}'");
        }
    }

}
