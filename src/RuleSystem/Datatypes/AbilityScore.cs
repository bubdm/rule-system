// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using MarcKing.RuleSystem.Interfaces.Datatypes;
using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace MarcKing.RuleSystem.Datatypes
{
    /// <summary>
    /// Represents a character ability score and the appropriate modifier.
    /// </summary>
    [Serializable]
    public struct AbilityScore : IAbilityScore, IComparable, IComparable<AbilityScore>,
        IEquatable<AbilityScore>, IFormattable, ISerializable
    {
        private readonly sbyte _modifier;

        private readonly byte _value;

        /// <summary>
        /// Represents the average value of an <see cref="AbilityScore"/>. This field is constant.
        /// </summary>
        public const byte AverageValue = 10;

        /// <summary>
        /// Represents the largest possible value of an <see cref="AbilityScore"/>. This field is
        /// constant.
        /// </summary>
        public const byte MaxValue = 30;

        /// <summary>
        /// Represents the smallest possible value of an <see cref="AbilityScore"/>. This field is
        /// constant.
        /// </summary>
        public const byte MinValue = 1;

        /// <summary>
        /// Initializes a new <see cref="AbilityScore"/> from serialization data.
        /// </summary>
        private AbilityScore(SerializationInfo serializationInfo,
                             StreamingContext streamingContext)
        {
            _value = serializationInfo.GetByte(nameof(_value));
            _modifier = CalculateModifier(_value);
        }

        /// <summary>
        /// Initializes a new <see cref="AbilityScore"/> from a <see cref="byte"/> value.
        /// </summary>
        /// <param name="value">
        /// The value with which to initialize the <see cref="AbilityScore"/>.
        /// </param>
        public AbilityScore(byte value)
        {
            _value = ClampValue(value);
            _modifier = CalculateModifier(_value);
        }

        /// <summary>
        /// Returns the modifier for this <see cref="AbilityScore"/> object.
        /// </summary>
        public sbyte Modifier => _modifier;

        /// <summary>
        /// Returns the value for this <see cref="AbilityScore"/> object.
        /// </summary>
        public byte Value => _value;

        /// <summary>
        /// Calculates the modifier for the specified value.
        /// </summary>
        /// <param name="value">
        /// A <see cref="byte"/> value for which to calculate the modifier.
        /// </param>
        /// <returns>
        /// A <see cref="sbyte"/> representing the modifier for the specified value.
        /// </returns>
        private static sbyte CalculateModifier(byte value)
        {
            return Convert.ToSByte(Math.Floor((value - 10) / 2.0));
        }

        /// <summary>
        /// Clamps the specified value to a range of <see cref="MinValue"/> through
        /// <see cref="MaxValue"/>.
        /// </summary>
        /// <param name="value">
        /// A <see cref="byte"/> value to clamp.
        /// </param>
        /// <returns>
        /// A <see cref="byte"/> within the range of <see cref="MinValue"/> through
        /// <see cref="MaxValue"/>.
        /// </returns>
        private static byte ClampValue(byte value)
        {
            return (value <= MinValue) ? MinValue : (value >= MaxValue) ? MaxValue : value;
        }

        /// <summary>
        /// Implicitly casts a <see cref="byte"/> to an <see cref="AbilityScore"/>.
        /// </summary>
        /// <param name="value">
        /// A <see cref="byte"/> to cast to an <see cref="AbilityScore"/>.
        /// </param>
        public static implicit operator AbilityScore(byte value)
        {
            return new AbilityScore(value);
        }

        /// <summary>
        /// Implicitly casts an <see cref="AbilityScore"/> to a <see cref="byte"/>.
        /// </summary>
        /// <param name="abilityScore">
        /// An <see cref="AbilityScore"/> to cast to a <see cref="byte"/>.
        /// </param>
        public static implicit operator byte(AbilityScore abilityScore)
        {
            return abilityScore.Value;
        }

        /// <summary>
        /// The inequality operator (!=) returns <c>false</c> if its operands are equal, <c>true</c>
        /// otherwise.
        /// </summary>
        /// <param name="left">
        /// Operand on the left side of the operator.
        /// </param>
        /// <param name="right">
        /// Operand on the right side of the operator.
        /// </param>
        /// <returns>
        /// <c>false</c> if the operands are equal, <c>true</c> otherwise.
        /// </returns>
        public static bool operator !=(AbilityScore left, AbilityScore right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// The "less than" relational operator (&lt;) that returns <c>true</c> if the left operand
        /// is less than the right, <c>right</c> otherwise.
        /// </summary>
        /// <param name="left">
        /// Operand on the left side of the operator.
        /// </param>
        /// <param name="right">
        /// Operand on the right side of the operator.
        /// </param>
        /// <returns>
        /// <c>true</c> if the left operand is less than the right, <c>right</c> otherwise.
        /// </returns>
        public static bool operator <(AbilityScore left, AbilityScore right)
        {
            return left.CompareTo(right) < 0;
        }

        /// <summary>
        /// The "less than or equal" relational operator (&lt;=) that returns <c>true</c> if the left
        /// operand is less than or equal to the right, <c>right</c> otherwise.
        /// </summary>
        /// <param name="left">
        /// Operand on the left side of the operator.
        /// </param>
        /// <param name="right">
        /// Operand on the right side of the operator.
        /// </param>
        /// <returns>
        /// <c>true</c> if the left operand is less than or equal to the right, <c>right</c>
        /// otherwise.
        /// </returns>
        public static bool operator <=(AbilityScore left, AbilityScore right)
        {
            return left.CompareTo(right) <= 0;
        }

        /// <summary>
        /// The equality operator (==) returns <c>true</c> if the values of its operands are equal,
        /// <c>false</c> otherwise.
        /// </summary>
        /// <param name="left">
        /// Operand on the left side of the operator.
        /// </param>
        /// <param name="right">
        /// Operand on the right side of the operator.
        /// </param>
        /// <returns>
        /// <c>true</c> if the values of its operands are equal, <c>false</c> otherwise.
        /// </returns>
        public static bool operator ==(AbilityScore left, AbilityScore right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// The "greater than" relational operator (&gt;) that returns <c>true</c> if the left
        /// operand is greater than the right, <c>right</c> otherwise.
        /// </summary>
        /// <param name="left">
        /// Operand on the left side of the operator.
        /// </param>
        /// <param name="right">
        /// Operand on the right side of the operator.
        /// </param>
        /// <returns>
        /// <c>true</c> if the left operand is greater than the right, <c>right</c> otherwise.
        /// </returns>
        public static bool operator >(AbilityScore left, AbilityScore right)
        {
            return left.CompareTo(right) > 0;
        }

        /// <summary>
        /// The "greater than or equal" relational operator (&gt;=) that returns <c>true</c> if the
        /// left operand is greater than or equal to the right, <c>right</c> otherwise.
        /// </summary>
        /// <param name="left">
        /// Operand on the left side of the operator.
        /// </param>
        /// <param name="right">
        /// Operand on the right side of the operator.
        /// </param>
        /// <returns>
        /// <c>true</c> if the left operand is greater than or equal to the right, <c>right</c>
        /// otherwise.
        /// </returns>
        public static bool operator >=(AbilityScore left, AbilityScore right)
        {
            return left.CompareTo(right) >= 0;
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="AbilityScore"/> and returns an
        /// indication of their relative values.
        /// </summary>
        /// <param name="other">
        /// An <see cref="AbilityScore"/> to compare.
        /// </param>
        /// <returns>
        /// A signed integer that indicates the relative order of this instance and
        /// <paramref name="other"/>.
        /// <list type="table">
        /// <listheader>
        /// <term>Return Value</term>
        /// <description>Meaning</description>
        /// </listheader>
        /// <item>
        /// <term>Less than zero</term>
        /// <description>This instance is less than <paramref name="other"/>.</description>
        /// </item>
        /// <item>
        /// <term>Zero</term>
        /// <description>This instance is equal to <paramref name="other"/>.</description>
        /// </item>
        /// <item>
        /// <term>Greater than zero</term>
        /// <description>This instance is greater than <paramref name="other"/>.</description>
        /// </item>
        /// </list>
        /// </returns>
        public int CompareTo(AbilityScore other)
        {
            return _value.CompareTo(other.Value);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="other">
        /// An object to compare with this instance, or <c>null</c>.
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="other"/> is an instance of <see cref="AbilityScore"/> and
        /// equals the value of this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object other)
        {
            if (other == null) return false;

            try
            {
                return Equals((AbilityScore)other);
            }
            catch (InvalidCastException)
            {
                return false;
            }
        }

        /// <summary>
        /// Returns a value indicating whether this instance and a specified
        /// <see cref="AbilityScore"/> object represent the same value.
        /// </summary>
        /// <param name="other">
        /// An object to compare to this instance.
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="other"/> is equal to this instance; otherwise,
        /// <c>false.</c>
        /// </returns>
        public bool Equals(AbilityScore other)
        {
            return _value.Equals(other.Value);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="AbilityScore"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        /// <summary>
        /// Populates a <see cref="SerializationInfo"/> with the data needed to serialize the
        /// <see cref="AbilityScore"/> object.
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo"/> to populate with data.
        /// </param>
        /// <param name="context">
        /// The destination (see <see cref="StreamingContext"/>) for this serialization.
        /// </param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(_value), _value);
        }

        /// <summary>
        /// Converts the value of the current <see cref="AbilityScore"/> object to its equivalent
        /// string representation.
        /// </summary>
        /// <returns>
        /// The string representation of the value of this object, which consists of a sequence of
        /// digits that range from 0 to 9 with no leading zeroes.
        /// </returns>
        /// <remarks>
        /// The return value is formatted with the general numeric format specifier ("G") and the
        /// <see cref="NumberFormatInfo"/> object for the thread current culture.
        /// </remarks>
        public override string ToString()
        {
            return ToString("G", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Converts the value of the current <see cref="AbilityScore"/> object to its equivalent
        /// string representation using the specified format and culture-specific formatting
        /// information.
        /// </summary>
        /// <param name="format">
        /// A standard format string.
        /// </param>
        /// <param name="provider">
        /// An object that supplies culture-specific formatting information.
        /// </param>
        /// <returns>
        /// The string representation of the current <see cref="AbilityScore"/> object, formatted as
        /// specified by the <paramref name="format"/> and <paramref name="provider"/> parameters.
        /// </returns>
        /// <exception cref="FormatException">
        /// <paramref name="format"/> includes an unsupported specifier. Supported format specifiers
        /// are listed in the Remarks section.
        /// </exception>
        /// <remarks>
        /// The <paramref name="format"/> can be "G" to display the value of the current
        /// <see cref="AbilityScore"/> object. The <paramref name="format"/> can be "M" to display
        /// the value and modifier of the current <see cref="AbilityScore"/> object. The
        /// <paramref name="format"/> can be "R" to display the same data as "M" but right aligned with
        /// spaces. The <paramref name="format"/> can be "L" to display the same data as "M" but left aligned with spaces.
        /// </remarks>
        public string ToString(string format, IFormatProvider provider)
        {
            if (String.IsNullOrEmpty(format)) format = "G";
            if (provider == null) provider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "G":
                    return _value.ToString(format, provider);

                case "M":
                    return $"{_value.ToString(provider)} ({_modifier.ToString("+#;-#;0", provider)})";

                case "L":
                    return $"{_value.ToString(provider)} {(_value < 10 ? " " : "")}({_modifier.ToString("+#;-#;0", provider)})";

                case "R":
                    return $"{(_value < 10 ? " " : "")}{_value.ToString(provider)} {(_modifier < 10 ? " " : "")}{(_modifier == 0 ? " " : "")}({_modifier.ToString("+#;-#;0", provider)})";

                case "C":
                    return $"{(_value < 10 ? " " : "")}{_value.ToString(provider)} ({_modifier.ToString("+#;-#;0", provider)})";

                default:
                    throw new FormatException($"The {format} format string is not supported.");
            }
        }

        /// <summary>
        /// Converts the numeric value of the current <see cref="AbilityScore"/> object to its
        /// equivalent string representation using the specified culture-specific formatting
        /// information.
        /// </summary>
        /// <param name="provider">
        /// An object that supplies culture-specific formatting information.
        /// </param>
        /// <returns>
        /// The string representation of the value of this object in the format specified by the
        /// <paramref name="provider"/> parameter.
        /// </returns>
        /// <remarks>
        /// The return value is formatted with the general numeric format specifier ("G").
        /// </remarks>
        public string ToString(IFormatProvider provider)
        {
            return ToString("G", provider);
        }

        /// <summary>
        /// Converts the value of the current <see cref="AbilityScore"/> object to its equivalent
        /// string representation using the specified format.
        /// </summary>
        /// <param name="format">
        /// A numeric format string.
        /// </param>
        /// <returns>
        /// he string representation of the current <see cref="AbilityScore"/> object, formatted as
        /// specified by the <paramref name="format"/> parameter.
        /// </returns>
        /// <exception cref="FormatException">
        /// <paramref name="format"/> includes an unsupported specifier. Supported format specifiers
        /// are listed in the Remarks section.
        /// </exception>
        /// <remarks>
        /// The <paramref name="format"/> can be "G" to display the value of the current
        /// <see cref="AbilityScore"/> object. The <paramref name="format"/> can be "M" to display
        /// the value and modifier of the current <see cref="AbilityScore"/> object. The return value
        /// of this function is formatted using the <see cref="NumberFormatInfo"/> object for the
        /// thread current culture.
        /// </remarks>
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Compares this instance to a specified object and returns an indication of their relative
        /// values.
        /// </summary>
        /// <param name="other">
        /// An object to compare, or <c>null</c>.
        /// </param>
        /// <returns>
        /// A signed integer that indicates the relative order of this instance and
        /// <paramref name="other"/>.
        /// <list type="table">
        /// <listheader>
        /// <term>Return Value</term>
        /// <description>Meaning</description>
        /// </listheader>
        /// <item>
        /// <term>Less than zero</term>
        /// <description>This instance is less than <paramref name="other"/>.</description>
        /// </item>
        /// <item>
        /// <term>Zero</term>
        /// <description>This instance is equal to <paramref name="other"/>.</description>
        /// </item>
        /// <item>
        /// <term>Greater than zero</term>
        /// <description>
        /// This instance is greater than <paramref name="other"/>, -or- <paramref name="other"/> is
        /// <c>null</c>.
        /// </description>
        /// </item>
        /// </list>
        /// </returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="other"/> is not an <see cref="AbilityScore"/>.
        /// </exception>
        int IComparable.CompareTo(object other)
        {
            if (other == null) return 1;

            try
            {
                return CompareTo((AbilityScore)other);
            }
            catch (InvalidCastException ex)
            {
                throw new ArgumentException($"Object is not an {nameof(AbilityScore)}", ex);
            }
        }
    }
}
