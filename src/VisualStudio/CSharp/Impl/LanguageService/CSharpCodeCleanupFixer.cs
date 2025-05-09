﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.ComponentModel.Composition;
using Microsoft.CodeAnalysis.Editor;
using Microsoft.CodeAnalysis.Editor.Shared.Utilities;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.VisualStudio.LanguageServices.Implementation.CodeCleanup;
using Microsoft.VisualStudio.LanguageServices.Implementation.ProjectSystem;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Utilities;

namespace Microsoft.VisualStudio.LanguageServices.CSharp.LanguageService;

[Export(typeof(AbstractCodeCleanUpFixer))]
[ContentType(ContentTypeNames.CSharpContentType)]
[method: ImportingConstructor]
[method: Obsolete(MefConstruction.ImportingConstructorMessage, error: true)]
internal sealed class CSharpCodeCleanUpFixer(
    IThreadingContext threadingContext,
    VisualStudioWorkspaceImpl workspace,
    IVsHierarchyItemManager vsHierarchyItemManager)
    : AbstractCodeCleanUpFixer(threadingContext, workspace, vsHierarchyItemManager);
