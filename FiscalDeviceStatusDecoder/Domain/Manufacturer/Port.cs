using System;
using System.Collections.Generic;

namespace FiscalDeviceStatusDecoder.Domain;

/// <inheritdoc/>
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
                { (0,1), "Cover is open" },
                { (0,2), "General error - this is OR of all errors marked with #" },
                { (0,3), "# Failure in printing mechanism" },
                { (0,6), "# Command code is invalid" },
                { (0,7), "# Syntax error" },

                { (1,6), "# Command is not permitted" },
                { (1,7), "# Overflow during command execution" },

                { (2,2), "Nonfiscal receipt is open" },
                { (2,3), "EJ nearly full" },
                { (2,4), "Fiscal receipt is open" },
                { (2,5), "EJ is full" },
                { (2,6), "Near paper end" },
                { (2,7), "# End of paper" },

                { (4,2), "OR of all errors marked with ‘*’ from Bytes 4 и 5" },
                { (4,3), "* Fiscal memory is full" },
                { (4,4), "There is space for less then 60 reports in Fiscal memory" },
                { (4,5), "Serial number and number of FM are set" },
                { (4,6), "Tax number is set" },
                { (4,7), "* Error while writing in FM" },

                { (5,3), "VAT are set at least once" },
                { (5,4), "Device is fiscalized" },
                { (5,6), "FM is formated" },
            };
    public Dictionary<(int, int), string> Document2 = new()
            {
                { (0,1), "Cover is open" },
                { (0,2), "General error - this is OR of all errors marked with #" },
                { (0,3), "# Failure in printing mechanism" },
                { (0,4), "No client display connected" },
                { (0,5), "The real time clock is not synchronized" },
                { (0,6), "# Command code is invalid" },
                { (0,7), "# Syntax error" },

                { (1,5), "More than 24 hours after day opening" },
                { (1,6), "# Command is not permitted" },
                { (1,7), "# Overflow during command execution" },

                { (2,2), "Non-fiscal receipt is open" },
                { (2,3), "EJ nearly full" },
                { (2,4), "Fiscal receipt is open" },
                { (2,5), "EJ is full" },
                { (2,6), "Near paper end" },
                { (2,7), "# End of paper" },

                { (4,1), "Fiscal memory is not found or damaged" },
                { (4,2), "OR of all errors marked with ‘*’ from Bytes 4 и 5" },
                { (4,3), "* Fiscal memory is full" },
                { (4,4), "There is space for less then 60 reports in Fiscal memory" },
                { (4,5), "Serial number and number of FM are set" },
                { (4,6), "Tax number is set" },
                { (4,7), "* Error when trying to access data stored in the FM" },

                { (5,3), "VAT are set at least once" },
                { (5,4), "Device is fiscalized" },
                { (5,6), "FM is formatted" },
            };
    public override Dictionary<(int, int), string>? DefaultDocument => throw new NotImplementedException();

    #endregion Documents
}