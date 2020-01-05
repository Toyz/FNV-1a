﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Fnv1a64Tests.cs" company="Always Elucidated Solution Pioneers, LLC">
//   Copyright © Always Elucidated Solution Pioneers, LLC 2014
// </copyright>
// <summary>
//   Tests the FNV-1a 64-bit algorithm.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Fnv1aTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static System.Text.Encoding;

    using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

    /// <inheritdoc />
    /// <summary>
    /// Tests the FNV-1a 64-bit algorithm.
    /// </summary>
    [TestClass]
    // ReSharper disable once InconsistentNaming
#pragma warning disable S101 // Types should be named in PascalCase
    public sealed class Fnv1a64Tests : IDisposable
#pragma warning restore S101 // Types should be named in PascalCase
    {
        /// <summary>
        /// The hash algorithm being tested.
        /// </summary>
        private System.Security.Cryptography.HashAlgorithm _alg;

        /// <summary>
        /// The method to run before each test.
        /// </summary>
        [TestInitialize]
        public void Initialize() => this._alg = new Fnv1a.Fnv1a64();

        /// <summary>
        /// The method to run after each test.
        /// </summary>
        [TestCleanup]
        public void Cleanup() => this.Dispose();

        /// <inheritdoc />
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() => this._alg.Dispose();

        /// <summary>
        /// Tests the empty string against the known vector result.
        /// </summary>
        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void TestVector1() => AreEqual(0xCBF29CE484222325, this.Fnv1a64(string.Empty));

        /// <summary>
        /// Tests the string "a" against the known vector result.
        /// </summary>
        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void TestVector2() => AreEqual(0xAF63DC4C8601EC8C, this.Fnv1a64("a"));

        /// <summary>
        /// Tests the string against the known vector result.
        /// </summary>
        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void TestVector3() => AreEqual(0x85944171F73967E8, this.Fnv1a64("foobar"));

        /// <summary>
        /// Computes the FNV-1a 64-bit hash for the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>The FNV-1a 64-bit hash of the specified data.</returns>
        // ReSharper disable once InconsistentNaming
        private ulong Fnv1a64(string data)
        {
            AreEqual(64, this._alg.HashSize);
            return (ulong)BitConverter.ToInt64(this._alg.ComputeHash(UTF8.GetBytes(data)), 0);
        }
    }
}
