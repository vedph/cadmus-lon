using Bogus;
using Cadmus.Mat.Bricks;
using System;

namespace Cadmus.Seed.Lon.Parts;

internal static class SeedHelper
{
    public static PhysicalSize GetPhysicalSize(Randomizer randomizer)
    {
        return new PhysicalSize
        {
            W = new PhysicalDimension
            {
                Value = (float)Math.Round(randomizer.Float(10, 20), 0),
                Unit = "cm"
            },
            H = new PhysicalDimension
            {
                Value = (float)Math.Round(randomizer.Float(15, 30), 0),
                Unit = "cm"
            }
        };
    }
}
