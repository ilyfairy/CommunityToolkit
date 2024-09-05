// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

global using CommunityToolkit.Mvvm.Poly;
using System.Runtime.CompilerServices;

namespace CommunityToolkit.Mvvm.Poly;

internal static unsafe class UnsafeCore
{
    public static bool IsNullRef<T>(ref T source)
    {
        return Unsafe.AreSame(ref source, ref Unsafe.AsRef<T>((void*)null));
    }
}