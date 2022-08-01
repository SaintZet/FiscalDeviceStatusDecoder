using System;
using System.Collections.Generic;

namespace FiscalDeviceStatusDecoder.Domain;

internal sealed class Eltrade : BaseManufacturer
{
    private static readonly Lazy<Eltrade> lazy = new Lazy<Eltrade>(() => new Eltrade());

    private Eltrade()
    {
    }

    public static Eltrade Instance => lazy.Value;

    public override string Name => nameof(Eltrade);
    public override Dictionary<(string[], Country), Dictionary<(int, int), string>>? AllModels => throw new NotImplementedException();

    #region Documents

    public override Dictionary<(int, int), string>? DefaultDocument => new()
            {
                { (0,0), "All good" },
            };

    #endregion Documents
}