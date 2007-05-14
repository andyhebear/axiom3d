#region LGPL License
/*
Axiom Graphics Engine Library
Copyright (C) 2003-2006 Axiom Project Team

The overall design, and a majority of the core engine and rendering code 
contained within this library is a derivative of the open source Object Oriented 
Graphics Engine OGRE, which can be found at http://ogre.sourceforge.net.  
Many thanks to the OGRE team for maintaining such a high quality project.

This library is free software; you can redistribute it and/or
modify it under the terms of the GNU Lesser General Public
License as published by the Free Software Foundation; either
version 2.1 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public
License along with this library; if not, write to the Free Software
Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
*/
#endregion

#region SVN Version Information
// <file>
//     <license see="http://axiomengine.sf.net/wiki/index.php/license.txt"/>
//     <id value="$Id$"/>
// </file>
#endregion SVN Version Information

#region Namespace Declarations

using System;

using Axiom.Core;
using Axiom.Media;

#endregion Namespace Declarations

namespace Axiom.Graphics
{
	/// <summary>
	///    Custom RenderTarget that allows for rendering a scene to a texture.
	/// </summary>
	public abstract class RenderTexture : RenderTarget
	{
		#region Fields

		protected HardwarePixelBuffer pixelBuffer;
		protected int zOffset = 0;

		public PixelFormat Format
		{
			get
			{
				return pixelBuffer.Format;
			}
		}

		#endregion Fields

		#region Constructors

		public RenderTexture( HardwarePixelBuffer buffer, int zOffset )
		{
			pixelBuffer = buffer;
			this.zOffset = zOffset;
			Priority = RenderTargetPriority.High;
			Width = buffer.Width;
			Height = buffer.Height;
			ColorDepth = PixelUtil.GetNumElemBits( buffer.Format );
		}

		#endregion Constructors

		#region Methods

		public override void Save( System.IO.Stream stream )
		{
			// TODO Implement RenderTexture.Save( System.IO.Stream )
			throw new Exception( "The method or operation is not implemented." );
		}

		/// <summary>
		/// Ensures texture is destroyed.
		/// </summary>
		protected override void dispose( bool disposeManagedResources )
		{
			if ( !isDisposed )
			{
				if ( disposeManagedResources )
				{
					pixelBuffer.ClearSliceRTT( 0 );
				}
			}
			isDisposed = true;

			// If it is available, make the call to the
			// base class's Dispose(Boolean) method
			base.dispose( disposeManagedResources );
		}

		#endregion Methods
	}
}