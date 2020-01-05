﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Set0.cs" company="Always Elucidated Solution Pioneers, LLC">
//   Copyright © Always Elucidated Solution Pioneers, LLC 2017
// </copyright>
// <summary>
//   Provides an implementation for performing test vector set 0 generation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Fnv1aTestVectorGenerator
{
    using System.IO;
    using System.Threading.Tasks;

    /// <inheritdoc />
    /// <summary>
    /// Provides an implementation for performing test vector set 0 generation.
    /// </summary>
    /// <seealso cref="ISet" />
    internal sealed class Set0 : SetBase
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Fnv1aTestVectorGenerator.Set0" /> class.
        /// </summary>
        /// <param name="writer">The writer.</param>
        public Set0(TextWriter writer = null) : base(writer)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Performs the test vector set 0 generation.
        /// </summary>
        public override void Perform()
        {
            this.WriteLine(string.Empty.Test());
            this.WriteLine("a".Test());
            this.WriteLine("b".Test());
            this.WriteLine("c".Test());
            this.WriteLine("d".Test());
            this.WriteLine("e".Test());
            this.WriteLine("f".Test());
            this.WriteLine("fo".Test());
            this.WriteLine("foo".Test());
            this.WriteLine("foob".Test());
            this.WriteLine("fooba".Test());
            this.WriteLine("foobar".Test());
        }

        /// <inheritdoc />
        /// <summary>
        /// Asynchronously performs the test vector set 0 generation.
        /// </summary>
        /// <returns>An asynchronous <see cref="Task"/></returns>
        public override async Task PerformAsync()
        {
            await this.WriteLineAsync(await string.Empty.TestAsync().ConfigureAwait(false)).ConfigureAwait(false);
            await this.WriteLineAsync(await "a".TestAsync().ConfigureAwait(false)).ConfigureAwait(false);
            await this.WriteLineAsync(await "b".TestAsync().ConfigureAwait(false)).ConfigureAwait(false);
            await this.WriteLineAsync(await "c".TestAsync().ConfigureAwait(false)).ConfigureAwait(false);
            await this.WriteLineAsync(await "d".TestAsync().ConfigureAwait(false)).ConfigureAwait(false);
            await this.WriteLineAsync(await "e".TestAsync().ConfigureAwait(false)).ConfigureAwait(false);
            await this.WriteLineAsync(await "f".TestAsync().ConfigureAwait(false)).ConfigureAwait(false);
            await this.WriteLineAsync(await "fo".TestAsync().ConfigureAwait(false)).ConfigureAwait(false);
            await this.WriteLineAsync(await "foo".TestAsync().ConfigureAwait(false)).ConfigureAwait(false);
            await this.WriteLineAsync(await "foob".TestAsync().ConfigureAwait(false)).ConfigureAwait(false);
            await this.WriteLineAsync(await "fooba".TestAsync().ConfigureAwait(false)).ConfigureAwait(false);
            await this.WriteLineAsync(await "foobar".TestAsync().ConfigureAwait(false)).ConfigureAwait(false);
        }
    }
}
