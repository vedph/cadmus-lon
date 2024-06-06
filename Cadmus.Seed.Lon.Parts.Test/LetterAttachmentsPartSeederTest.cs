using Cadmus.Core;
using Cadmus.Lon.Parts;
using Fusi.Tools.Configuration;
using System;
using System.Reflection;

namespace Cadmus.Seed.Lon.Parts.Test;

public sealed class LetterAttachmentsPartSeederTest
{
    private static readonly PartSeederFactory _factory =
        TestHelper.GetFactory();
    private static readonly SeedOptions _seedOptions =
        _factory.GetSeedOptions();
    private static readonly IItem _item =
        _factory.GetItemSeeder().GetItem(1, "facet");

    [Fact]
    public void TypeHasTagAttribute()
    {
        Type t = typeof(LetterAttachmentsPartSeeder);
        TagAttribute? attr = t.GetTypeInfo().GetCustomAttribute<TagAttribute>();
        Assert.NotNull(attr);
        Assert.Equal("seed.it.vedph.lon.letter-attachments", attr!.Tag);
    }

    [Fact]
    public void Seed_Ok()
    {
        LetterAttachmentsPartSeeder seeder = new();
        seeder.SetSeedOptions(_seedOptions);

        IPart? part = seeder.GetPart(_item, null, _factory);

        Assert.NotNull(part);

        LetterAttachmentsPart? p = part as LetterAttachmentsPart;
        Assert.NotNull(p);

        TestHelper.AssertPartMetadata(p!);
    }
}
