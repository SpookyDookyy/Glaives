﻿using System;

namespace Elixir.Graphics
{
    /// <summary>
    /// The create options to use for the texture
    /// </summary>
    public struct TextureCreateOptions : IEquatable<TextureCreateOptions>
    {
        /// <summary>
        /// <para>FilterMode : Linear</para>
        /// <para>WrapMode : ClampToEdge</para>
        /// </summary>
        public static TextureCreateOptions Smooth => new TextureCreateOptions(TextureFilterMode.Linear, TextureWrapMode.ClampToEdge);

        /// <summary>
        /// <para>FilterMode : Nearest</para>
        /// <para>WrapMode : ClampToEdge</para>
        /// </summary>
        public static TextureCreateOptions Sharp => new TextureCreateOptions(TextureFilterMode.Nearest, TextureWrapMode.ClampToEdge);

        /// <summary>
        /// The way the texture is filtered
        /// </summary>
        public readonly TextureFilterMode FilterMode;

        /// <summary>
        /// The way the texture is wrapped outside of the texture coordinates
        /// </summary>
        public readonly TextureWrapMode WrapMode;

        /// <summary>
        /// Create new texture create options
        /// </summary>
        /// <param name="filterMode">The way the texture is filtered</param>
        /// <param name="wrapMode">The way the texture is wrapped outside of the texture coordinates</param>
        public TextureCreateOptions(TextureFilterMode filterMode, TextureWrapMode wrapMode)
        {
            FilterMode = filterMode;
            WrapMode = wrapMode;
        }

        public bool Equals(TextureCreateOptions other)
        {
            return FilterMode == other.FilterMode && WrapMode == other.WrapMode;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is TextureCreateOptions && Equals((TextureCreateOptions) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) FilterMode * 397) ^ (int) WrapMode;
            }
        }

        public override string ToString()
        {
            return $"(Filter: {FilterMode}, Wrap: {WrapMode})";
        }

        public static bool operator ==(TextureCreateOptions left, TextureCreateOptions right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TextureCreateOptions left, TextureCreateOptions right)
        {
            return !left.Equals(right);
        }
    }
}