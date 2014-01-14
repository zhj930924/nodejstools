﻿/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. 
 *
 * This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the Apache License, Version 2.0, please send an email to 
 * vspython@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Apache License, Version 2.0.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * ***************************************************************************/

#if DEV12_OR_LATER
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.BraceCompletion;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;

namespace Microsoft.NodejsTools.Repl {
    /// <summary>
    /// Brace matching session provider which takes precedence over the JavaScript
    /// brace matching implementation.  This is used for the REPL window to shut down
    /// brace completion which results in exceptions.
    /// 
    /// https://nodejstools.codeplex.com/workitem/513
    /// </summary>
    [Export(typeof(IBraceCompletionSessionProvider))]
    [ContentType(NodejsConstants.NodejsRepl)]

    [BracePair('[', ']')]
    [BracePair('(', ')')]
    [BracePair('{', '}')]
    [BracePair('\'', '\'')]
    [BracePair('"', '"')]
    class ReplBraceCompletionSessionProvider : IBraceCompletionSessionProvider {
        public bool TryCreateSession(ITextView textView, SnapshotPoint openingPoint, char openingBrace, char closingBrace, out IBraceCompletionSession session) {
            session = null;
            return false;
        }
    }
}
#endif
