﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.LanguageServer;
using Roslyn.LanguageServer.Protocol;

namespace Microsoft.CodeAnalysis.ExternalAccess.Razor.Features;

internal static class WorkspaceExtensions
{
    public static ValueTask<TextDocument?> GetTextDocumentAsync(this Workspace workspace, Uri uri, CancellationToken cancellationToken)
    {
        var identifier = new TextDocumentIdentifier() { Uri = uri };
        return workspace.CurrentSolution.GetTextDocumentAsync(identifier, cancellationToken);
    }
}
