﻿using System.Text;

namespace CSharp.ExtensionMethods;

public static partial class StringExtensions
{
    public enum MaskStyle
    {
        /// <summary>
        /// Masks all characters within the masking region, regardless of type.
        /// </summary>
        All,

        /// <summary>
        /// Masks only alphabetic and numeric characters within the masking region.
        /// </summary>
        AlphaNumericOnly,
    }

    /// <summary>
    /// Converts the string to an enum
    /// </summary>
    /// <returns></returns>
    public static readonly char DefaultMaskCharacter = '*';

    /// <summary>
    /// Returns true if the string is non-null and at least the specified number of characters.
    /// </summary>
    /// <param name="this">The string to check.</param>
    /// <param name="length">The minimum length.</param>
    /// <returns>True if string is non-null and at least the length specified.</returns>
    /// <exception>throws ArgumentOutOfRangeException if length is not a non-negative number.</exception>
    public static bool IsLengthAtLeast(this string @this, int length)
    {
        if (length < 0)
            throw new ArgumentOutOfRangeException(nameof(length), length, "The length must be a non-negative number.");

        return @this != null
                    && @this.Length >= length;
    }

    /// <summary>
    /// Mask the source string with the mask char except for the last exposed digits.
    /// </summary>
    /// <param name="this">Original string to mask.</param>
    /// <param name="maskChar">The character to use to mask the source.</param>
    /// <param name="numExposed">Number of characters exposed in masked value.</param>
    /// <param name="style">The masking style to use (all characters or just alpha-nums).</param>
    /// <returns>The masked account number.</returns>
    public static string Mask(this string @this, char maskChar, int numExposed, MaskStyle style)
    {
        var maskedString = @this;

        if (@this.IsLengthAtLeast(numExposed))
        {
            var builder = new StringBuilder(@this.Length);
            int index = maskedString.Length - numExposed;

            if (style == MaskStyle.AlphaNumericOnly)
            {
                CreateAlphaNumMask(builder, @this, maskChar, index);
            }
            else
            {
                builder.Append(maskChar, index);
            }

            builder.Append(@this[index..]);
            maskedString = builder.ToString();
        }

        return maskedString;
    }

    /// <summary>
    /// Mask the source string with the mask char except for the last exposed digits.
    /// </summary>
    /// <param name="this">Original string to mask.</param>
    /// <param name="maskChar">The character to use to mask the source.</param>
    /// <param name="numExposed">Number of characters exposed in masked value.</param>
    /// <returns>The masked account number.</returns>
    public static string Mask(this string @this, char maskChar, int numExposed)
    {
        return Mask(@this, maskChar, numExposed, MaskStyle.All);
    }

    /// <summary>
    /// Mask the source string with the mask char.
    /// </summary>
    /// <param name="this">Original string to mask.</param>
    /// <param name="maskChar">The character to use to mask the source.</param>
    /// <returns>The masked account number.</returns>
    public static string Mask(this string @this, char maskChar) =>
        Mask(@this, maskChar, 0, MaskStyle.All);

    /// <summary>
    /// Mask the source string with the default mask char except for the last exposed digits.
    /// </summary>
    /// <param name="this">Original string to mask.</param>
    /// <param name="numExposed">Number of characters exposed in masked value.</param>
    /// <returns>The masked account number.</returns>
    public static string Mask(this string @this, int numExposed) =>
        Mask(@this, DefaultMaskCharacter, numExposed, MaskStyle.All);

    /// <summary>
    /// Mask the source string with the default mask char.
    /// </summary>
    /// <param name="this">Original string to mask.</param>
    /// <returns>The masked account number.</returns>
    public static string Mask(this string @this) =>
        Mask(@this, DefaultMaskCharacter, 0, MaskStyle.All);

    /// <summary>
    /// Mask the source string with the mask char.
    /// </summary>
    /// <param name="this">Original string to mask.</param>
    /// <param name="maskChar">The character to use to mask the source.</param>
    /// <param name="style">The masking style to use (all characters or just alpha-nums).</param>
    /// <returns>The masked account number.</returns>
    public static string Mask(this string @this, char maskChar, MaskStyle style) =>
        Mask(@this, maskChar, 0, style);

    /// <summary>
    /// Mask the source string with the default mask char except for the last exposed digits.
    /// </summary>
    /// <param name="this">Original string to mask.</param>
    /// <param name="numExposed">Number of characters exposed in masked value.</param>
    /// <param name="style">The masking style to use (all characters or just alpha-nums).</param>
    /// <returns>The masked account number.</returns>
    public static string Mask(this string @this, int numExposed, MaskStyle style) =>
        Mask(@this, DefaultMaskCharacter, numExposed, style);

    /// <summary>
    /// Mask the source string with the default mask char.
    /// </summary>
    /// <param name="this">Original string to mask.</param>
    /// <param name="style">The masking style to use (all characters or just alpha-nums).</param>
    /// <returns>The masked account number.</returns>
    public static string Mask(this string @this, MaskStyle style) =>
        Mask(@this, DefaultMaskCharacter, 0, style);

    /// <summary>
    /// Masks all characters for the specified length.
    /// </summary>
    /// <param name="buffer">String builder to store result in.</param>
    /// <param name="source">The source string to pull non-alpha numeric characters.</param>
    /// <param name="mask">Masking character to use.</param>
    /// <param name="length">Length of the mask.</param>
    private static void CreateAlphaNumMask(StringBuilder buffer, string source, char mask, int length)
    {
        for (int i = 0; i < length; i++)
        {
            buffer.Append(char.IsLetterOrDigit(source[i])
                            ? mask
                            : source[i]);
        }
    }
}