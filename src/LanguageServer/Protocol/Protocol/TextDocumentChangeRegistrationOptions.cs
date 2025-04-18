﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Text.Json.Serialization;

namespace Roslyn.LanguageServer.Protocol;

/// <summary>
/// Class representing the registration options for didChange events.
/// <para>
/// See the <see href="https://microsoft.github.io/language-server-protocol/specifications/specification-current/#textDocumentChangeRegistrationOptions">Language Server Protocol specification</see> for additional information.
/// </para>
/// </summary>
internal sealed class TextDocumentChangeRegistrationOptions : TextDocumentRegistrationOptions
{
    /// <summary>
    /// How documents are synced to the server. See <see cref="TextDocumentSyncKind.Full"/>
    /// and <see cref="TextDocumentSyncKind.Incremental"/>.
    /// </summary>
    [JsonPropertyName("syncKind")]
    public TextDocumentSyncKind SyncKind
    {
        get;
        set;
    }
}
