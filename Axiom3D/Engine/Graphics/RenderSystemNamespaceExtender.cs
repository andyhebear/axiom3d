#region LGPL License
/*
Axiom Graphics Engine Library
Copyright (C) 2003-2006  Axiom Project Team

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
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <id value="$Id$"/>
// </file>
#endregion SVN Version Information

#region Namespace Declarations

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

#endregion Namespace Declarations
			
namespace Axiom
{
    /// <summary>
    /// Extends Axiom VFS /Axiom/RenderSystems/ namespace that allows to
    /// query for registered render systems
    /// </summary>
    public class RenderSystemNamespaceExtender : INamespaceExtender
    {
        /// <summary>
        /// RenderSystem collection
        /// </summary>
        protected RenderSystemCollection renderSystems =
            new RenderSystemCollection();

        /// <summary>
        /// Registers a new render system with Axiom
        /// </summary>
        /// <param name="renderSystem"></param>
        public void RegisterRenderSystem(string name, RenderSystem renderSystem)
        {
            renderSystems.Add(name, renderSystem);
        }

        #region INamespaceExtender implementation

        public IEnumerable<K> Subtree<K>()
        {
            if (typeof(K) != typeof(RenderSystem) &&
                !typeof(K).IsSubclassOf(typeof(RenderSystem)))
                throw new ArgumentOutOfRangeException("RenderSystemNamespaceExtender supports only RenderSystem descendants");

            IEnumerator enu = renderSystems.Values.GetEnumerator();

            while (enu.MoveNext())
            {
                yield return (K)(enu.Current);
            }
        }

        const string
            NAMESPACE_NAME = "/Axiom/RenderSystems/";

        public string Namespace
        {
            get
            {
                return NAMESPACE_NAME;
            }
        }

        public K GetObject<K>(string objectName)
        {
            if (typeof(K) != typeof(RenderSystem) &&
            !typeof(K).IsSubclassOf(typeof(RenderSystem)))
                throw new ArgumentOutOfRangeException("RenderSystemNamespaceExtender supports only RenderSystem descendants");

            return (K)((object)renderSystems[objectName]);
        }

        #endregion
    }
}