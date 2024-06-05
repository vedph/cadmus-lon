using Cadmus.Core;
using Cadmus.Seed.Lon.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cadmus.Lon.Parts.Test;

public sealed class LetterAttachmentsPartTest
{
    private static LetterAttachmentsPart GetPart()
    {
        LetterAttachmentsPartSeeder seeder = new();
        IItem item = new Item
        {
            FacetId = "default",
            CreatorId = "zeus",
            UserId = "zeus",
            Description = "Test item",
            Title = "Test Item",
            SortKey = ""
        };
        return (LetterAttachmentsPart)seeder.GetPart(item, null, null)!;
    }

    private static LetterAttachmentsPart GetEmptyPart()
    {
        return new LetterAttachmentsPart
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
        LetterAttachmentsPart part = GetPart();

        string json = TestHelper.SerializePart(part);
        LetterAttachmentsPart part2 =
            TestHelper.DeserializePart<LetterAttachmentsPart>(json)!;

        Assert.Equal(part.Id, part2.Id);
        Assert.Equal(part.TypeId, part2.TypeId);
        Assert.Equal(part.ItemId, part2.ItemId);
        Assert.Equal(part.RoleId, part2.RoleId);
        Assert.Equal(part.CreatorId, part2.CreatorId);
        Assert.Equal(part.UserId, part2.UserId);

        Assert.Equal(part.Attachments.Count, part2.Attachments.Count);
    }

    [Fact]
    public void GetDataPins_NoEntries_Ok()
    {
        LetterAttachmentsPart part = GetPart();
        part.Attachments.Clear();

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
        LetterAttachmentsPart part = GetEmptyPart();

        for (int n = 1; n <= 3; n++)
        {
            part.Attachments.Add(new LetterAttachment
            {
                Name = $"a{n}",
                Type = n % 2 == 0 ? "even" : "odd",
                Note = $"note{n}"
            });
        }

        List<DataPin> pins = part.GetDataPins(null).ToList();

        Assert.Equal(6, pins.Count);

        // tot-count
        DataPin? pin = pins.Find(p => p.Name == "tot-count");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
        Assert.Equal("3", pin!.Value);

        // name's
        for (int n = 1; n <= 3; n++)
        {
            pin = pins.Find(p => p.Name == $"name" && p.Value == $"a{n}");
            Assert.NotNull(pin);
            TestHelper.AssertPinIds(part, pin!);
        }

        // type's (odd, even)
        pin = pins.Find(p => p.Name == "type" && p.Value == "odd");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
        pin = pins.Find(p => p.Name == "type" && p.Value == "even");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
    }
}
