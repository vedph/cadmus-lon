using System;
using Cadmus.Core;
using System.Collections.Generic;
using System.Linq;
using Cadmus.Seed.Lon.Parts;

namespace Cadmus.Lon.Parts.Test;

public sealed class LetterInfoPartTest
{
    private static LetterInfoPart GetPart()
    {
        LetterInfoPartSeeder seeder = new();
        IItem item = new Item
        {
            FacetId = "default",
            CreatorId = "zeus",
            UserId = "zeus",
            Description = "Test item",
            Title = "Test Item",
            SortKey = ""
        };
        return (LetterInfoPart)seeder.GetPart(item, null, null)!;
    }

    private static LetterInfoPart GetEmptyPart()
    {
        return new LetterInfoPart
        {
            ItemId = Guid.NewGuid().ToString(),
            RoleId = "some-role",
            CreatorId = "zeus",
            UserId = "another",
        };
    }

    [Fact]
    public void Part_Is_Serializable()
    {
        LetterInfoPart part = GetPart();

        string json = TestHelper.SerializePart(part);
        LetterInfoPart part2 = TestHelper.DeserializePart<LetterInfoPart>(json)!;

        Assert.Equal(part.Id, part2.Id);
        Assert.Equal(part.TypeId, part2.TypeId);
        Assert.Equal(part.ItemId, part2.ItemId);
        Assert.Equal(part.RoleId, part2.RoleId);
        Assert.Equal(part.CreatorId, part2.CreatorId);
        Assert.Equal(part.UserId, part2.UserId);
    }

    [Fact]
    public void GetDataPins()
    {
        LetterInfoPart part = GetEmptyPart();
        part.Archive = "archive";
        part.Shelfmark = "shelfmark";
        part.Language = "ita";
        part.Languages = ["eng", "fra"];
        part.Features = ["f1", "f2"];

        List<DataPin> pins = part.GetDataPins(null).ToList();
        Assert.Equal(7, pins.Count);

        // archive
        DataPin? pin = pins.Find(p => p.Name == "archive" && p.Value == "archive");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        // shelfmark
        pin = pins.Find(p => p.Name == "shelfmark" && p.Value == "shelfmark");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        // language
        pin = pins.Find(p => p.Name == "language" && p.Value == "ita");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        // languages
        pin = pins.Find(p => p.Name == "add-language" && p.Value == "eng");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
        pin = pins.Find(p => p.Name == "add-language" && p.Value == "fra");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        // features
        pin = pins.Find(p => p.Name == "feature" && p.Value == "f1");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
        pin = pins.Find(p => p.Name == "feature" && p.Value == "f2");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
    }
}
