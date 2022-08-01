using System;
using System.Collections.Generic;
using System.Linq;

namespace FiscalDeviceStatusDecoder.Domain
{
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
}