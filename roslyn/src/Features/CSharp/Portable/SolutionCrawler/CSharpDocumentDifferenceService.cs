﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Composition;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.CodeAnalysis.SolutionCrawler;

namespace Microsoft.CodeAnalysis.CSharp.SolutionCrawler
{
    [ExportLanguageService(typeof(IDocumentDifferenceService), LanguageNames.CSharp), Shared]
    internal class CSharpDocumentDifferenceService : AbstractDocumentDifferenceService
    {
        [ImportingConstructor]
        [Obsolete(MefConstruction.ImportingConstructorMessage, error: true)]
        public CSharpDocumentDifferenceService()
        {
        }
    }
}