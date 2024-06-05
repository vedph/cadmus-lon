using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cadmus.Core;
using Fusi.Tools.Configuration;

namespace Cadmus.Lon.Parts;

/// <summary>
/// Letter's attachments.
/// <para>Tag: <c>it.vedph.lon.letter-attachments</c>.</para>
/// </summary>
[Tag("it.vedph.lon.letter-attachments")]
public sealed class LetterAttachmentsPart : PartBase
{
    /// <summary>
    /// Gets or sets the attachments.
    /// </summary>
    public List<LetterAttachment> Attachments { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LetterAttachmentsPart"/> class.
    /// </summary>
    public LetterAttachmentsPart()
    {
        Attachments = [];
    }

    /// <summary>
    /// Get all the key=value pairs (pins) exposed by the implementor.
    /// </summary>
    /// <param name="item">The optional item. The item with its parts
    /// can optionally be passed to this method for those parts requiring
    /// to access further data.</param>
    /// <returns>The pins: <c>tot-count</c> and a collection of pins with
    /// these keys: ....</returns>
    public override IEnumerable<DataPin> GetDataPins(IItem? item = null)
    {
        DataPinBuilder builder = new(DataPinHelper.DefaultFilter);

        builder.Set("tot", Attachments?.Count ?? 0, false);

        if (Attachments?.Count > 0)
        {
            // all the names
            foreach (LetterAttachment attachment in Attachments)
            {
                builder.AddValue("name", attachment.Name,
                    filter: true, filterOptions: true);
            }
            // unique types
            builder.AddValues("type", Attachments.Select(a => a.Type));
        }

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
                "name",
                "The attachment's names.",
                "MF"),
            new DataPinDefinition(DataPinValueType.String,
                "type",
                "The attachment's unique types.",
                "M"),
            new DataPinDefinition(DataPinValueType.Integer,
               "tot-count",
               "The total count of entries.")
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

        sb.Append("[LetterAttachmentsPart]");

        if (Attachments?.Count > 0)
        {
            sb.Append(' ');
            int n = 0;
            foreach (var entry in Attachments)
            {
                if (++n > 3) break;
                if (n > 1) sb.Append("; ");
                sb.Append(entry);
            }
            if (Attachments.Count > 3)
                sb.Append("...(").Append(Attachments.Count).Append(')');
        }

        return sb.ToString();
    }
}
