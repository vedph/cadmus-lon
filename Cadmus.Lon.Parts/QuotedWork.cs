using System.Text;

namespace Cadmus.Lon.Parts;

/// <summary>
/// A quoted work.
/// </summary>
public class QuotedWork
{
    /// <summary>
    /// Gets or sets the work's identifier, usually drawn from a thesaurus
    /// (<c>quoted-works-ids</c>).
    /// </summary>
    public string Id { get; set; } = "";

    /// <summary>
    /// Gets or sets the role played by the cited work in relation with its
    /// source.
    /// </summary>
    public string? Role { get; set; }

    /// <summary>
    /// Gets or sets the location of the quoted passage.
    /// </summary>
    public string? Location { get; set; }

    /// <summary>
    /// Gets or sets an optional free text note.
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        StringBuilder sb = new(Id);
        if (!string.IsNullOrEmpty(Role))
            sb.Append(" [").Append(Role).Append(']');
        if (!string.IsNullOrEmpty(Location))
            sb.Append(' ').Append(Location);
        return sb.ToString();
    }
}
