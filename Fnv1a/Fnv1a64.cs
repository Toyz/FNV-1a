﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Fnv1a64.cs" company="Always Elucidated Solution Pioneers, LLC">
//   Copyright © Always Elucidated Solution Pioneers, LLC 2014
// </copyright>
// <summary>
//   Implements the FNV-1a 64-bit variant hashing algorithm.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Fnv1a
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary>
    /// Implements the FNV-1a 64-bit variant hashing algorithm.
    /// </summary>
    // ReSharper disable once InconsistentNaming
#pragma warning disable S101 // Types should be named in PascalCase
    public sealed class Fnv1a64 : System.Security.Cryptography.HashAlgorithm
#pragma warning restore S101 // Types should be named in PascalCase
    {
        /// <summary>
        /// The prime.
        /// </summary>
        private const ulong FnvPrime = 0x00000100000001B3;

        /// <summary>
        /// The non-zero offset basis.
        /// </summary>
        private const ulong FnvOffsetBasis = 0xCBF29CE484222325;

        /// <summary>
        /// The hash.
        /// </summary>
        private ulong _hash;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="Fnv1a64"/> class.
        /// </summary>
        public Fnv1a64()
        {
            this.Initialize();
            this.HashSizeValue = 64;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes an implementation of the <see cref="T:System.Security.Cryptography.HashAlgorithm"/> class.
        /// </summary>
        public override void Initialize() => this._hash = FnvOffsetBasis;

        /// <inheritdoc />
        /// <summary>
        /// When overridden in a derived class, routes data written to the object into the hash algorithm for computing
        /// the hash.
        /// </summary>
        /// <param name="array">The input to compute the hash code for.</param>
        /// <param name="ibStart">The offset into the byte array from which to begin using data.</param>
        /// <param name="cbSize">The number of bytes in the byte array to use as data.</param>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            for (int i = ibStart; i < cbSize; i++)
            {
                unchecked
                {
                    this._hash ^= array[i];
                    this._hash *= FnvPrime;
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// When overridden in a derived class, finalizes the hash computation after the last data is processed by the
        /// cryptographic stream object.
        /// </summary>
        /// <returns>
        /// The computed hash code.
        /// </returns>
        protected override byte[] HashFinal() => BitConverter.GetBytes(this._hash);
    }
}
