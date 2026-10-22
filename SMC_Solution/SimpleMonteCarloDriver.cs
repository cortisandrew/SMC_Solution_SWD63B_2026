using System;
using System.Collections.Generic;
using System.Text;

namespace SMC_Solution;

/// <summary>
/// Test
/// </summary>
public class SimpleMonteCarloDriver
{
    private ISimulation _simulator;

    private IList<double>? _results = null;

    public SimpleMonteCarloDriver(ISimulation simulator)
    {
        _simulator = simulator;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="n">
    /// The number of simulations to run (i.e. time).
    /// </param>
    public void RunSimulations(int n)
    {
        _results = new List<double>(n);

        for (int i = 0; i < n; i++)
        {
            _results.Add(_simulator.Simulate());
        }
    }

    /// <summary>
    /// Calculates the expected value of the simulation by taking the mean of the simulations, after running the simulations
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public double EstimateExpectedValue()
    {
        if (_results == null || _results.Count == 0)
            throw new InvalidOperationException("You cannot estimate the expected value without any simulations");

        return _results.Average();
    }

    public double EstimateVariance()
    {
        if (_results == null || _results.Count == 0)
            throw new InvalidOperationException("You cannot estimate the variance without any simulations");

        double mu_estimate = EstimateExpectedValue();

        return _results.Sum(
                x => Math.Pow(x - mu_estimate, 2.0)
            ) 
            / (_results.Count - 1);
    }

    public double EstimateStandardDeviation()
    {
        return Math.Sqrt(EstimateVariance());
    }

    public double EstimateRMSE()
    {
        double sigma_estimate = EstimateStandardDeviation();

        return sigma_estimate / Math.Sqrt(_results!.Count);
    }

    public int RequiredSimulations(double maxRMSE)
    {
        return (int)Math.Ceiling(
            EstimateVariance() / Math.Pow(maxRMSE, 2.0));
    }
}
