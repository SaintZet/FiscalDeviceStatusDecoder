using System;
using System.Collections.Generic;
using System.Linq;

namespace FiscalDeviceStatusDecoder.Domain
{
    internal class Datecs
    {
        private Dictionary<string[], Dictionary<(int, int), string>> AllModels = new();

        #region Documents

        private Dictionary<(int, int), string> DefaultDocument = new()
                {
                    { (0,0), "All good" },
                };
        private Dictionary<(int, int), string> Document1 = new()
                {
                    { (0,0), "All good" },
                };
        private Dictionary<(int, int), string> Document2 = new()
                {
                    { (0,0), "All good" },
                };
        private Dictionary<(int, int), string> Document3 = new()
                {
                    { (0,0), "All good" },
                };

        #endregion Documents

        internal Datecs()
        {
            AllModels.Add(new string[] { "DP-05", "DP-25", "DP-35", "WP-50", "DP-150" }, Document1);
            AllModels.Add(new string[] { "FP-800", "FP-2000", "FP-650", "SK1-21F", "SK1-31F", "FMP-10", "FP-700" }, Document2);
            AllModels.Add(new string[] { "DP-25X", "DP-05C", "WP-500X", "WP-50X", "FP-700X", "FP-700XR", "FMP-350Xv", "FMP-55X" }, Document3);
        }

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