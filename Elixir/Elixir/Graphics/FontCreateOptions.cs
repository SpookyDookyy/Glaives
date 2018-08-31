﻿using System;

namespace Elixir.Graphics
{
    /// <summary>
    /// The create options to use for the font
    /// </summary>
    public struct FontCreateOptions : IEquatable<FontCreateOptions>
    {
        /// <summary>
        /// The size of the font
        /// </summary>
        public readonly float Size;

        /// <summary>
        /// The styling of the font (flags)
        /// </summary>
        public readonly FontStyleFlags StyleFlags;

        /// <summary>
        /// The alphabets supported by the font (flags)
        /// </summary>
        public readonly AlphabetFlags SupportedAlphabetsFlags;

        /// <summary>
        /// The filter mode for the font texture
        /// </summary>
        public readonly TextureFilterMode FilterMode;

        /// <inheritdoc />
        /// <summary>
        /// Create new font create options
        /// </summary>
        /// <param name="size">The size of the font</param>
        public FontCreateOptions(float size)
            : this(size, FontStyleFlags.Regular, TextureFilterMode.Linear, AlphabetFlags.Latin)
        {
            Size = size;
        }

        /// <inheritdoc />
        /// <summary>
        /// Create new font create options
        /// </summary>
        /// <param name="size">The size of the font</param>
        /// <param name="styleFlags">The styling of the font (flags)</param>
        public FontCreateOptions(float size, FontStyleFlags styleFlags)
            : this(size, styleFlags, TextureFilterMode.Linear, AlphabetFlags.Latin)
        {
            Size = size;
            StyleFlags = styleFlags;
        }

        /// <inheritdoc />
        /// <summary>
        /// Create new font create options
        /// </summary>
        /// <param name="size">The size of the font</param>
        /// <param name="styleFlags">The styling of the font (flags)</param>
        /// <param name="filterMode">The filter mode for the font texture</param>
        public FontCreateOptions(float size, FontStyleFlags styleFlags, TextureFilterMode filterMode)
            : this(size, styleFlags, filterMode, AlphabetFlags.Latin)
        {
            Size = size;
            FilterMode = filterMode;
            StyleFlags = styleFlags;
        }

        /// <summary>
        /// Create new font create options
        /// </summary>
        /// <param name="size">The size of the font</param>
        /// <param name="styleFlags">The styling of the font (flags)</param>
        /// <param name="filterMode">The filter mode for the font texture</param>
        /// <param name="supportedAlphabetsFlags">The alphabets supported by the font (flags)</param>
        public FontCreateOptions(float size, FontStyleFlags styleFlags, TextureFilterMode filterMode, AlphabetFlags supportedAlphabetsFlags)
        {
            Size = size;
            FilterMode = filterMode;
            StyleFlags = styleFlags;
            SupportedAlphabetsFlags = supportedAlphabetsFlags;
        }

        public bool Equals(FontCreateOptions other)
        {
            return Size.Equals(other.Size) && StyleFlags == other.StyleFlags && SupportedAlphabetsFlags == other.SupportedAlphabetsFlags && FilterMode == other.FilterMode;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is FontCreateOptions && Equals((FontCreateOptions) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Size.GetHashCode();
                hashCode = (hashCode * 397) ^ (int) StyleFlags;
                hashCode = (hashCode * 397) ^ (int) SupportedAlphabetsFlags;
                hashCode = (hashCode * 397) ^ (int) FilterMode;
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"(Size: {Size}, StyleFlags: {StyleFlags}, Filter: {FilterMode}, Alphabets: {SupportedAlphabetsFlags})";
        }

        public static bool operator ==(FontCreateOptions left, FontCreateOptions right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FontCreateOptions left, FontCreateOptions right)
        {
            return !left.Equals(right);
        }
    }
}