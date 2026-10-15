using SMC_Solution;

var experiment = new CoinTossExperiment();

SimpleMonteCarloDriver driver = new SimpleMonteCarloDriver(experiment);

int[] runSizes = [100, 1_000, 10_000, 100_000, 1_000_000, 10_000_000 ];

foreach (int runSize in runSizes)
{
    driver.RunSimulations(runSize);

    Console.WriteLine($"Using {runSize} simulations, the estimated mean for the experiment is {driver.EstimateExpectedValue()}");
}