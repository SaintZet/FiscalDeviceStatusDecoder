using System;
using System.Collections.Generic;
using System.Linq;

namespace FiscalDeviceStatusDecoder.Domain;

/// <summary>
/// Comment.
/// </summary>
public abstract class BaseManufacturer
{
    public abstract Dictionary<(string[], Country), Dictionary<(int, int), string>>? AllModels { get; }
    public abstract Dictionary<(int, int), string>? DefaultDocument { get; }
    public abstract string Name { get; }

    public virtual Dictionary<(int, int), string> GetStatusDocument(string[]? currentModels, Country country)
    {
        if (currentModels == null)
        {
            return DefaultDocument!;
        }

        foreach (var keyValue in AllModels!)
        {
            if (keyValue.Key.Item2 != country)
            {
                continue;
            }

            if (keyValue.Key.Item1.Intersect(currentModels).Any())
            {
                return keyValue.Value;
            }
        }

        throw new NotImplementedException();
    }
}

#region TemplateDocument

//{ (0,0), "" },
//{ (0, 1), "" },
//{ (0, 2), "" },
//{ (0, 3), "" },
//{ (0, 4), "" },
//{ (0, 5), "" },
//{ (0, 6), "" },
//{ (0, 7), "" },

//{ (1, 0), "" },
//{ (1, 1), "" },
//{ (1, 2), "" },
//{ (1, 3), "" },
//{ (1, 4), "" },
//{ (1, 5), "" },
//{ (1, 6), "" },
//{ (1, 7), "" },

//{ (2, 0), "" },
//{ (2, 1), "" },
//{ (2, 2), "" },
//{ (2, 3), "" },
//{ (2, 4), "" },
//{ (2, 5), "" },
//{ (2, 6), "" },
//{ (2, 7), "" },

//{ (3, 0), "" },
//{ (3, 1), "" },
//{ (3, 2), "" },
//{ (3, 3), "" },
//{ (3, 4), "" },
//{ (3, 5), "" },
//{ (3, 6), "" },
//{ (3, 7), "" },

//{ (4, 0), "" },
//{ (4, 1), "" },
//{ (4, 2), "" },
//{ (4, 3), "" },
//{ (4, 4), "" },
//{ (4, 5), "" },
//{ (4, 6), "" },
//{ (4, 7), "" },

//{ (5, 0), "" },
//{ (5, 1), "" },
//{ (5, 2), "" },
//{ (5, 3), "" },
//{ (5, 4), "" },
//{ (5, 5), "" },
//{ (5, 6), "" },
//{ (5, 7), "" },

//{ (6, 0), "" },
//{ (6, 1), "" },
//{ (6, 2), "" },
//{ (6, 3), "" },
//{ (6, 4), "" },
//{ (6, 5), "" },
//{ (6, 6), "" },
//{ (6, 7), "" },

//{ (7, 0), "" },
//{ (7, 1), "" },
//{ (7, 2), "" },
//{ (7, 3), "" },
//{ (7, 4), "" },
//{ (7, 5), "" },
//{ (7, 6), "" },
//{ (7, 7), "" },

#endregion TemplateDocument