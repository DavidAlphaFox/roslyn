﻿' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.

Imports System.Composition
Imports System.Threading
Imports Microsoft.CodeAnalysis.Highlighting
Imports Microsoft.CodeAnalysis.Host.Mef
Imports Microsoft.CodeAnalysis.Text
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax

Namespace Microsoft.CodeAnalysis.VisualBasic.KeywordHighlighting
    <ExportHighlighter(LanguageNames.VisualBasic), [Shared]>
    Friend Class ConstructorDeclarationHighlighter
        Inherits AbstractKeywordHighlighter(Of SyntaxNode)

        <ImportingConstructor>
        <Obsolete(MefConstruction.ImportingConstructorMessage, True)>
        Public Sub New()
        End Sub

        Protected Overloads Overrides Sub AddHighlights(node As SyntaxNode, highlights As List(Of TextSpan), cancellationToken As CancellationToken)
            Dim methodBlock = node.GetAncestor(Of MethodBlockBaseSyntax)()
            If methodBlock Is Nothing OrElse TypeOf methodBlock.BlockStatement IsNot SubNewStatementSyntax Then
                Return
            End If

            With methodBlock
                With DirectCast(.BlockStatement, SubNewStatementSyntax)
                    Dim firstKeyword = If(.Modifiers.Count > 0, .Modifiers.First(), .DeclarationKeyword)
                    highlights.Add(TextSpan.FromBounds(firstKeyword.SpanStart, .NewKeyword.Span.End))
                End With

                highlights.AddRange(
                    methodBlock.GetRelatedStatementHighlights(
                        blockKind:=SyntaxKind.SubKeyword,
                        checkReturns:=True))

                highlights.Add(.EndBlockStatement.Span)
            End With
        End Sub
    End Class
End Namespace
