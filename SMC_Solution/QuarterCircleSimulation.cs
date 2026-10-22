using System;
using System.Collections.Generic;
using System.Text;

namespace SMC_Solution;

public class QuarterCircleSimulation : ISimulation
{
    public double Simulate()
    {
        // Select a point over the unit square uniformly
        double x = Random.Shared.NextDouble();
        double y = Random.Shared.NextDouble();

        // This is the distance from (0,0) which is also the center of the circle
        double distance_from_origin = Math.Sqrt(x*x + y*y);

        // If the point is closer to (0,0) than the radius (=1), it is on the circle
        if (distance_from_origin < 1)
        {
            return 1; // point selected is on top of the quarter circle
        }
        else
        {
            return 0; // point selected is NOT on top of the quarter circle
        }
    }
}
