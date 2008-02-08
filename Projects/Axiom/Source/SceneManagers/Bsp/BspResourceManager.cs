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
using Axiom.Collections;

using ResourceHandle = System.UInt64;
using System.IO;

#endregion Namespace Declarations

namespace Axiom.SceneManagers.Bsp
{
    /// <summary>
    ///		Manages the locating and loading of BSP-based indoor levels.
    /// </summary>
    /// <remarks>
    ///		Like other ResourceManager specialisations it manages the location and loading
    ///		of a specific type of resource, in this case files containing Binary
    ///		Space Partition (BSP) based level files e.g. Quake3 levels.</p>
    ///		However, note that unlike other ResourceManager implementations,
    ///		only 1 BspLevel resource is allowed to be loaded at one time. Loading
    ///		another automatically unloads the currently loaded level if any.
    /// </remarks>
    public class BspResourceManager : ResourceManager, ISingleton<BspResourceManager>
    {
        #region Fields and Properties

        protected Quake3ShaderManager shaderManager;

        #endregion Fields and Properties

        #region Methods

        /// <summary>
        ///		Loads a BSP-based level from the named file.  Currently only supports loading of Quake3 .bsp files.
        /// </summary>
        public BspLevel Load( Stream stream, string group )
        {
            RemoveAll();

            BspLevel bsp = (BspLevel)Create( "bsplevel", ResourceGroupManager.Instance.WorldResourceGroupName, true, null, null );
            bsp.Load( stream );

            return bsp;
        }

        #endregion

        #region ISingleton<BspResourceManager> Implementation

        protected static BspResourceManager instance;

        public static BspResourceManager Instance
        {
            get
            {
                return instance;
            }
        }

        static BspResourceManager()
        {
            instance = new BspResourceManager();
        }

        protected BspResourceManager()
        {
            ResourceType = "BspLevel";
            shaderManager = Quake3ShaderManager.Instance;
            ResourceGroupManager.Instance.RegisterResourceManager( ResourceType, this );
        }

        public bool Initialize( params object[] args )
        {
            return true;
        }

        protected override void dispose( bool disposeManagedResources )
        {
            if ( !isDisposed )
            {
                if ( disposeManagedResources )
                {
                    // Dispose managed resources.
                    shaderManager.Dispose();
                    ResourceGroupManager.Instance.UnregisterResourceManager( "BspLevel" );
                }

                // There are no unmanaged resources to release, but
                // if we add them, they need to be released here.
            }
            isDisposed = true;

            // If it is available, make the call to the
            // base class's Dispose(Boolean) method
            base.dispose( disposeManagedResources );
        }

        #endregion ISingleton<BspResourceManager> Implementation

        #region ResourceManager Implementation

        public override Resource Load( string name, string group, bool isManual, IManualResourceLoader loader, NameValuePairList loadParams )
        {
            RemoveAll(); // Only one level at a time.

            return base.Load( name, group, isManual, loader, loadParams );
        }


        /// <summary>
        ///		Creates a BspLevel resource - mainly used internally.
        /// </summary>
        protected override Resource _create( string name, ResourceHandle handle, string group, bool isManual, IManualResourceLoader loader, NameValuePairList createParams )
        {
            return new BspLevel( this, name, handle, group, isManual, loader );
        }

        #endregion ResourceMAnager Implementation
    }
}