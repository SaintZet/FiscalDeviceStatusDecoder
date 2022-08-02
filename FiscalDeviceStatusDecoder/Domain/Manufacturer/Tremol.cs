using System;
using System.Collections.Generic;

namespace FiscalDeviceStatusDecoder.Domain;

/// <inheritdoc/>
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
                { (0, 1), "Power down in opened fiscal receipt" },
                { (0, 3), "DateTime not set" },
                { (0, 4), "DateTime wrong" },
                { (0, 5), "RAM reset" },
                { (0, 6), "Hardware clock error" },

                { (1, 1), "Reports registers Overflow" },

                { (2, 1), "Opened Fiscal Receipt" },
                { (2, 2), "Receipt Invoice Type" },
                { (2, 5), "SD card near full" },
                { (2, 6), "SD card full" },

                { (3, 5), "CU fiscalized" },
                { (3, 6), "CU produced" },

                { (4, 0), "Paired with TIMS" },
                { (4, 1), "Unsent receipts" },

                { (5, 0), "No Sec.IC" },
                { (5, 1), "No certificates" },
                { (5, 2), "Service jumper" },
                { (5, 4), "Missing SD card" },
                { (5, 5), "Wrong SD card" },
    };
    public override Dictionary<(int, int), string>? DefaultDocument => new()
            {
                { (0,0), "FM Read only" },
                { (0, 1), "Power down in opened fiscal receipt " },
                { (0, 2), "Printer not ready - overheat" },
                { (0, 3), "DateTime not set" },
                { (0, 4), "DateTime wrong" },
                { (0, 5), "RAM reset" },
                { (0, 6), "Hardware clock error" },

                { (1, 0), "Printer not ready - no paper" },
                { (1, 1), "Reports registers Overflow" },
                { (1, 2), "Customer report is not zeroed" },
                { (1, 3), "Daily report is not zeroed" },
                { (1, 4), "Article report is not zeroed" },
                { (1, 5), "Operator report is not zeroed" },
                { (1, 6), "Duplicate printed" },

                { (2, 0), "Opened Non-fiscal Receipt" },
                { (2, 1), "Opened Fiscal Receipt" },
                { (2, 2), "Opened Fiscal Detailed Receipt" },
                { (2, 3), "Opened Fiscal Receipt with VAT" },
                { (2, 4), "Opened Invoice Fiscal Receipt" },
                { (2, 5), "SD card near full" },
                { (2, 6), "SD card full" },

                { (3, 0), "No FM module" },
                { (3, 1), "FM error" },
                { (3, 2), "FM full" },
                { (3, 3), "FM near full" },
                { (3, 4), "Decimal point" },
                { (3, 5), "FM fiscalized" },
                { (3, 6), "FM produced" },

                { (4, 0), "Printer: automatic cutting" },
                { (4, 1), "External display: transparent display" },
                { (4, 2), "Speed is 9600" },
                { (4, 4), "Drawer: automatic opening" },
                { (4, 5), "Customer logo included in the receipt" },

                { (5, 0), "Wrong SIM card" },
                { (5, 1), "Blocking 3 days without mobile operator" },
                { (5, 2), "No task from NRA" },
                { (5, 5), "Wrong SD card" },
                { (5, 6), "Deregistered" },

                { (6, 0), "No SIM card" },
                { (6, 1), "No GPRS Modem" },
                { (6, 2), "No mobile operator" },
                { (6, 3), "No GPRS service" },
                { (6, 4), "Near end of paper" },
                { (6, 5), "Unsent data for 24 hours" },
            };

    #endregion Documents
}