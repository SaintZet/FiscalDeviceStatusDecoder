using System;
using System.Collections.Generic;
using System.Linq;

namespace FiscalDeviceStatusDecoder.Domain
{
    internal class Daisy
    {
        private Dictionary<string[], Dictionary<(int, int), string>> AllModels = new();

        #region Documents

        private Dictionary<(int, int), string> DefaultDocument = new()
                {
                    { (0,0), "All good" },
                };

        #endregion Documents

        internal Daisy()
        {
        }

        //TODO: Create abstract class.
        internal Dictionary<(int, int), string> GetDocument(string[]? currentModels)
        {
            if (currentModels == null)
            {
                return DefaultDocument;
            }

            foreach (var keyValue in AllModels)
            {
                if (keyValue.Key.Intersect(currentModels).Any())
                {
                    return keyValue.Value;
                }
            }

            throw new NotImplementedException();
        }
    }
}