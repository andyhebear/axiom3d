#region LGPL License

/*
Axiom Graphics Engine Library
Copyright (C) 2003-2010 Axiom Project Team
This file is part of Axiom.RenderSystems.OpenGLES
C# version developed by bostich.

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

#endregion LGPL License

#region SVN Version Information

// <file>
//     <license see="http://axiomengine.sf.net/wiki/index.php/license.txt"/>
//     <id value="$Id: GLESDefaultHardwareIndexBuffer.cs 3412 2012-12-13 19:35:47Z borrillis $"/>
// </file>

#endregion SVN Version Information

#region Namespace Declarations

using System;

using Axiom.Core;
using Axiom.Graphics;
using Axiom.Utilities;

#endregion Namespace Declarations

namespace Axiom.RenderSystems.OpenGLES
{
	/// <summary>
	/// </summary>
	public class GLESDefaultHardwareIndexBuffer : HardwareIndexBuffer
	{
		protected byte[] _data;
		protected BufferBase _dataPtr;
		
		/// <summary>
		/// </summary>
		/// <param name="idxType"> </param>
		/// <param name="numIndexes"> </param>
		/// <param name="usage"> </param>
		public GLESDefaultHardwareIndexBuffer( IndexType idxType, int numIndexes, BufferUsage usage )
			: base( null, idxType, numIndexes, usage, true, false ) // always software, never shadowed
		{
			if ( idxType == IndexType.Size32 )
			{
				throw new AxiomException( "32 bit hardware buffers are not allowed in OpenGL ES." );
			}
			
			this._data = new byte[ sizeInBytes ];
			this._dataPtr = BufferBase.Wrap( this._data );
		}
		
		/// <summary>
		/// </summary>
		/// <param name="offset"> </param>
		/// <param name="length"> </param>
		/// <param name="locking"> </param>
		/// <returns> </returns>
		protected override BufferBase LockImpl( int offset, int length, BufferLocking locking )
		{
			// Only for use internally, no 'locking' as such
			return this._dataPtr + offset;
		}
		
		/// <summary>
		/// </summary>
		protected override void UnlockImpl()
		{
			// Nothing to do
		}
		
		/// <summary>
		/// </summary>
		/// <param name="offset"> </param>
		/// <param name="length"> </param>
		/// <param name="locking"> </param>
		/// <returns> </returns>
		public override BufferBase Lock( int offset, int length, BufferLocking locking )
		{
			isLocked = true;
			return this._dataPtr + offset;
		}
		
		/// <summary>
		/// </summary>
		public override void Unlock()
		{
			isLocked = false;
			// Nothing to do
		}
		
		/// <summary>
		/// </summary>
		/// <param name="offset"> </param>
		/// <param name="length"> </param>
		/// <param name="dest"> </param>
		public override void ReadData( int offset, int length, BufferBase dest )
		{
			Contract.Requires( ( offset + length ) <= sizeInBytes );
			
			Memory.Copy( this._dataPtr + offset, dest, length );
		}
		
		/// <summary>
		/// </summary>
		/// <param name="offset"> </param>
		/// <param name="length"> </param>
		/// <param name="src"> </param>
		/// <param name="discardWholeBuffer"> </param>
		public override void WriteData( int offset, int length, BufferBase src, bool discardWholeBuffer )
		{
			Contract.Requires( ( offset + length ) <= sizeInBytes );
			// ignore discard, memory is not guaranteed to be zeroised
			Memory.Copy( src, this._dataPtr + offset, length );
		}
		
		/// <summary>
		/// </summary>
		/// <param name="disposeManagedResources"> </param>
		protected override void dispose( bool disposeManagedResources )
		{
			if ( !IsDisposed )
			{
				if ( disposeManagedResources )
				{
					if ( this._data != null )
					{
						this._dataPtr.SafeDispose();
						this._data = null;
					}
				}
			}
			
			// If it is available, make the call to the
			// base class's Dispose(Boolean) method
			base.dispose( disposeManagedResources );
		}
	}
}
