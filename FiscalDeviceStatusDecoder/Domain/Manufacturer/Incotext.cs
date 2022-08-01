using System;
using System.Collections.Generic;

namespace FiscalDeviceStatusDecoder.Domain;

internal sealed class Incotext : BaseManufacturer
{
    private static readonly Lazy<Incotext> lazy = new Lazy<Incotext>(() => new Incotext());

    private Incotext()
    {
    }

    public static Incotext Instance => lazy.Value;

    public override string Name => nameof(Incotext);
    public override Dictionary<(string[], Country), Dictionary<(int, int), string>>? AllModels => throw new NotImplementedException();

    #region Documents

    public override Dictionary<(int, int), string>? DefaultDocument => new()
            {
                { (0,0), "All good" },
            };

    #endregion Documents
}