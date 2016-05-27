#region MIT/X11 License

//Copyright � 2003-2012 Axiom 3D Rendering Engine Project
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in
//all copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//THE SOFTWARE.

#endregion License

#region SVN Version Information

// <file>
//     <license see="http://axiom3d.net/wiki/index.php/license.txt"/>
//     <id value="$Id: GLES2Config.cs 3410 2012-12-13 19:35:14Z borrillis $"/>
// </file>

#endregion SVN Version Information

#region Namespace Declarations

using System;

using Axiom.Core;

using OpenGL = OpenTK.Graphics.ES20.GL;

using Axiom.Core;

#endregion Namespace Declarations

namespace Axiom.RenderSystems.OpenGLES2
{
	public static class GLES2Config
	{
#if NET_40
		public static void GlCheckError( object caller, bool raiseException = true )
#else
		public static void GlCheckError( object caller, bool raiseException )
#endif
		{
			var e = OpenGL.GetError();
			if ( e != OpenTK.Graphics.ES20.All.None )
			{
				var msg = string.Format( "[GLES2] Error {0}: {1} from {2}", (int)e, e, caller.ToString() );
				LogManager.Instance.Write( msg );
				if ( raiseException )
					throw new AxiomException( msg );
			}
		}

#if !NET_40
		public static void GlCheckError( object caller )
		{
			GlCheckError( caller, true );
		}
#endif
		internal static void GlClearError()
		{
			var e = (int)OpenGL.GetError();
			if ( e != 0 )
			{
				LogManager.Instance.Write( string.Format( "[GLES2] Ignoring error {0} on stack.", e ) );
			}
		}
	}
}
