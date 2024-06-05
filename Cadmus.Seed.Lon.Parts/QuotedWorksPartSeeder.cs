using Bogus;
using Cadmus.Core;
using Cadmus.Lon.Parts;
using Fusi.Tools.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cadmus.Seed.Lon.Parts;

/// <summary>
/// Seeder for <see cref="QuotedWorksPart"/>.
/// Tag: <c>seed.it.vedph.lon.quoted-works</c>.
/// </summary>
/// <seealso cref="PartSeederBase" />
[Tag("seed.it.vedph.lon.quoted-works")]
public sealed class QuotedWorksPartSeeder : PartSeederBase
{
    private static List<QuotedWork> GetQuotedWorks(int count)
    {
        List<QuotedWork> works = [];
        for (int n = 1; n <= count; n++)
        {
            works.Add(new Faker<QuotedWork>()
                .RuleFor(p => p.Id, f => f.Database.Random.AlphaNumeric(5))
                // TODO role from thesaurus
                .RuleFor(p => p.Role, f => f.PickRandom("-", "alpha"))
                .RuleFor(p => p.Location, f =>
                    f.Random.Number(1, 100).ToString(CultureInfo.InvariantCulture))
                .RuleFor(p => p.Note, f => f.Random.Bool(0.3f)
                    ? f.Lorem.Sentence() : null)
                .Generate());
        }
        return works;
    }

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

        QuotedWorksPart part = new Faker<QuotedWorksPart>()
            .RuleFor(f => f.Works, f => GetQuotedWorks(f.Random.Number(1, 3)))
            .Generate();
        SetPartMetadata(part, roleId, item);

        return part;
    }
}
