using SMC_Solution;

var experiment = new CoinTossExperiment();

/*
SimpleMonteCarloDriver driver = new SimpleMonteCarloDriver(experiment);

int[] runSizes = [100, 1_000, 10_000, 100_000, 1_000_000, 10_000_000 ];

foreach (int runSize in runSizes)
{
    driver.RunSimulations(runSize);

    Console.WriteLine($"Using {runSize} simulations, the estimated mean for the experiment is {driver.EstimateExpectedValue()}");
}
*/


var driverQuarterCircle = new SimpleMonteCarloDriver(new QuarterCircleSimulation());

driverQuarterCircle.RunSimulations(10_000_000);

Console.WriteLine($"The estimated area of the quarter circle is {driverQuarterCircle.EstimateExpectedValue()}");
Console.WriteLine($"The true error is {Math.PI/4.0 - driverQuarterCircle.EstimateExpectedValue()}");
Console.WriteLine($"The estimated variance of the simulation is {driverQuarterCircle.EstimateVariance()}. The true variance is: {Math.PI/4.0 * (1 - Math.PI/4.0)}");
Console.WriteLine($"The RMSE of the simulation is {driverQuarterCircle.EstimateRMSE()}");



Console.WriteLine($"The estimated value for Pi is {driverQuarterCircle.EstimateExpectedValue() * 4}. The true value of Pi is {Math.PI}");

double maxRMSE = 0.00001;
Console.WriteLine($"To obtain a result with a RMSE of {maxRMSE}, we require {driverQuarterCircle.RequiredSimulations(maxRMSE)}");