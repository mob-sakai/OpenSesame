﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Microsoft.CodeAnalysis.GenerateType
{
    internal class GenerateTypeOptionsResult
    {
        public static readonly GenerateTypeOptionsResult Cancelled = new GenerateTypeOptionsResult(isCancelled: true);

        public Accessibility Accessibility { get; }
        public Document ExistingDocument { get; }
        public bool IsCancelled { get; }
        public bool IsNewFile { get; }
        public IList<string> Folders { get; }
        public string NewFileName { get; }
        public Project Project { get; }
        public TypeKind TypeKind { get; }
        public string FullFilePath { get; }
        public string TypeName { get; }
        public string DefaultNamespace { get; }
        public bool AreFoldersValidIdentifiers { get; }

        public GenerateTypeOptionsResult(
            Accessibility accessibility,
            TypeKind typeKind,
            string typeName,
            Project project,
            bool isNewFile,
            string newFileName,
            IList<string> folders,
            string fullFilePath,
            Document existingDocument,
            bool areFoldersValidIdentifiers,
            string defaultNamespace,
            bool isCancelled = false)
        {
            Accessibility = accessibility;
            TypeKind = typeKind;
            TypeName = typeName;
            Project = project;
            IsNewFile = isNewFile;
            NewFileName = newFileName;
            Folders = folders;
            FullFilePath = fullFilePath;
            ExistingDocument = existingDocument;
            AreFoldersValidIdentifiers = areFoldersValidIdentifiers;
            DefaultNamespace = defaultNamespace;
            IsCancelled = isCancelled;
        }

        private GenerateTypeOptionsResult(bool isCancelled)
        {
            IsCancelled = isCancelled;
        }
    }
}