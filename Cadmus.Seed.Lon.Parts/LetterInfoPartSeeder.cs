using Bogus;
using Cadmus.Core;
using Cadmus.Lon.Parts;
using Fusi.Tools.Configuration;
using System;

namespace Cadmus.Seed.Lon.Parts;

/// <summary>
/// Seeder for <see cref="LetterInfoPart"/>.
/// Tag: <c>seed.it.vedph.lon.letter-info</c>.
/// </summary>
/// <seealso cref="PartSeederBase" />
[Tag("seed.it.vedph.lon.letter-info")]
public sealed class LetterInfoPartSeeder : PartSeederBase
{
    /// <summary>
    /// Creates and seeds a new part.
    /// </summary>
    /// <param name="item">The item this part should belong to.</param>
    /// <param name="roleId">The optional part role ID.</param>
    /// <param name="factory">The part seeder factory. This is used
    /// for layer parts, which need to seed a set of fragments.</param>
    /// <returns>A new part or null.</returns>
    /// <exception cref="ArgumentNullException">item or factory</exception>
    public override IPart? GetPart(IItem item, string? roleId,
        PartSeederFactory? factory)
    {
        ArgumentNullException.ThrowIfNull(item);

        LetterInfoPart part = new Faker<LetterInfoPart>()
           .RuleFor(p => p.Archive, f => f.Company.CompanyName())
           .RuleFor(p => p.Shelfmark, f => f.Random.AlphaNumeric(8))
           .RuleFor(p => p.Language, f => f.PickRandom("ita", "eng"))
           .RuleFor(p => p.Languages, f => [f.PickRandom("spa", "fra")])
           .RuleFor(p => p.Features, f => [f.PickRandom("stamp", "envelope")])
           .RuleFor(p => p.Size, f => f.Random.Bool(0.3f)
                ? SeedHelper.GetPhysicalSize(f.Random) : null)
           .Generate();
        SetPartMetadata(part, roleId, item);

        return part;
    }
}
