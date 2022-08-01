using System;
using System.Collections.Generic;

namespace FiscalDeviceStatusDecoder.Domain;

internal sealed class Port : BaseManufacturer
{
    private static readonly Lazy<Port> lazy = new Lazy<Port>(() => new Port());

    private Port()
    {
    }

    public static Port Instance => lazy.Value;
    public override string Name => nameof(Port);
    public override Dictionary<(string[], Country), Dictionary<(int, int), string>>? AllModels => new()
    {
        {(new string[] { "150", "600", "1000" }, Country.RU), Document1! },
        {(new string[] { "150" }, Country.KZ), Document2! },
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
    public override Dictionary<(int, int), string>? DefaultDocument => throw new NotImplementedException();

    #endregion Documents
}