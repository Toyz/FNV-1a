﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Fnv1a32Tests.cs" company="Always Elucidated Solution Pioneers, LLC">
//   Copyright © Always Elucidated Solution Pioneers, LLC 2014
// </copyright>
// <summary>
//   Tests the FNV-1a 32-bit algorithm.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Fnv1aTests
{
    using System;
    using System.Security.Cryptography;

    using Fnv1a;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static System.Text.Encoding;

    using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

    /// <summary>
    /// Tests the FNV-1a 32-bit algorithm.
    /// </summary>
    [TestClass]
    // ReSharper disable once InconsistentNaming
    public sealed class Fnv1a32Tests
    {
        /// <summary>
        /// Tests the empty string against the known vector result.
        /// </summary>
        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void TestVector1()
        {
            AreEqual(0x811c9dc5, Fnv1a32(string.Empty));
        }

        /// <summary>
        /// Tests the string "a" against the known vector result.
        /// </summary>
        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void TestVector2()
        {
            AreEqual(0xe40c292c, Fnv1a32("a"));
        }

        /// <summary>
        /// Tests the string against the known vector result.
        /// </summary>
        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void TestVector3()
        {
            AreEqual(0xbf9cf968, Fnv1a32("foobar"));
        }

        /// <summary>
        /// Computes the FNV-1a 32-bit hash for the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>The FNV-1a 32-bit hash of the specified data.</returns>
        // ReSharper disable once InconsistentNaming
        private static uint Fnv1a32(string data)
        {
            using (HashAlgorithm alg = new Fnv1a32())
            {
                AreEqual(32, alg.HashSize);
                return (uint)BitConverter.ToInt32(alg.ComputeHash(UTF8.GetBytes(data)), 0);
            }
        }
    }
}
