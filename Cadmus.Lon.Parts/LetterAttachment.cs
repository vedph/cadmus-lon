using Cadmus.Mat.Bricks;
using System.Text;

namespace Cadmus.Lon.Parts;

/// <summary>
/// A material attachment to a letter.
/// </summary>
public class LetterAttachment
{
    /// <summary>
    /// Gets or sets the type, usually drawn from a thesaurus
    /// (<c>letter-attachment-types</c>).
    /// </summary>
    public string Type { get; set; } = "";

    /// <summary>
    /// Gets or sets the attachment's name.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Gets or sets a generic free text note.
    /// </summary>
    public string Note { get; set; } = "";

    /// <summary>
    /// Gets or sets the optional size.
    /// </summary>
    public PhysicalSize? Size { get; set; }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append(Type);
        if (!string.IsNullOrEmpty(Name))
        {
            sb.Append(": ");
            sb.Append(Name);
        }
        return sb.ToString();
    }
}
