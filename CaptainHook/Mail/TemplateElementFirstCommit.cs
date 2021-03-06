// 
//  Authors:
//    Marek Habersack grendel@twistedcode.net
// 
//  Copyright (c) 2010, Novell, Inc (http://novell.com/)
// 
//  All rights reserved.
// 
//  Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in
//       the documentation and/or other materials provided with the distribution.
//     * Neither the name of Novell, Inc nor names of the contributors may be used to endorse or promote products derived from this software without specific prior written permission.
// 
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
//  "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
//  LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
//  A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
//  CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
//  EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
//  PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
//  PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
//  LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
//  NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
//  SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// 
using System;
using System.Collections.Generic;

using CaptainHook.GitHub;

namespace CaptainHook.Mail
{
	public class TemplateElementFirstCommit : TemplateElement
	{
		string basePath;
		string commitSourceID;
		
		public TemplateElementFirstCommit (string basePath, string commitSourceID)
		{
			if (String.IsNullOrEmpty (basePath))
				throw new ArgumentNullException ("basePath");

			if (String.IsNullOrEmpty (commitSourceID))
				throw new ArgumentNullException ("commitSourceID");
			
			this.basePath = basePath;
			this.commitSourceID = commitSourceID;
		}
		
		public override string Generate (object data)
		{
			var list = data as List <Commit>;
			if (list == null)
				throw new ArgumentException ("must represent an instance of List <Commit>", "data");

			if (list.Count == 0)
				return String.Empty;
			
			var template = new Template <Commit> (basePath, commitSourceID);
			return template.ComposeMailBody (list [0]);
		}
	}
}
