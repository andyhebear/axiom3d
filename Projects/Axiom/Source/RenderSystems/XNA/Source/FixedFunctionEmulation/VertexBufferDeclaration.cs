﻿#region LGPL License
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
using System.Collections.Generic;

using Axiom.Graphics;
using Axiom.RenderSystems.Xna.HLSL;

using XNA = Microsoft.Xna.Framework;
using XFG = Microsoft.Xna.Framework.Graphics;

#endregion Namespace Declarations

namespace Axiom.RenderSystems.Xna.FixedFunctionEmulation
{
	class VertexBufferDeclaration : IComparable<VertexBufferDeclaration>
	{
		#region Fields and Properties

		protected List<VertexBufferElement> vertexBufferElements;
		public IEnumerable<VertexBufferElement> VertexBufferElements
		{
			get
			{
				return vertexBufferElements;
			}
			set
			{
				vertexBufferElements = (List<VertexBufferElement>)value;
			}
		}

		public bool HasColor
		{
			get
			{
				return ( GetVertexElementSemanticCount( VertexElementSemantic.Diffuse ) > 0 );
			}
		}

		public bool HasTexCoord
		{
			get
			{
				return ( GetVertexElementSemanticCount( VertexElementSemantic.TexCoords ) > 0 );
			}
		}

		public ushort TexCoordCount
		{
			get
			{
				return GetVertexElementSemanticCount( VertexElementSemantic.TexCoords );
			}
		}

		#endregion Fields and Properties

		#region Methods

		public ushort GetVertexElementSemanticCount( VertexElementSemantic semantic )
		{
			ushort count = 0;
			foreach ( VertexBufferElement vbe in vertexBufferElements )
			{
				if ( vbe.VertexElementSemantic == semantic )
				{
					count++;
				}
			}
			return count;
		}

		#endregion Methods

		#region IComparable<VertexBufferDeclaration> Implementation

		public int CompareTo( VertexBufferDeclaration other )
		{
			throw new NotImplementedException();
		}

		#endregion IComparable<VertexBufferDeclaration> Implementation
	}
}