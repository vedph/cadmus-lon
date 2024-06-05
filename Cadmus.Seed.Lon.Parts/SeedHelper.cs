using Bogus;
using Cadmus.Mat.Bricks;

namespace Cadmus.Seed.Lon.Parts;

internal static class SeedHelper
{
    public static PhysicalSize GetPhysicalSize(Randomizer randomizer)
    {
        return new PhysicalSize
        {
            W = new PhysicalDimension
            {
                Value = randomizer.Float(10, 20),
                Unit = "cm"
            },
            H = new PhysicalDimension
            {
                Value = randomizer.Float(15, 30),
                Unit = "cm"
            }
        };
    }
}
