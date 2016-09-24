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

namespace Accord.Statistics.Models.Regression
{
    using System;
    using Accord.Statistics.Links;
    using AForge;
    using Accord.MachineLearning;

    /// <summary>
    ///   Binary Logistic Regression.
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    ///   In statistics, logistic regression (sometimes called the logistic model or
    ///   Logit model) is used for prediction of the probability of occurrence of an
    ///   event by fitting data to a logistic curve. It is a generalized linear model
    ///   used for binomial regression.</para>
    /// <para>
    ///   Like many forms of regression analysis, it makes use of several predictor
    ///   variables that may be either numerical or categorical. For example, the
    ///   probability that a person has a heart attack within a specified time period
    ///   might be predicted from knowledge of the person's age, sex and body mass index.</para>
    /// <para>
    ///   Logistic regression is used extensively in the medical and social sciences
    ///   as well as marketing applications such as prediction of a customer's
    ///   propensity to purchase a product or cease a subscription.</para>  
    /// 
    /// <para>
    ///   References:
    ///   <list type="bullet">
    ///     <item><description>
    ///       Bishop, Christopher M.; Pattern Recognition and Machine Learning. 
    ///       Springer; 1st ed. 2006.</description></item>
    ///     <item><description>
    ///       Amos Storkey. (2005). Learning from Data: Learning Logistic Regressors. School of Informatics.
    ///       Available on: http://www.inf.ed.ac.uk/teaching/courses/lfd/lectures/logisticlearn-print.pdf </description></item>
    ///     <item><description>
    ///       Cosma Shalizi. (2009). Logistic Regression and Newton's Method. Available on:
    ///       http://www.stat.cmu.edu/~cshalizi/350/lectures/26/lecture-26.pdf </description></item>
    ///     <item><description>
    ///       Edward F. Conor. Logistic Regression. Website. Available on: 
    ///       http://userwww.sfsu.edu/~efc/classes/biol710/logistic/logisticreg.htm </description></item>
    ///   </list></para>  
    /// </remarks>
    /// 
    /// <example>
    ///     <code source="Unit Tests\Accord.Tests.Statistics\Models\Regression\LogisticRegressionTest.cs" region="doc_log_reg_1" />
    /// </example>
    /// 
    [Serializable]
    public class LogisticRegression : GeneralizedLinearRegression
    {

        /// <summary>
        ///   Creates a new Logistic Regression Model.
        /// </summary>
        /// 
        public LogisticRegression()
            : base(new LogitLinkFunction())
        {
        }

        /// <summary>
        ///   Creates a new Logistic Regression Model.
        /// </summary>
        /// 
        /// <param name="inputs">The number of input variables for the model.</param>
        /// 
        public LogisticRegression(int inputs)
            : base(new LogitLinkFunction(), inputs) { }

        /// <summary>
        ///   Creates a new Logistic Regression Model.
        /// </summary>
        /// 
        /// <param name="inputs">The number of input variables for the model.</param>
        /// <param name="intercept">The starting intercept value. Default is 0.</param>
        /// 
        public LogisticRegression(int inputs, double intercept)
            : base(new LogitLinkFunction(), inputs, intercept) { }

        /// <summary>
        ///   Gets the 95% confidence interval for the
        ///   Odds Ratio for a given coefficient.
        /// </summary>
        /// 
        /// <param name="index">
        ///   The coefficient's index. The first value
        ///   (at zero index) is the intercept value.
        /// </param>
        /// 
        public DoubleRange GetConfidenceInterval(int index)
        {
            double coeff = Coefficients[index];
            double error = StandardErrors[index];

            double upper = coeff + 1.9599 * error;
            double lower = coeff - 1.9599 * error;

            DoubleRange ci = new DoubleRange(Math.Exp(lower), Math.Exp(upper));

            return ci;
        }

        /// <summary>
        ///   Gets the Odds Ratio for a given coefficient.
        /// </summary>
        /// 
        /// <remarks>
        ///   The odds ratio can be computed raising Euler's number
        ///   (e ~~ 2.71) to the power of the associated coefficient.
        /// </remarks>
        /// 
        /// <param name="index">
        ///   The coefficient's index. The first value
        ///   (at zero index) is the intercept value.
        /// </param>
        /// 
        /// <returns>
        ///   The Odds Ratio for the given coefficient.
        /// </returns>
        /// 
        public double GetOddsRatio(int index)
        {
            return Math.Exp(Coefficients[index]);
        }

        /// <summary>
        ///   Constructs a new <see cref="LogisticRegression"/> from
        ///   an array of weights (linear coefficients). The first
        ///   weight is interpreted as the intercept value.
        /// </summary>
        /// 
        /// <param name="weights">An array of linear coefficients.</param>
        /// 
        /// <returns>
        ///   A <see cref="LogisticRegression"/> whose 
        ///   <see cref="GeneralizedLinearRegression.Coefficients"/> are
        ///   the same as in the given <paramref name="weights"/> array.
        /// </returns>
        /// 
        public static LogisticRegression FromWeights(double[] weights)
        {
            var lr = new LogisticRegression(weights.Length - 1);
            for (int i = 0; i < weights.Length; i++)
                lr.Coefficients[i] = weights[i];

            return lr;
        }

    }
}
