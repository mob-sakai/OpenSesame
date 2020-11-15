﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Runtime.InteropServices;
using Microsoft.CodeAnalysis.Editor.Shared.Options;

namespace Microsoft.VisualStudio.LanguageServices.Implementation.Options
{
    [Guid(Guids.RoslynOptionPageFeatureManagerComponentsIdString)]
    internal class InternalComponentsOnOffPage : AbstractOptionPage
    {
        protected override AbstractOptionPageControl CreateOptionPage(IServiceProvider serviceProvider, OptionStore optionStore)
        {
            return new InternalOptionsControl(nameof(EditorComponentOnOffOptions), optionStore);
        }
    }
}