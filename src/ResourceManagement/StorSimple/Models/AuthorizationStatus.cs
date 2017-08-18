// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.StorSimple.Fluent.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.StorSimple;
    using Microsoft.Azure.Management.StorSimple.Fluent;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for AuthorizationStatus.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AuthorizationStatus
    {
        [EnumMember(Value = "Disabled")]
        Disabled,
        [EnumMember(Value = "Enabled")]
        Enabled
    }
    internal static class AuthorizationStatusEnumExtension
    {
        internal static string ToSerializedValue(this AuthorizationStatus? value)
        {
            return value == null ? null : ((AuthorizationStatus)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this AuthorizationStatus value)
        {
            switch( value )
            {
                case AuthorizationStatus.Disabled:
                    return "Disabled";
                case AuthorizationStatus.Enabled:
                    return "Enabled";
            }
            return null;
        }

        internal static AuthorizationStatus? ParseAuthorizationStatus(this string value)
        {
            switch( value )
            {
                case "Disabled":
                    return AuthorizationStatus.Disabled;
                case "Enabled":
                    return AuthorizationStatus.Enabled;
            }
            return null;
        }
    }
}