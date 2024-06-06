using Cadmus.Core;
using Cadmus.Seed.Lon.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cadmus.Lon.Parts.Test;

public sealed class QuotedWorksPartTest
{
    private static QuotedWorksPart GetPart()
    {
        QuotedWorksPartSeeder seeder = new();
        IItem item = new Item
        {
            FacetId = "default",
            CreatorId = "zeus",
            UserId = "zeus",
            Description = "Test item",
            Title = "Test Item",
            SortKey = ""
        };
        return (QuotedWorksPart)seeder.GetPart(item, null, null)!;
    }

    private static QuotedWorksPart GetEmptyPart()
    {
        return new QuotedWorksPart
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
        QuotedWorksPart part = GetPart();

        string json = TestHelper.SerializePart(part);
        QuotedWorksPart part2 =
            TestHelper.DeserializePart<QuotedWorksPart>(json)!;

        Assert.Equal(part.Id, part2.Id);
        Assert.Equal(part.TypeId, part2.TypeId);
        Assert.Equal(part.ItemId, part2.ItemId);
        Assert.Equal(part.RoleId, part2.RoleId);
        Assert.Equal(part.CreatorId, part2.CreatorId);
        Assert.Equal(part.UserId, part2.UserId);

        Assert.Equal(part.Works.Count, part2.Works.Count);
    }

    [Fact]
    public void GetDataPins_NoEntries_Ok()
    {
        QuotedWorksPart part = GetPart();
        part.Works.Clear();

        List<DataPin> pins = part.GetDataPins(null).ToList();

        Assert.Single(pins);
        DataPin pin = pins[0];
        Assert.Equal("tot-count", pin.Name);
        TestHelper.AssertPinIds(part, pin);
        Assert.Equal("0", pin.Value);
    }

    [Fact]
    public void GetDataPins_Entries_Ok()
    {
        QuotedWorksPart part = GetEmptyPart();

        for (int n = 1; n <= 3; n++)
        {
            part.Works.Add(new QuotedWork
            {
                Id = $"w{n}",
                Role = n % 2 == 0 ? "even" : "odd",
                Location = "loc",
                Note = "note"
            });
        }

        List<DataPin> pins = part.GetDataPins(null).ToList();

        Assert.Equal(4, pins.Count);

        DataPin? pin = pins.Find(p => p.Name == "tot-count");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
        Assert.Equal("3", pin!.Value);

        for (int n = 1; n <= 3; n++)
        {
            pin = pins.Find(p => p.Name == "id" && p.Value == $"w{n}");
            Assert.NotNull(pin);
            TestHelper.AssertPinIds(part, pin!);
        }
    }
}
