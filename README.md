# axiom3d
Project Description
 The Axiom Engine is an Open-source, cross-platform 3D rendering engine for .NET and Mono licensed using the LGPL. The engine is a high-performance C# port of the powerful OGRE engine and provides full support for DirectX, OpenGL and XNA on Windows, Linux, Android, iPhone and Windows Phone.

General Features Object-Oriented Design, Plug-in Architecture, Other:
C# codebase built using Visual Studio .NET 2010 running on .Net Framework 2.0, 3.5 and 4.0. Project files for VS 2008, 2010, and MonoDevelop are included. 
Game agnostic design, allowing the flexibility for use in a variety of game genres or visualization applications. 
Strict adherence to the best practices of .NET framework naming standards and methodologies (i.e. Use of properties instead of GetX()/SetX(). Usage of .NET framework class library wherever possible. No Hungarian notation, other than the "I" prefix for interfaces. 
Flexible plugin architecture for dynamically loading plugin functionality at runtime. 
Runs under Mono/Linux 
Comprehensive C# Math Library, with support for Quaternions, as well as various sizes of Matrices, and Vectors. Operator overloads are implemented as well (not CLS compliant yet however). Math code has been ported over from C++ and has been hand optimized to perform as best as the CLR will allow. 
Automatic resource management, for maintaining memory quotas. Supports flexible archive implementation, including folder structures and .zip files using SharpZipLib. 
Built in logging support via a log writer that implements TraceListener. All messages are written using Trace.Write. 


Lighting Per-vertex:
Shadows Shadow Volume:
Texturing Basic, Multi-texturing, Bumpmapping, Mipmapping, Volumetric, Projected:
Support for a variety of image formats, including .png, .jpg, .gif, .tga, with dynamic MipMap generation. .dds files are supported for 2D, Volume, and Cubic textures in both DirextX AND OpenGL via DevIL. 
1D, 2D, Cubic, and Volume textures. 

Shaders Vertex, Pixel, High Level:
Vertex/Fragment programs, including Cg and HLSL high level plugins, as well as support for loading ASM shaders 
Vertex/Fragment programs are also fully configurable in the material files, and allow for parameters that instruct the engine to track various states and supply them automatically to the program parameters, such as worldviewprojmatrix, lightpositionobjectspace, camerapositionobject_space, etc. 
Support profiles at present are: * DirectX 8 - vp11, ps11 - ps14 * DirectX 9 - vp20, ps20 * OpenGL - arbvp1, arbfp1, fp20 (GeForce3/4 Register and Texture Combiners supported via nvparse), vp30/fp30 (GeForceFX). 

Scene Management General, BSP, Octrees, LOD:
Extensible Hierarchical Scene Graph 
Octree scene manager plugin which includes a basic heightmap loading scene manager 

Animation Keyframe Animation, Skeletal Animation:
Skeletal animation with an Ogre .skeleton file loader. Features include multiple bone assignments per vertex, smooth frame rate scaled blending, and multiple animations can be blended together to allow for seamless animation transitions. 
Pose animation allowing for facial animations and more. 
Allows animations to be assigned to nodes in the scene graph, allowing objects to move along predefined spline paths. 

Meshes Mesh Loading, Skinning, Progressive:
Fast Mesh loader support the Ogre .mesh file formats 1.10 and 1.20, now including pre generated LOD levels based on the entitie's distance from the camera. 
Exporters for various 3D Modeling programs, including Milkshape and 3dx Max can be downloaded from the Ogre downloads page 

Special Effects Environment Mapping, Billboarding, Particle System, Sky, Fog, Mirror:
Spherical environment mapping 
Particle systems, extendable via plugins for defining new Emitters and Affectors and definable through Ogre particle scripts. 
Support for skyboxes via cubic textures, and sky planes. 
2d billboard support, with built in pooling to reduce runtime overhead. Supports sprites, and is also used for the particle system. 
Post-process compositor effects for HDR, Bloom, Motion Blur etc. 

Rendering Fixed-function, Render-to-Texture, Fonts, GUI:
Extensible render system support, via plugins. Current implementations include Tao for OpenGL, and Managed DirectX 9, Xna is under development. 
Virtual hardware vertex/index buffer interface, allowing for faster rendering of primitives by placing geometry data in video AGP memory, eliminating the need for keeping it in application memory and copying it over every frame. 
Support for Ogre .material files, allowing the flexibility for controlling fixed function render state on a per object basis, in addition to specifying texture blending and texture effects such as scrolling and rotating. 
Smart rendering pipeline, with sorting designed to reduce render state changes as much as possible. Transparent objects are also sorted to allow blending into the scene correctly. 
Font bitmap support using the Ogre .fontdef format for loading bitmaps based and dynamically generated font bitmaps. 

