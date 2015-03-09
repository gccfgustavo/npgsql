﻿using JetBrains.Annotations;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace EntityFramework.Npgsql.Extensions
{
    public static class Strings
    {
        private static readonly ResourceManager _resourceManager
            = new ResourceManager("EntityFramework.Npgsql.Strings", typeof(Strings).GetTypeInfo().Assembly);

        /// <summary>
        /// The value for the configuration entry '{configurationKey}' is '{invalidValue}', but an integer is expected.
        /// </summary>
        public static string IntegerConfigurationValueFormatError([CanBeNull] object configurationKey, [CanBeNull] object invalidValue)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("IntegerConfigurationValueFormatError", "configurationKey", "invalidValue"), configurationKey, invalidValue);
        }

        /// <summary>
        /// The value provided for argument '{argumentName}' must be a valid value of enum type '{enumType}'.
        /// </summary>
        public static string InvalidEnumValue([CanBeNull] object argumentName, [CanBeNull] object enumType)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("InvalidEnumValue", "argumentName", "enumType"), argumentName, enumType);
        }

        /// <summary>
        /// The value provided for max batch size must be positive.
        /// </summary>
        public static string MaxBatchSizeMustBePositive
        {
            get { return GetString("MaxBatchSizeMustBePositive"); }
        }

        /// <summary>
        /// The increment value of '{increment}' for sequence '{sequenceName}' cannot be used for value generation. Sequences used for value generation must have positive increments.
        /// </summary>
        public static string SequenceBadBlockSize([CanBeNull] object increment, [CanBeNull] object sequenceName)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("SequenceBadBlockSize", "increment", "sequenceName"), increment, sequenceName);
        }

        /// <summary>
        /// Identity value generation cannot be used for the property '{property}' on entity type '{entityType}' because the property type is '{propertyType}'. Identity value generation can only be used with signed integer properties.
        /// </summary>
        public static string IdentityBadType([CanBeNull] object property, [CanBeNull] object entityType, [CanBeNull] object propertyType)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("IdentityBadType", "property", "entityType", "propertyType"), property, entityType, propertyType);
        }

        /// <summary>
        /// SQL Server sequences cannot be used to generate values for the property '{property}' on entity type '{entityType}' because the property type is '{propertyType}'. Sequences can only be used with integer properties.
        /// </summary>
        public static string SequenceBadType([CanBeNull] object property, [CanBeNull] object entityType, [CanBeNull] object propertyType)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("SequenceBadType", "property", "entityType", "propertyType"), property, entityType, propertyType);
        }

        public static string SkipNeedsOrderBy
        {
            get { return "A query containing the Skip operator must include at least one OrderBy operation."; }
        }

        /// <summary>
        /// SQL Server-specific methods can only be used when the context is using a SQL Server data store.
        /// </summary>
        public static string PostgresNotInUse
        {
            get { return GetString("PostgresNotInUse"); }
        }

        private static string GetString(string name, params string[] formatterNames)
        {
            var value = _resourceManager.GetString(name);

            Debug.Assert(value != null);

            if (formatterNames != null)
            {
                for (var i = 0; i < formatterNames.Length; i++)
                {
                    value = value.Replace("{" + formatterNames[i] + "}", "{" + i + "}");
                }
            }

            return value;
        }
    }
}