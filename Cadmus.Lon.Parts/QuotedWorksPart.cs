using System.Collections.Generic;
using System.Text;
using Cadmus.Core;
using Fusi.Tools.Configuration;

namespace Cadmus.Lon.Parts;

/// <summary>
/// List of quoted works.
/// <para>Tag: <c>it.vedph.lon.quoted-works</c>.</para>
/// </summary>
[Tag("it.vedph.lon.quoted-works")]
public sealed class QuotedWorksPart : PartBase
{
    /// <summary>
    /// Gets or sets the entries.
    /// </summary>
    public List<QuotedWork> Works { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="QuotedWorksPart"/> class.
    /// </summary>
    public QuotedWorksPart()
    {
        Works = [];
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

        builder.Set("tot", Works?.Count ?? 0, false);

        if (Works?.Count > 0)
        {
            foreach (QuotedWork work in Works)
            {
                builder.AddValue("id", work.Id);
            }
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
                "id",
                "The work's identifier(s).",
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

        sb.Append("[QuotedWorks]");

        if (Works?.Count > 0)
        {
            sb.Append(' ');
            int n = 0;
            foreach (var entry in Works)
            {
                if (++n > 3) break;
                if (n > 1) sb.Append("; ");
                sb.Append(entry);
            }
            if (Works.Count > 3)
                sb.Append("...(").Append(Works.Count).Append(')');
        }

        return sb.ToString();
    }
}
