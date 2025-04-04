﻿# Cadmus LON

Cadmus models for project LON: "Letters on the net: Eugenio Montale's correspondence (1915-1981). Study and database".

Asterisks in models mark required properties. Stars mark new models, specifically created for this project. The project contains a single item type, letters.

## Letters

- [metadata](https://github.com/vedph/cadmus-general/blob/master/docs/metadata.md): generic metadata in the form of name=value pairs (e.g. the name(s) of the author(s) of a record, whether it is unedited, etc.).
- [external IDs](https://github.com/vedph/cadmus-general/blob/master/docs/external-ids.md) role `letter`: any number of identifiers for the letter in other resources, whether they are digital or not.
- [external IDs](https://github.com/vedph/cadmus-general/blob/master/docs/external-ids.md) role `corr`: correspondents, i.e. sender(s) and recipient(s). Their role is specified by `tag`.
- [chronotopes](https://github.com/vedph/cadmus-general/blob/master/docs/chronotopes.md): 1 or more place-and/or-date pairs.
- [links](https://github.com/vedph/cadmus-general/blob/master/docs/pin-links.md) for related letters, using the tag to specify the relation type.

- [categories](https://github.com/vedph/cadmus-general/blob/master/docs/categories.md) for topics.
- ⭐ `LetterInfoPart` (🔑 `it.vedph.lon.letter-info`): essential information about the letter:
  - archive (`string`, 📚 `letter-info-archives`): archival source.
  - shelfmark (`string`): archival shelfmark.
  - language\* (`string` default `ita` ISO 639-3; 📚 `letter-info-languages`): the primary (or unique) language of the letter.
  - languages (`string[]`, ISO 639-3; 📚 `letter-info-languages`): optional additional languages, besides the main language as specified by `language`.
  - features (`string[]`: flags from 📚 `letter-info-features` for boolean features like presence of stamps, typewritten, etc.).
  - size (`PhysicalSize`).
- ⭐ `LetterAttachmentsPart` (🔑 `it.vedph.lon.letter-attachments`): the list of letter's attachments:
  - type\* (`string`; 📚 `letter-attachment-types`)
  - name\* (`string`)
  - note (`string`)
  - size (`PhysicalSize`)
- [comment](https://github.com/vedph/cadmus-general/blob/master/docs/comment.md) includes the letter's summary and optionally its cited entities, unless you prefer to add them as external IDs. Cited entities include persons and places, and optionally works when they do not belong to the canonical list provided for the cited-works part. Canonical works have their own part including more specialized data.
- [note](https://github.com/vedph/cadmus-general/blob/master/docs/note.md) role `dsc`.
- [note](https://github.com/vedph/cadmus-general/blob/master/docs/note.md) role `incipit`.
- [note](https://github.com/vedph/cadmus-general/blob/master/docs/note.md) role `explicit`.
- [note](https://github.com/vedph/cadmus-general/blob/master/docs/note.md) role `text`.

- ⭐ `QuotedWorksPart` (🔑 `it.vedph.lon.quoted-works`): "canonical" works quoted by the letter. This draws from a hierarchical thesaurus. Sporadic works by third parties which you do not want to list here can be added to the entities in the comment.
  - id (`string`, 📚 `quoted-works-ids`, hierarchical)
  - role (`string`, 📚 `quoted-works-roles`)
  - location (`string`)
  - note (`string`)
- [external bibliography](https://github.com/vedph/cadmus-general/blob/master/docs/ext-bibliography.md) (reference edition may go here too).
- [note](https://github.com/vedph/cadmus-general/blob/master/docs/note.md) role `note`.

## History

### 2.0.0

- 2025-03-18: updated packages (bumped Cadmus core to v8).

### 1.0.2

- 2025-01-29: updated packages.

### 1.0.1

- 2025-01-06: updated packages.

### 1.0.0

- 2024-11-23: ⚠️ upgraded to .NET 9.

### 0.0.6

- 2024-09-28: updated packages.
- 2024-08-30: updated test packages.

### 0.0.5

- 2024-07-17: updated packages.

### 0.0.4

- 2024-06-25: no decimals in size seeder.

### 0.0.3

- 2024-06-18: updated seeders with real thesauri.
