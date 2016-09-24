﻿// Accord Machine Learning Library
// The Accord.NET Framework
// http://accord-framework.net
//
// Copyright © Alex Risman, 2016
// https://github.com/mthmn20
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

namespace Accord.MachineLearning.DecisionTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.IO;
    using Accord.Statistics.Filters;
    using Accord.Math;
    using AForge;
    using Accord.Statistics;
    using System.Threading;


    /// <summary>
    ///   Random Forest
    /// </summary>
    /// 
    [Serializable]
    public class RandomForest : MulticlassClassifierBase
    {
        private DecisionTree[] trees;


        /// <summary>
        ///   Gets the trees in the random forest.
        /// </summary>
        /// 
        public DecisionTree[] Trees
        {
            get { return trees; }
        }

        /// <summary>
        ///   Gets the number of classes that can be recognized
        ///   by this random forest.
        /// </summary>
        /// 
        [Obsolete("Please use NumberOfOutputs instead.")]
        public int Classes { get { return NumberOfOutputs; } }

        /// <summary>
        ///   Creates a new random forest.
        /// </summary>
        /// 
        /// <param name="trees">The number of trees in the forest.</param>
        /// <param name="classes">The number of classes in the classification problem.</param>
        /// 
        public RandomForest(int trees, int classes)
        {
            this.trees = new DecisionTree[trees];
            this.NumberOfOutputs = classes;
        }

        /// <summary>
        ///   Computes the decision output for a given input vector.
        /// </summary>
        /// 
        /// <param name="data">The input vector.</param>
        /// 
        /// <returns>The forest decision for the given vector.</returns>
        /// 
        [Obsolete("Please use Decide() instead.")]
        public int Compute(double[] data)
        {
            return Decide(data);
        }


        /// <summary>
        /// Computes a class-label decision for a given <paramref name="input" />.
        /// </summary>
        /// <param name="input">The input vector that should be classified into
        /// one of the <see cref="ITransform.NumberOfOutputs" /> possible classes.</param>
        /// <returns>A class-label that best described <paramref name="input" /> according
        /// to this classifier.</returns>
        public override int Decide(double[] input)
        {
            int[] responses = new int[NumberOfOutputs];
            Parallel.For(0, trees.Length, i =>
            {
                int j = trees[i].Decide(input);
                Interlocked.Increment(ref responses[j]);
            });

            return responses.ArgMax();
        }
    }
}
