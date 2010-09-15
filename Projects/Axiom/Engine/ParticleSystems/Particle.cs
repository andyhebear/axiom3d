#region LGPL License
/*
Axiom Graphics Engine Library
Copyright (C) 2003-2010 Axiom Project Team

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
//     <license see="http://axiom3d.net/wiki/index.php/license.txt"/>
//     <id value="$Id$"/>
// </file>
#endregion SVN Version Information

#region Namespace Declarations

using System;

using Axiom.Core;
using Axiom.Math;

#endregion Namespace Declarations

namespace Axiom.ParticleSystems
{
	public enum ParticleType
	{
		Emitter,
		Visual
	}

	/// <summary>
	///		Class representing a single particle instance.
	/// </summary>
	public class Particle
	{

		#region Member variables

		/// Does this particle have it's own dimensions?
		public bool hasOwnDimensions;
		/// Personal width if mOwnDimensions == true
		public float width;
		/// Personal height if mOwnDimensions == true
		public float height;
		/// Current rotation value
		public float rotationInRadians;
		// Note the intentional public access to internal variables
		// Accessing via get/set would be too costly for 000's of particles
		/// World position
		public Vector3 Position = Vector3.Zero;
		/// Direction (and speed) 
		public Vector3 Direction = Vector3.Zero;
		/// Current colour
		public ColorEx Color = ColorEx.White;

		/// <summary>Time (in seconds) before this particle is destroyed.</summary>
		public float timeToLive;
		/// <summary>Total Time to live, number of seconds of particles natural life</summary>
		public float totalTimeToLive;
		/// <summary>Speed of rotation in radians</summary>
		float rotationSpeed;

		/// Parent ParticleSystem
		protected ParticleSystem parentSystem;
		/// Additional visual data you might want to associate with the Particle
		protected ParticleVisualData visual;

		protected ParticleType particleType = ParticleType.Visual;

		#endregion

		#region Properties

		public float RotationSpeed
		{
			get
			{
				return rotationSpeed;
			}
			set
			{
				rotationSpeed = value;
			}
		}

		public ParticleType ParticleType
		{
			get
			{
				return particleType;
			}
			set
			{
				particleType = value;
			}
		}
		#endregion

		/// <summary>
		///		Default constructor.
		/// </summary>
		public Particle()
		{
			timeToLive = 10;
			totalTimeToLive = 10;
			rotationSpeed = 0;
		}


		public void NotifyVisualData( ParticleVisualData vdata )
		{
			visual = vdata;
		}

		public void NotifyOwner( ParticleSystem owner )
		{
			this.parentSystem = owner;
		}

		public void SetDimensions( float width, float height )
		{
			hasOwnDimensions = true;
			this.width = width;
			this.height = height;
			parentSystem.NotifyParticleResized();
		}

		public void ResetDimensions()
		{
			hasOwnDimensions = false;
		}

		public bool HasOwnDimensions
		{
			get
			{
				return hasOwnDimensions;
			}
			set
			{
				hasOwnDimensions = value;
			}
		}

		public float Rotation
		{
			get
			{
				return rotationInRadians * Utility.DEGREES_PER_RADIAN;
			}
			set
			{
				rotationInRadians = value * Utility.RADIANS_PER_DEGREE;
				if ( rotationInRadians != 0 )
					parentSystem.NotifyParticleRotated();
			}
		}

		public float Width
		{
			get
			{
				return width;
			}
			set
			{
				width = value;
			}
		}

		public float Height
		{
			get
			{
				return height;
			}
			set
			{
				height = value;
			}
		}

		public ParticleVisualData VisualData
		{
			get
			{
				return visual;
			}
		}
	}
}
