using System;
using System.Collections.Generic;

namespace FiscalDeviceStatusDecoder.Domain;

internal sealed class Datecs : BaseManufacturer
{
    private static readonly Lazy<Datecs> lazy = new Lazy<Datecs>(() => new Datecs());

    private Datecs()
    {
    }

    public static Datecs Instance => lazy.Value;

    public override string Name => nameof(Datecs);
    public override Dictionary<(string[], Country), Dictionary<(int, int), string>>? AllModels => new()
    {
        {(new string[] { "DP-05", "DP-25", "DP-35", "WP-50", "DP-150" }, Country.BG), Document1! },
        {(new string[] { "FP-800", "FP-2000", "FP-650", "SK1-21F", "SK1-31F", "FMP-10", "FP-700" }, Country.BG), Document2! },
        {(new string[] { "DP-25X", "DP-05C", "WP-500X", "WP-50X", "FP-700X", "FP-700XR", "FMP-350Xv", "FMP-55X" }, Country.BG), Document3! },
    };

    #region Documents

    public Dictionary<(int, int), string> Document1 = new()
            {
                { (0,0), "All good" },
            };
    public Dictionary<(int, int), string> Document2 = new()
            {
                { (0,0), "All good" },
            };
    public Dictionary<(int, int), string> Document3 = new()
            {
                { (0,0), "All good" },
            };
    public override Dictionary<(int, int), string>? DefaultDocument => new()
            {
                { (0,0), "All good" },
            };

    #endregion Documents
}