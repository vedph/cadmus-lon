﻿using Cadmus.Core;
using Cadmus.Lon.Parts;
using Fusi.Tools.Configuration;
using System;
using System.Reflection;
using Xunit;

namespace Cadmus.Seed.Lon.Parts.Test;

public sealed class LetterInfoPartSeederTest
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
        Type t = typeof(LetterInfoPartSeeder);
        TagAttribute? attr = t.GetTypeInfo().GetCustomAttribute<TagAttribute>();
        Assert.NotNull(attr);
        Assert.Equal("seed.it.vedph.lon.letter-info", attr!.Tag);
    }

    [Fact]
    public void Seed_Ok()
    {
        LetterInfoPartSeeder seeder = new();
        seeder.SetSeedOptions(_seedOptions);

        IPart? part = seeder.GetPart(_item, null, _factory);

        Assert.NotNull(part);

        LetterInfoPart? p = part as LetterInfoPart;
        Assert.NotNull(p);

        TestHelper.AssertPartMetadata(p!);
    }
}
