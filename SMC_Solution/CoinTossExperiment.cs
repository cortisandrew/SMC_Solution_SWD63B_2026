using System;
using System.Collections.Generic;
using System.Text;

namespace SMC_Solution;

public class CoinTossExperiment : ISimulation
{
    public double Simulate()
    {
        bool coinTossOne = Random.Shared.NextDouble() > 0.5;
        bool coinTossTwo = Random.Shared.NextDouble() > 0.5;

        // Both Head
        if (coinTossOne && coinTossTwo)
        {
            return 3.5;
        }
        // HT or TH
        else if (coinTossOne || coinTossTwo)
        {
            return -1;
        }
        // TT
        else
        {
            return -2;
        }
    }
}
