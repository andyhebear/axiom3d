﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Axiom.Graphics
{
    partial class GpuProgramParameters
    {
        /// <summary>
        /// Information about predefined program constants.
        /// </summary>
        /// <note>
        /// Only available for high-level programs but is referenced generically
        /// by GpuProgramParameters.
        /// </note>
        public class GpuConstantDefinition
        {
            /// <summary>
            /// Data type.
            /// </summary>
            public GpuConstantType ConstantType;

            /// <summary>
            /// Physical start index in buffer (either float or int buffer)
            /// </summary>
            public int PhysicalIndex;

            /// <summary>
            /// Logical index - used to communicate this constant to the rendersystem
            /// </summary>
            public int LogicalIndex;

            /// <summary>
            /// Number of raw buffer slots per element
            /// (some programs pack each array element to float4, some do not)
            /// </summary>
            public int ElementSize;

            /// <summary>
            /// Length of array
            /// </summary>
            public int ArraySize;

            /// <summary>
            /// How this parameter varies (bitwise combination of GpuParamVariability)
            /// </summary>
            public GpuParamVariability Variability;

            /// <summary>
            /// 
            /// </summary>
            public bool IsFloat
            {
                get
                {
                    return IsFloatConst( ConstantType );
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public bool IsSampler
            {
                get
                {
                    return IsSamplerConst( ConstantType );
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public GpuConstantDefinition()
            {
                ConstantType = GpuConstantType.Unknown;
                PhysicalIndex = int.MaxValue;
                ElementSize = 0;
                ArraySize = 1;
                Variability = GpuParamVariability.Global;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="c"></param>
            /// <returns></returns>
            public static bool IsFloatConst( GpuConstantType c )
            {
                switch ( c )
                {
                    case GpuConstantType.Int1:
                    case GpuConstantType.Int2:
                    case GpuConstantType.Int3:
                    case GpuConstantType.Int4:
                    case GpuConstantType.Sampler1D:
                    case GpuConstantType.Sampler2D:
                    case GpuConstantType.Sampler3D:
                    case GpuConstantType.SamplerCube:
                    case GpuConstantType.Sampler1DShadow:
                    case GpuConstantType.Sampler2DShadow:
                        return false;
                    default:
                        return true;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="c"></param>
            /// <returns></returns>
            public bool IsSamplerConst( GpuConstantType c )
            {
                switch ( c )
                {
                    case GpuConstantType.Sampler1D:
                    case GpuConstantType.Sampler2D:
                    case GpuConstantType.Sampler3D:
                    case GpuConstantType.SamplerCube:
                    case GpuConstantType.Sampler1DShadow:
                    case GpuConstantType.Sampler2DShadow:
                        return true;
                    default:
                        return false;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="ctype"></param>
            /// <param name="padToMultiplesOf4"></param>
            /// <returns></returns>
            public static int GetElementSize( GpuConstantType ctype, bool padToMultiplesOf4 )
            {
                if ( padToMultiplesOf4 )
                {
                    switch ( ctype )
                    {
                        case GpuConstantType.Float1:
                        case GpuConstantType.Float2:
                        case GpuConstantType.Float3:
                        case GpuConstantType.Float4:
                        case GpuConstantType.Int1:
                        case GpuConstantType.Int2:
                        case GpuConstantType.Int3:
                        case GpuConstantType.Int4:
                        case GpuConstantType.Sampler1D:
                        case GpuConstantType.Sampler2D:
                        case GpuConstantType.Sampler3D:
                        case GpuConstantType.Sampler1DShadow:
                        case GpuConstantType.Sampler2DShadow:
                        case GpuConstantType.SamplerCube:
                            return 4;
                        case GpuConstantType.Matrix_2X2:
                        case GpuConstantType.Matrix_2X3:
                        case GpuConstantType.Matrix_2X4:
                            return 8; // 2 float4s
                        case GpuConstantType.Matrix_3X2:
                        case GpuConstantType.Matrix_3X3:
                        case GpuConstantType.Matrix_3X4:
                            return 12; //3 float4s
                        case GpuConstantType.Matrix_4X2:
                        case GpuConstantType.Matrix_4X3:
                        case GpuConstantType.Matrix_4X4:
                            return 16; //4 float4s
                        default:
                            return 4;
                    }
                }
                else
                {
                    switch ( ctype )
                    {
                        case GpuConstantType.Float1:
                        case GpuConstantType.Int1:
                        case GpuConstantType.Sampler1D:
                        case GpuConstantType.Sampler2D:
                        case GpuConstantType.Sampler3D:
                        case GpuConstantType.Sampler1DShadow:
                        case GpuConstantType.Sampler2DShadow:
                        case GpuConstantType.SamplerCube:
                            return 1;
                        case GpuConstantType.Float2:
                        case GpuConstantType.Int2:
                            return 2;
                        case GpuConstantType.Float3:
                        case GpuConstantType.Int3:
                            return 3;
                        case GpuConstantType.Float4:
                        case GpuConstantType.Int4:
                            return 4;
                        case GpuConstantType.Matrix_2X2:
                            return 4;
                        case GpuConstantType.Matrix_2X3:
                        case GpuConstantType.Matrix_3X2:
                            return 6;
                        case GpuConstantType.Matrix_2X4:
                        case GpuConstantType.Matrix_4X2:
                            return 8;
                        case GpuConstantType.Matrix_3X3:
                            return 9;
                        case GpuConstantType.Matrix_3X4:
                        case GpuConstantType.Matrix_4X3:
                            return 12;
                        case GpuConstantType.Matrix_4X4:
                            return 16;
                        default:
                            return 4;
                    }
                }
            }
        }
    }
}