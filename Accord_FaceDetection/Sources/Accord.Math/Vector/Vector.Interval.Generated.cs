﻿// Accord Math Library
// The Accord.NET Framework
// http://accord-framework.net
//
// Copyright © César Souza, 2009-2016
// cesarsouza at gmail.com
//
//    This library is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 2.1 of the License, or (at your option) any later version.
//
//    This library is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public
//    License along with this library; if not, write to the Free Software
//    Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
//

// ======================================================================
// This code has been generated by a tool; do not edit manually. Instead,
// edit the T4 template Vector.Interval.tt so this file can be regenerated. 
// ======================================================================


namespace Accord.Math
{
    using System;
    using Accord.Math;

    public static partial class Vector
    {

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static int[] Interval(int a, int b)
        {
            return Interval(a, b, (double)1.0);
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static int[] Interval(int a, int b, double stepSize)
        {
            if (a == b)
                return new [] { a };

            int[] r;

            if (a > b)
            {
                int steps = (int)System.Math.Ceiling((a - b) / (double)stepSize) + 1;
                r = new int[steps];
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (int)(a - i * stepSize);
                r[steps - 1] = (int)(b);
            }
            else
            {
                int steps = (int)System.Math.Ceiling((b - a) / (double)stepSize) + 1;
                r = new int[steps];
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (int)(a + i * stepSize);
                r[steps - 1] = (int)(b);
            }

            return r;
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static int[] Interval(int a, int b, int steps)
        {
            if (a == b)
                return new [] { a };

            if (steps == Int32.MaxValue)
            {
                throw new ArgumentOutOfRangeException("steps",
                    "input must be lesser than Int32.MaxValue");
            }

            var r = new int[steps + 1];

            if (a > b)
            {
                int stepSize = (int)((a - b) / (int)steps);
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (int)(a - i * stepSize);
                r[steps] = (int)(b);
            }
            else
            {
                var stepSize = (int)((b - a) / (int)steps);
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (int)(a + i * stepSize);
                r[steps] = (int)(b);
            }

            return r;
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static float[] Interval(float a, float b)
        {
            return Interval(a, b, (float)1.0);
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static float[] Interval(float a, float b, float stepSize)
        {
            if (a == b)
                return new [] { a };

            float[] r;

            if (a > b)
            {
                int steps = (int)System.Math.Ceiling((a - b) / (double)stepSize) + 1;
                r = new float[steps];
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (float)(a - i * stepSize);
                r[steps - 1] = (float)(b);
            }
            else
            {
                int steps = (int)System.Math.Ceiling((b - a) / (double)stepSize) + 1;
                r = new float[steps];
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (float)(a + i * stepSize);
                r[steps - 1] = (float)(b);
            }

            return r;
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static float[] Interval(float a, float b, int steps)
        {
            if (a == b)
                return new [] { a };

            if (steps == Int32.MaxValue)
            {
                throw new ArgumentOutOfRangeException("steps",
                    "input must be lesser than Int32.MaxValue");
            }

            var r = new float[steps + 1];

            if (a > b)
            {
                float stepSize = (float)((a - b) / (float)steps);
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (float)(a - i * stepSize);
                r[steps] = (float)(b);
            }
            else
            {
                var stepSize = (float)((b - a) / (float)steps);
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (float)(a + i * stepSize);
                r[steps] = (float)(b);
            }

            return r;
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static double[] Interval(double a, double b)
        {
            return Interval(a, b, (double)1.0);
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static double[] Interval(double a, double b, double stepSize)
        {
            if (a == b)
                return new [] { a };

            double[] r;

            if (a > b)
            {
                int steps = (int)System.Math.Ceiling((a - b) / (double)stepSize) + 1;
                r = new double[steps];
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (double)(a - i * stepSize);
                r[steps - 1] = (double)(b);
            }
            else
            {
                int steps = (int)System.Math.Ceiling((b - a) / (double)stepSize) + 1;
                r = new double[steps];
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (double)(a + i * stepSize);
                r[steps - 1] = (double)(b);
            }

            return r;
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static double[] Interval(double a, double b, int steps)
        {
            if (a == b)
                return new [] { a };

            if (steps == Int32.MaxValue)
            {
                throw new ArgumentOutOfRangeException("steps",
                    "input must be lesser than Int32.MaxValue");
            }

            var r = new double[steps + 1];

            if (a > b)
            {
                double stepSize = (double)((a - b) / (double)steps);
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (double)(a - i * stepSize);
                r[steps] = (double)(b);
            }
            else
            {
                var stepSize = (double)((b - a) / (double)steps);
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (double)(a + i * stepSize);
                r[steps] = (double)(b);
            }

            return r;
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static short[] Interval(short a, short b)
        {
            return Interval(a, b, (short)1.0);
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static short[] Interval(short a, short b, short stepSize)
        {
            if (a == b)
                return new [] { a };

            short[] r;

            if (a > b)
            {
                int steps = (int)System.Math.Ceiling((a - b) / (double)stepSize) + 1;
                r = new short[steps];
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (short)(a - i * stepSize);
                r[steps - 1] = (short)(b);
            }
            else
            {
                int steps = (int)System.Math.Ceiling((b - a) / (double)stepSize) + 1;
                r = new short[steps];
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (short)(a + i * stepSize);
                r[steps - 1] = (short)(b);
            }

            return r;
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static short[] Interval(short a, short b, int steps)
        {
            if (a == b)
                return new [] { a };

            if (steps == Int32.MaxValue)
            {
                throw new ArgumentOutOfRangeException("steps",
                    "input must be lesser than Int32.MaxValue");
            }

            var r = new short[steps + 1];

            if (a > b)
            {
                short stepSize = (short)((a - b) / (short)steps);
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (short)(a - i * stepSize);
                r[steps] = (short)(b);
            }
            else
            {
                var stepSize = (short)((b - a) / (short)steps);
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (short)(a + i * stepSize);
                r[steps] = (short)(b);
            }

            return r;
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static byte[] Interval(byte a, byte b)
        {
            return Interval(a, b, (byte)1.0);
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static byte[] Interval(byte a, byte b, byte stepSize)
        {
            if (a == b)
                return new [] { a };

            byte[] r;

            if (a > b)
            {
                int steps = (int)System.Math.Ceiling((a - b) / (double)stepSize) + 1;
                r = new byte[steps];
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (byte)(a - i * stepSize);
                r[steps - 1] = (byte)(b);
            }
            else
            {
                int steps = (int)System.Math.Ceiling((b - a) / (double)stepSize) + 1;
                r = new byte[steps];
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (byte)(a + i * stepSize);
                r[steps - 1] = (byte)(b);
            }

            return r;
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static byte[] Interval(byte a, byte b, int steps)
        {
            if (a == b)
                return new [] { a };

            if (steps == Int32.MaxValue)
            {
                throw new ArgumentOutOfRangeException("steps",
                    "input must be lesser than Int32.MaxValue");
            }

            var r = new byte[steps + 1];

            if (a > b)
            {
                byte stepSize = (byte)((a - b) / (byte)steps);
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (byte)(a - i * stepSize);
                r[steps] = (byte)(b);
            }
            else
            {
                var stepSize = (byte)((b - a) / (byte)steps);
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (byte)(a + i * stepSize);
                r[steps] = (byte)(b);
            }

            return r;
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static sbyte[] Interval(sbyte a, sbyte b)
        {
            return Interval(a, b, (sbyte)1.0);
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static sbyte[] Interval(sbyte a, sbyte b, sbyte stepSize)
        {
            if (a == b)
                return new [] { a };

            sbyte[] r;

            if (a > b)
            {
                int steps = (int)System.Math.Ceiling((a - b) / (double)stepSize) + 1;
                r = new sbyte[steps];
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (sbyte)(a - i * stepSize);
                r[steps - 1] = (sbyte)(b);
            }
            else
            {
                int steps = (int)System.Math.Ceiling((b - a) / (double)stepSize) + 1;
                r = new sbyte[steps];
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (sbyte)(a + i * stepSize);
                r[steps - 1] = (sbyte)(b);
            }

            return r;
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static sbyte[] Interval(sbyte a, sbyte b, int steps)
        {
            if (a == b)
                return new [] { a };

            if (steps == Int32.MaxValue)
            {
                throw new ArgumentOutOfRangeException("steps",
                    "input must be lesser than Int32.MaxValue");
            }

            var r = new sbyte[steps + 1];

            if (a > b)
            {
                sbyte stepSize = (sbyte)((a - b) / (sbyte)steps);
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (sbyte)(a - i * stepSize);
                r[steps] = (sbyte)(b);
            }
            else
            {
                var stepSize = (sbyte)((b - a) / (sbyte)steps);
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (sbyte)(a + i * stepSize);
                r[steps] = (sbyte)(b);
            }

            return r;
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static long[] Interval(long a, long b)
        {
            return Interval(a, b, (long)1.0);
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static long[] Interval(long a, long b, long stepSize)
        {
            if (a == b)
                return new [] { a };

            long[] r;

            if (a > b)
            {
                int steps = (int)System.Math.Ceiling((a - b) / (double)stepSize) + 1;
                r = new long[steps];
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (long)(a - i * stepSize);
                r[steps - 1] = (long)(b);
            }
            else
            {
                int steps = (int)System.Math.Ceiling((b - a) / (double)stepSize) + 1;
                r = new long[steps];
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (long)(a + i * stepSize);
                r[steps - 1] = (long)(b);
            }

            return r;
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static long[] Interval(long a, long b, int steps)
        {
            if (a == b)
                return new [] { a };

            if (steps == Int32.MaxValue)
            {
                throw new ArgumentOutOfRangeException("steps",
                    "input must be lesser than Int32.MaxValue");
            }

            var r = new long[steps + 1];

            if (a > b)
            {
                long stepSize = (long)((a - b) / (long)steps);
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (long)(a - i * stepSize);
                r[steps] = (long)(b);
            }
            else
            {
                var stepSize = (long)((b - a) / (long)steps);
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (long)(a + i * stepSize);
                r[steps] = (long)(b);
            }

            return r;
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static decimal[] Interval(decimal a, decimal b)
        {
            return Interval(a, b, (decimal)1.0);
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static decimal[] Interval(decimal a, decimal b, decimal stepSize)
        {
            if (a == b)
                return new [] { a };

            decimal[] r;

            if (a > b)
            {
                int steps = (int)System.Math.Ceiling((a - b) / (decimal)stepSize) + 1;
                r = new decimal[steps];
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (decimal)(a - i * stepSize);
                r[steps - 1] = (decimal)(b);
            }
            else
            {
                int steps = (int)System.Math.Ceiling((b - a) / (decimal)stepSize) + 1;
                r = new decimal[steps];
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (decimal)(a + i * stepSize);
                r[steps - 1] = (decimal)(b);
            }

            return r;
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static decimal[] Interval(decimal a, decimal b, int steps)
        {
            if (a == b)
                return new [] { a };

            if (steps == Int32.MaxValue)
            {
                throw new ArgumentOutOfRangeException("steps",
                    "input must be lesser than Int32.MaxValue");
            }

            var r = new decimal[steps + 1];

            if (a > b)
            {
                decimal stepSize = (decimal)((a - b) / (decimal)steps);
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (decimal)(a - i * stepSize);
                r[steps] = (decimal)(b);
            }
            else
            {
                var stepSize = (decimal)((b - a) / (decimal)steps);
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (decimal)(a + i * stepSize);
                r[steps] = (decimal)(b);
            }

            return r;
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static ulong[] Interval(ulong a, ulong b)
        {
            return Interval(a, b, (ulong)1.0);
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static ulong[] Interval(ulong a, ulong b, ulong stepSize)
        {
            if (a == b)
                return new [] { a };

            ulong[] r;

            if (a > b)
            {
                int steps = (int)System.Math.Ceiling((a - b) / (double)stepSize) + 1;
                r = new ulong[steps];
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (ulong)(a - i * stepSize);
                r[steps - 1] = (ulong)(b);
            }
            else
            {
                int steps = (int)System.Math.Ceiling((b - a) / (double)stepSize) + 1;
                r = new ulong[steps];
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (ulong)(a + i * stepSize);
                r[steps - 1] = (ulong)(b);
            }

            return r;
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static ulong[] Interval(ulong a, ulong b, int steps)
        {
            if (a == b)
                return new [] { a };

            if (steps == Int32.MaxValue)
            {
                throw new ArgumentOutOfRangeException("steps",
                    "input must be lesser than Int32.MaxValue");
            }

            var r = new ulong[steps + 1];

            if (a > b)
            {
                ulong stepSize = (ulong)((a - b) / (ulong)steps);
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (ulong)(a - i * stepSize);
                r[steps] = (ulong)(b);
            }
            else
            {
                var stepSize = (ulong)((b - a) / (ulong)steps);
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (ulong)(a + i * stepSize);
                r[steps] = (ulong)(b);
            }

            return r;
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static ushort[] Interval(ushort a, ushort b)
        {
            return Interval(a, b, (ushort)1.0);
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static ushort[] Interval(ushort a, ushort b, ushort stepSize)
        {
            if (a == b)
                return new [] { a };

            ushort[] r;

            if (a > b)
            {
                int steps = (int)System.Math.Ceiling((a - b) / (double)stepSize) + 1;
                r = new ushort[steps];
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (ushort)(a - i * stepSize);
                r[steps - 1] = (ushort)(b);
            }
            else
            {
                int steps = (int)System.Math.Ceiling((b - a) / (double)stepSize) + 1;
                r = new ushort[steps];
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (ushort)(a + i * stepSize);
                r[steps - 1] = (ushort)(b);
            }

            return r;
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static ushort[] Interval(ushort a, ushort b, int steps)
        {
            if (a == b)
                return new [] { a };

            if (steps == Int32.MaxValue)
            {
                throw new ArgumentOutOfRangeException("steps",
                    "input must be lesser than Int32.MaxValue");
            }

            var r = new ushort[steps + 1];

            if (a > b)
            {
                ushort stepSize = (ushort)((a - b) / (ushort)steps);
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (ushort)(a - i * stepSize);
                r[steps] = (ushort)(b);
            }
            else
            {
                var stepSize = (ushort)((b - a) / (ushort)steps);
                for (uint i = 0; i < r.Length; i++)
                    r[i] = (ushort)(a + i * stepSize);
                r[steps] = (ushort)(b);
            }

            return r;
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static double[] Interval(this DoubleRange range, int steps)
        {
            return Interval(range.Min, range.Max, steps);
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static double[] Interval(this DoubleRange range, double stepSize)
        {
            return Interval(range.Min, range.Max, stepSize);
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static float[] Interval(this Range range, int steps)
        {
            return Interval(range.Min, range.Max, steps);
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static float[] Interval(this Range range, float stepSize)
        {
            return Interval(range.Min, range.Max, stepSize);
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static byte[] Interval(this ByteRange range, int steps)
        {
            return Interval(range.Min, range.Max, steps);
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static byte[] Interval(this ByteRange range, byte stepSize)
        {
            return Interval(range.Min, range.Max, stepSize);
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static int[] Interval(this IntRange range, int steps)
        {
            return Interval(range.Min, range.Max, steps);
        }

        /// <summary>
        ///   Creates an interval vector.
        /// </summary>
        /// 
        public static int[] Interval(this IntRange range, double stepSize)
        {
            return Interval(range.Min, range.Max, stepSize);
        }
    }
}