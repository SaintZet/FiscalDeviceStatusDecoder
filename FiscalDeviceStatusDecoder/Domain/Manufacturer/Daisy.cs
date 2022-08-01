using System;
using System.Collections.Generic;

namespace FiscalDeviceStatusDecoder.Domain;

internal sealed class Daisy : BaseManufacturer
{
    private static readonly Lazy<Daisy> lazy = new Lazy<Daisy>(() => new Daisy());

    private Daisy()
    {
    }

    public static Daisy Instance => lazy.Value;

    public override string Name => nameof(Daisy);
    public override Dictionary<(string[], Country), Dictionary<(int, int), string>>? AllModels => throw new NotImplementedException();

    #region Documents

    public override Dictionary<(int, int), string>? DefaultDocument => new()
            {
                { (0,0), "All good" },
            };

    #endregion Documents
}