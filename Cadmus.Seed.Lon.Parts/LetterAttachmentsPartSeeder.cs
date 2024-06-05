using Bogus;
using Cadmus.Core;
using Cadmus.Lon.Parts;
using Fusi.Tools.Configuration;
using System;
using System.Collections.Generic;

namespace Cadmus.Seed.Lon.Parts;

/// <summary>
/// Seeder for <see cref="LetterAttachmentsPart"/>.
/// Tag: <c>seed.it.vedph.lon.letter-attachments</c>.
/// </summary>
/// <seealso cref="PartSeederBase" />
[Tag("seed.it.vedph.lon.letter-attachments")]
public sealed class LetterAttachmentsPartSeeder : PartSeederBase
{
    private static List<LetterAttachment> GetAttachments(int count)
    {
        List<LetterAttachment> attachments = [];
        for (int n = 1; n <= count; n++)
        {
            attachments.Add(new Faker<LetterAttachment>()
                .RuleFor(a => a.Type, f => f.PickRandom("literary", "picture"))
                .RuleFor(a => a.Name, f => f.Lorem.Word())
                .RuleFor(a => a.Note, f => f.Random.Bool(0.3f)
                    ? f.Lorem.Sentence() : null)
                .RuleFor(a => a.Size, f => f.Random.Bool(0.3f)
                    ? SeedHelper.GetPhysicalSize(f.Random) : null)
                .Generate());
        }
        return attachments;
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

        LetterAttachmentsPart part = new Faker<LetterAttachmentsPart>()
           .RuleFor(p => p.Attachments,
                f => GetAttachments(f.Random.Number(0, 3)))
           .Generate();
        SetPartMetadata(part, roleId, item);

        return part;
    }
}
