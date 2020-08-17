using System;

namespace G1ANT.Addon.amazon.Api.Enums
{
    public enum AttributeOperationType
    {
        PreferAttribute,
        ForceAttribute,
        ForceProperty,
        Default = PreferAttribute
    }

    public static class AttributeOperationTypeParser
    {
        public static AttributeOperationType Parse(string operationTypeName)
        {
            if (string.IsNullOrEmpty(operationTypeName))
                return AttributeOperationType.Default;

            return (AttributeOperationType)Enum.Parse(typeof(AttributeOperationType), operationTypeName, true);
        }
    }
}