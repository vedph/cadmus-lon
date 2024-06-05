using System.Collections.Generic;
using System.Text;
using Cadmus.Core;
using Cadmus.Mat.Bricks;
using Fusi.Tools.Configuration;

namespace Cadmus.Lon.Parts;

/// <summary>
/// Essential information about a letter.
/// <para>Tag: <c>it.vedph.lon.letter-info</c>.</para>
/// </summary>
[Tag("it.vedph.lon.letter-info")]
public sealed class LetterInfoPart : PartBase
{
    /// <summary>
    /// Gets or sets the archive source for this letter.
    /// Usually this is derived from a thesaurus (<c>letter-info-archives</c>).
    /// </summary>
    public string Archive { get; set; } = "";

    /// <summary>
    /// Gets or sets the shelfmark code in the archive.
    /// </summary>
    public string Shelfmark { get; set; } = "";

    /// <summary>
    /// Gets or sets the primary language used in the letter.
    /// Usually this is derived from a thesaurus (<c>letter-info-languages</c>).
    /// </summary>
    public string Language { get; set; } = "";

    /// <summary>
    /// Gets or sets the additional languages used in the letter.
    /// Usually this is derived from a thesaurus (<c>letter-info-languages</c>).
    /// </summary>
    public List<string> Languages { get; set; } = [];

    /// <summary>
    /// Gets or sets the letter's features, usually drawn from a thesaurus
    /// (<c>letter-info-features</c>).
    /// </summary>
    public List<string> Features { get; set; } = [];

    /// <summary>
    /// Gets or sets the optional physical size of the letter.
    /// </summary>
    public PhysicalSize? Size { get; set; }

    /// <summary>
    /// Get all the key=value pairs (pins) exposed by the implementor.
    /// </summary>
    /// <param name="item">The optional item. The item with its parts
    /// can optionally be passed to this method for those parts requiring
    /// to access further data.</param>
    /// <returns>The pins.</returns>
    public override IEnumerable<DataPin> GetDataPins(IItem? item = null)
    {
        DataPinBuilder builder = new();

        if (!string.IsNullOrEmpty(Archive))
            builder.AddValue("archive", Archive);
        if (!string.IsNullOrEmpty(Shelfmark))
            builder.AddValue("shelfmark", Shelfmark);
        if (!string.IsNullOrEmpty(Language))
            builder.AddValue("language", Language);
        if (Languages?.Count > 0)
            builder.AddValues("add-language", Languages);
        if (Features?.Count > 0)
            builder.AddValues("feature", Features);

        return builder.Build(this);
    }

    /// <summary>
    /// Gets the definitions of data pins used by the implementor.
    /// </summary>
    /// <returns>Data pins definitions.</returns>
    public override IList<DataPinDefinition> GetDataPinDefinitions()
    {
        return new List<DataPinDefinition>(
        [
            new DataPinDefinition(DataPinValueType.String,
                "archive",
                "The archive identifier."),
            new DataPinDefinition(DataPinValueType.String,
                "shelfmark",
                "The shelfmark code."),
                new DataPinDefinition(DataPinValueType.String,
                "language",
                "The main language."),
            new DataPinDefinition(DataPinValueType.String,
                "add-language",
                "Additional language(s).",
                "M"),
            new DataPinDefinition(DataPinValueType.String,
                "feature",
                "Feature(s).",
                "M"),
        ]);
    }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        StringBuilder sb = new();

        sb.Append("[LetterInfo]");
        sb.Append(Archive).Append(' ').Append(Shelfmark);

        return sb.ToString();
    }
}