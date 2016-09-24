﻿// Accord Statistics Library
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

namespace Accord.MachineLearning
{
    using Accord.MachineLearning;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    ///   Common interface for multiple regression models. Multiple regression
    ///   models learn how to produce a set of real values (a real-valued vector)
    ///   from an input vector <c>x</c>.
    /// </summary>
    /// 
    /// <typeparam name="TInput">The data type for the input data. Default is double[].</typeparam>
    /// <typeparam name="TOutput">The data type for the predicted variables. Default is double.</typeparam>
    /// 
    public interface IMultipleRegression<TInput, TOutput> :
        IRegression<TInput, TOutput[]>
    {
    }

    /// <summary>
    ///   Common interface for multiple regression models. Multiple regression
    ///   models learn how to produce a set of real values (a real-valued vector)
    ///   from an input vector <c>x</c>.
    /// </summary>
    /// 
    /// <typeparam name="TInput">The data type for the input data. Default is double[].</typeparam>
    /// 
    public interface IMultipleRegression<TInput> :
        IMultipleRegression<TInput, double>,
        IMultipleRegression<TInput, float>
    {
    }
}
