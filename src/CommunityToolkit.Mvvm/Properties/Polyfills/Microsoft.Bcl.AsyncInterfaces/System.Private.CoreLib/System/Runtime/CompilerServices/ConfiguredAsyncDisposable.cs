// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#if NET45

using System.Runtime.InteropServices;

#pragma warning disable IDE0161
#pragma warning disable IDE0009

namespace System.Runtime.CompilerServices
{
    /// <summary>Provides a type that can be used to configure how awaits on an <see cref="IAsyncDisposable"/> are performed.</summary>
    [StructLayout(LayoutKind.Auto)]
    public readonly struct ConfiguredAsyncDisposable
    {
        private readonly IAsyncDisposable _source;
        private readonly bool _continueOnCapturedContext;

        internal ConfiguredAsyncDisposable(IAsyncDisposable source, bool continueOnCapturedContext)
        {
            _source = source;
            _continueOnCapturedContext = continueOnCapturedContext;
        }

        /// <summary>Asynchronously releases the unmanaged resources used by the <see cref="T:System.Runtime.CompilerServices.ConfiguredAsyncDisposable" />.</summary>
        /// <returns>A task that represents the asynchronous dispose operation.</returns>
        public ConfiguredValueTaskAwaitable DisposeAsync() =>
            // as with other "configured" awaitable-related type in CompilerServices, we don't null check to defend against
            // misuse like `default(ConfiguredAsyncDisposable).DisposeAsync()`, which will null ref by design.
            _source.DisposeAsync().ConfigureAwait(_continueOnCapturedContext);
    }
}

#endif
