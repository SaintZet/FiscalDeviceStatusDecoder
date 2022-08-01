using System;
using System.Collections.Generic;

namespace FiscalDeviceStatusDecoder.Domain;

internal sealed class Tremol : BaseManufacturer
{
    private static readonly Lazy<Tremol> lazy = new Lazy<Tremol>(() => new Tremol());

    private Tremol()
    {
    }

    public static Tremol Instance => lazy.Value;

    public override string Name => nameof(Tremol);
    public override Dictionary<(string[], Country), Dictionary<(int, int), string>>? AllModels => new()
    {
        {(new string[] { "CU", "M23" }, Country.KE), Document1! },
    };

    #region Documents

    public Dictionary<(int, int), string> Document1 = new()
            {
                { (0,0), "All good" },
            };
    public override Dictionary<(int, int), string>? DefaultDocument => new()
            {
                { (0,0), "All good" },
            };

    #endregion Documents
}