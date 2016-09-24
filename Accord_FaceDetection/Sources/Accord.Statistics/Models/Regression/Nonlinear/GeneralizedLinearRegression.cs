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
    using System.Linq;
    using Accord.Statistics.Links;
    using Accord.Statistics.Testing;
    using Accord.MachineLearning;
    using Accord.Math;

    /// <summary>
    ///   Generalized Linear Model Regression.
    /// </summary>
    /// 
    /// <remarks>
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
    public class GeneralizedLinearRegression : BinaryLikelihoodClassifierBase<double[]>, ICloneable
    {

        private ILinkFunction linkFunction;
        private double[] coefficients;
        private double[] standardErrors;


        /// <summary>
        ///   Creates a new Generalized Linear Regression Model.
        /// </summary>
        /// 
        /// <param name="function">The link function to use.</param>
        /// 
        public GeneralizedLinearRegression(ILinkFunction function)
        {
            this.linkFunction = function;
            this.NumberOfOutputs = 1;
            this.NumberOfInputs = 1;
        }

        /// <summary>
        ///   Creates a new Generalized Linear Regression Model.
        /// </summary>
        /// 
        /// <param name="function">The link function to use.</param>
        /// <param name="inputs">The number of input variables for the model.</param>
        /// 
        public GeneralizedLinearRegression(ILinkFunction function, int inputs)
        {
            this.linkFunction = function;
            this.coefficients = new double[inputs + 1];
            this.standardErrors = new double[inputs + 1];
            this.NumberOfInputs = inputs;
            this.NumberOfOutputs = 1;
        }

        /// <summary>
        ///   Creates a new Generalized Linear Regression Model.
        /// </summary>
        /// 
        /// <param name="function">The link function to use.</param>
        /// <param name="inputs">The number of input variables for the model.</param>
        /// <param name="intercept">The starting intercept value. Default is 0.</param>
        /// 
        public GeneralizedLinearRegression(ILinkFunction function, int inputs, double intercept)
            : this(function, inputs)
        {
            this.coefficients[0] = intercept;
        }

        /// <summary>
        ///   Creates a new Generalized Linear Regression Model.
        /// </summary>
        /// 
        public GeneralizedLinearRegression()
        {
            this.NumberOfOutputs = 1;
        }

        /// <summary>
        ///   Creates a new Generalized Linear Regression Model.
        /// </summary>
        /// 
        /// <param name="function">The link function to use.</param>
        /// <param name="coefficients">The coefficient vector.</param>
        /// <param name="standardErrors">The standard error vector.</param>
        /// 
        public GeneralizedLinearRegression(ILinkFunction function,
            double[] coefficients, double[] standardErrors)
            : this()
        {
            this.linkFunction = function;
            this.coefficients = coefficients;
            this.standardErrors = standardErrors;
        }

        /// <summary>
        /// Gets the number of inputs accepted by the model.
        /// </summary>
        /// 
        public override int NumberOfInputs
        {
            get { return base.NumberOfInputs; }
            set
            {
                base.NumberOfInputs = value;
                this.coefficients = Vector.Create(value + 1, this.coefficients);
                this.standardErrors = Vector.Create(value + 1, this.standardErrors);
            }
        }

        /// <summary>
        ///   Gets the coefficient vector, in which the
        ///   first value is always the intercept value.
        /// </summary>
        /// 
        public double[] Coefficients
        {
            get { return coefficients; }
        }

        /// <summary>
        ///   Gets the standard errors associated with each
        ///   coefficient during the model estimation phase.
        /// </summary>
        /// 
        public double[] StandardErrors
        {
            get { return standardErrors; }
        }

        /// <summary>
        ///   Gets the number of inputs handled by this model.
        /// </summary>
        /// 
        [Obsolete("Please use NumberOfInputs instead.")]
        public int Inputs
        {
            get { return coefficients.Length - 1; }
        }

        /// <summary>
        ///   Gets the link function used by
        ///   this generalized linear model.
        /// </summary>
        /// 
        public ILinkFunction Link
        {
            get { return linkFunction; }
        }

        /// <summary>
        ///   Gets or sets the intercept term. This is always the 
        ///   first value of the <see cref="Coefficients"/> array.
        /// </summary>
        /// 
        public double Intercept
        {
            get { return coefficients[0]; }
            set { coefficients[0] = value; }
        }




        /// <summary>
        ///   Computes the model output for the given input vector.
        /// </summary>
        /// 
        /// <param name="input">The input vector.</param>
        /// 
        /// <returns>The output value.</returns>
        /// 
        [Obsolete("Please use the Score method instead.")]
        public double Compute(double[] input)
        {
            double sum = coefficients[0];
            for (int i = 1; i < coefficients.Length; i++)
                sum += input[i - 1] * coefficients[i];
            return linkFunction.Inverse(sum);
        }

        /// <summary>
        ///   Computes the model output for each of the given input vectors.
        /// </summary>
        /// 
        /// <param name="input">The array of input vectors.</param>
        /// 
        /// <returns>The array of output values.</returns>
        /// 
        [Obsolete("Please use the Score method instead.")]
        public double[] Compute(double[][] input)
        {
            double[] output = new double[input.Length];
#pragma warning disable 612, 618
            for (int i = 0; i < input.Length; i++)
                output[i] = Compute(input[i]);
#pragma warning restore 612, 618
            return output;
        }




        /// <summary>
        ///   Gets the Wald Test for a given coefficient.
        /// </summary>
        /// 
        /// <remarks>
        ///   The Wald statistical test is a test for a model parameter in which
        ///   the estimated parameter θ is compared with another proposed parameter
        ///   under the assumption that the difference between them will be approximately
        ///   normal. There are several problems with the use of the Wald test. Please
        ///   take a look on substitute tests based on the log-likelihood if possible.
        /// </remarks>
        /// 
        /// <param name="index">
        ///   The coefficient's index. The first value
        ///   (at zero index) is the intercept value.
        /// </param>
        /// 
        public WaldTest GetWaldTest(int index)
        {
            return new WaldTest(coefficients[index], 0.0, standardErrors[index]);
        }


        /// <summary>
        ///   Gets the Log-Likelihood for the model.
        /// </summary>
        /// 
        /// <param name="input">A set of input data.</param>
        /// <param name="output">A set of output data.</param>
        /// <returns>
        ///   The Log-Likelihood (a measure of performance) of
        ///   the model calculated over the given data sets.
        /// </returns>
        /// 
        public double GetLogLikelihood(double[][] input, double[] output)
        {
            double sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                double actualOutput = Score(input[i]);
                double expectedOutput = output[i];

                if (actualOutput != 0)
                    sum += expectedOutput * Math.Log(actualOutput);

                if (actualOutput != 1)
                    sum += (1 - expectedOutput) * Math.Log(1 - actualOutput);

                Accord.Diagnostics.Debug.Assert(!Double.IsNaN(sum));
            }

            return sum;
        }

        /// <summary>
        ///   Gets the Log-Likelihood for the model.
        /// </summary>
        /// 
        /// <param name="input">A set of input data.</param>
        /// <param name="output">A set of output data.</param>
        /// <param name="weights">The weights associated with each input vector.</param>
        /// 
        /// <returns>
        ///   The Log-Likelihood (a measure of performance) of
        ///   the model calculated over the given data sets.
        /// </returns>
        /// 
        public double GetLogLikelihood(double[][] input, double[] output, double[] weights)
        {
            double sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                double w = weights[i];
                double actualOutput = Score(input[i]);
                double expectedOutput = output[i];

                if (actualOutput != 0)
                    sum += expectedOutput * Math.Log(actualOutput) * w;

                if (actualOutput != 1)
                    sum += (1 - expectedOutput) * Math.Log(1 - actualOutput) * w;

                Accord.Diagnostics.Debug.Assert(!Double.IsNaN(sum));
            }

            return sum;
        }

        /// <summary>
        ///   Gets the Deviance for the model.
        /// </summary>
        /// 
        /// <remarks>
        ///   The deviance is defined as -2*Log-Likelihood.
        /// </remarks>
        /// 
        /// <param name="input">A set of input data.</param>
        /// <param name="output">A set of output data.</param>
        /// <returns>
        ///   The deviance (a measure of performance) of the model
        ///   calculated over the given data sets.
        /// </returns>
        /// 
        public double GetDeviance(double[][] input, double[] output)
        {
            return -2.0 * GetLogLikelihood(input, output);
        }

        /// <summary>
        ///   Gets the Deviance for the model.
        /// </summary>
        /// 
        /// <remarks>
        ///   The deviance is defined as -2*Log-Likelihood.
        /// </remarks>
        /// 
        /// <param name="input">A set of input data.</param>
        /// <param name="output">A set of output data.</param>
        /// <param name="weights">The weights associated with each input vector.</param>
        /// 
        /// <returns>
        ///   The deviance (a measure of performance) of the model
        ///   calculated over the given data sets.
        /// </returns>
        /// 
        public double GetDeviance(double[][] input, double[] output, double[] weights)
        {
            return -2.0 * GetLogLikelihood(input, output, weights);
        }

        /// <summary>
        ///   Gets the Log-Likelihood Ratio between two models.
        /// </summary>
        /// 
        /// <remarks>
        ///   The Log-Likelihood ratio is defined as 2*(LL - LL0).
        /// </remarks>
        /// 
        /// <param name="input">A set of input data.</param>
        /// <param name="output">A set of output data.</param>
        /// <param name="regression">Another Logistic Regression model.</param>
        /// 
        /// <returns>The Log-Likelihood ratio (a measure of performance
        /// between two models) calculated over the given data sets.</returns>
        /// 
        public double GetLogLikelihoodRatio(double[][] input, double[] output, GeneralizedLinearRegression regression)
        {
            return 2.0 * (this.GetLogLikelihood(input, output) - regression.GetLogLikelihood(input, output));
        }

        /// <summary>
        ///   Gets the Log-Likelihood Ratio between two models.
        /// </summary>
        /// 
        /// <remarks>
        ///   The Log-Likelihood ratio is defined as 2*(LL - LL0).
        /// </remarks>
        /// 
        /// <param name="input">A set of input data.</param>
        /// <param name="output">A set of output data.</param>
        /// <param name="weights">The weights associated with each input vector.</param>
        /// <param name="regression">Another Logistic Regression model.</param>
        /// 
        /// <returns>The Log-Likelihood ratio (a measure of performance
        /// between two models) calculated over the given data sets.</returns>
        /// 
        public double GetLogLikelihoodRatio(double[][] input, double[] output, double[] weights, GeneralizedLinearRegression regression)
        {
            return 2.0 * (this.GetLogLikelihood(input, output, weights) - regression.GetLogLikelihood(input, output, weights));
        }


        /// <summary>
        ///   The likelihood ratio test of the overall model, also called the model chi-square test.
        /// </summary>
        /// 
        /// <param name="input">A set of input data.</param>
        /// <param name="output">A set of output data.</param>
        /// 
        /// <remarks>
        ///   <para>
        ///   The Chi-square test, also called the likelihood ratio test or the log-likelihood test
        ///   is based on the deviance of the model (-2*log-likelihood). The log-likelihood ratio test 
        ///   indicates whether there is evidence of the need to move from a simpler model to a more
        ///   complicated one (where the simpler model is nested within the complicated one).</para>
        ///   <para>
        ///   The difference between the log-likelihood ratios for the researcher's model and a
        ///   simpler model is often called the "model chi-square".</para>
        /// </remarks>
        /// 
        public ChiSquareTest ChiSquare(double[][] input, double[] output)
        {
            double y0 = 0;
            double y1 = 0;

            for (int i = 0; i < output.Length; i++)
            {
                y0 += 1.0 - output[i];
                y1 += output[i];
            }

            var intercept = Math.Log(y1 / y0);
            var regression = new GeneralizedLinearRegression(linkFunction, NumberOfInputs, intercept);

            double ratio = GetLogLikelihoodRatio(input, output, regression);

            return new ChiSquareTest(ratio, coefficients.Length - 1);
        }

        /// <summary>
        ///   The likelihood ratio test of the overall model, also called the model chi-square test.
        /// </summary>
        /// 
        /// <param name="input">A set of input data.</param>
        /// <param name="output">A set of output data.</param>
        /// <param name="weights">The weights associated with each input vector.</param>
        /// 
        /// <remarks>
        ///   <para>
        ///   The Chi-square test, also called the likelihood ratio test or the log-likelihood test
        ///   is based on the deviance of the model (-2*log-likelihood). The log-likelihood ratio test 
        ///   indicates whether there is evidence of the need to move from a simpler model to a more
        ///   complicated one (where the simpler model is nested within the complicated one).</para>
        ///   <para>
        ///   The difference between the log-likelihood ratios for the researcher's model and a
        ///   simpler model is often called the "model chi-square".</para>
        /// </remarks>
        /// 
        public ChiSquareTest ChiSquare(double[][] input, double[] output, double[] weights)
        {
            double y0 = 0;
            double y1 = 0;

            for (int i = 0; i < output.Length; i++)
            {
                y0 += (1.0 - output[i]) * weights[i];
                y1 += output[i] * weights[i];
            }

            var intercept = Math.Log(y1 / y0);

            var regression = new GeneralizedLinearRegression(linkFunction, NumberOfInputs, intercept);

            double ratio = GetLogLikelihoodRatio(input, output, weights, regression);

            return new ChiSquareTest(ratio, coefficients.Length - 1);
        }


        /// <summary>
        ///   Creates a new GeneralizedLinearRegression that is a copy of the current instance.
        /// </summary>
        /// 
        public object Clone()
        {
            ILinkFunction function = (ILinkFunction)linkFunction.Clone();

            var regression = new GeneralizedLinearRegression(function, coefficients.Length);
            regression.coefficients = (double[])this.coefficients.Clone();
            regression.standardErrors = (double[])this.standardErrors.Clone();

            return regression;
        }


        /// <summary>
        ///   Creates a GeneralizedLinearRegression from a <see cref="LogisticRegression"/> object. 
        /// </summary>
        /// 
        /// <param name="regression">A <see cref="LogisticRegression"/> object.</param>
        /// <param name="makeCopy">True to make a copy of the logistic regression values, false
        /// to use the actual values. If the actual values are used, changes done on one model
        /// will be reflected on the other model.</param>
        /// 
        /// <returns>A new <see cref="GeneralizedLinearRegression"/> which is a copy of the 
        /// given <see cref="LogisticRegression"/>.</returns>
        /// 
        public static GeneralizedLinearRegression FromLogisticRegression(
            LogisticRegression regression, bool makeCopy)
        {
            if (makeCopy)
            {
                double[] coefficients = (double[])regression.Coefficients.Clone();
                double[] standardErrors = (double[])regression.StandardErrors.Clone();
                return new GeneralizedLinearRegression(new LogitLinkFunction(),
                    coefficients, standardErrors);
            }
            else
            {
                return new GeneralizedLinearRegression(new LogitLinkFunction(),
                    regression.Coefficients, regression.StandardErrors);
            }
        }




        /// <summary>
        /// Predicts a class label vector for the given input vector, returning the
        /// log-likelihood that the input vector belongs to its predicted class.
        /// </summary>
        /// <param name="input">The input vector.</param>
        /// <param name="decision">The class label predicted by the classifier.</param>
        /// <returns></returns>
        public override double LogLikelihood(double[] input, out bool decision)
        {
            double sum = coefficients[0];
            for (int i = 1; i < coefficients.Length; i++)
                sum += input[i - 1] * coefficients[i];
            double z = linkFunction.Log(sum);
            decision = Classes.Decide(z - 0.5);
            return linkFunction.Log(sum);
        }

        /// <summary>
        /// Predicts a class label vector for the given input vector, returning the
        /// log-likelihood that the input vector belongs to its predicted class.
        /// </summary>
        /// <param name="input">The input vector.</param>
        /// <returns></returns>
        public override double LogLikelihood(double[] input)
        {
            double sum = coefficients[0];
            for (int i = 1; i < coefficients.Length; i++)
                sum += input[i - 1] * coefficients[i];
            return linkFunction.Log(sum);
        }

        /// <summary>
        /// Computes a numerical score measuring the association between
        /// the given <paramref name="input" /> vector and its most strongly
        /// associated class (as predicted by the classifier).
        /// </summary>
        /// <param name="input">The input vector.</param>
        /// <returns></returns>
        public override double Score(double[] input)
        {
            double sum = coefficients[0];
            for (int i = 1; i < coefficients.Length; i++)
                sum += input[i - 1] * coefficients[i];
            return linkFunction.Inverse(sum);
        }

        /// <summary>
        /// Computes a class-label decision for a given <paramref name="input" />.
        /// </summary>
        /// <param name="input">The input vector that should be classified into
        /// one of the <see cref="ITransform.NumberOfOutputs" /> possible classes.</param>
        /// <returns>
        /// A class-label that best described <paramref name="input" /> according
        /// to this classifier.
        /// </returns>
        public override bool Decide(double[] input)
        {
            double sum = coefficients[0];
            for (int i = 1; i < coefficients.Length; i++)
                sum += input[i - 1] * coefficients[i];
            double z = linkFunction.Inverse(sum);
            return Classes.Decide(z - 0.5);
        }
    }
}
