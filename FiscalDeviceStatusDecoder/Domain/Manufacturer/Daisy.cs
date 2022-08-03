namespace FiscalDeviceStatusDecoder.Domain;

/// <inheritdoc/>
public sealed class Daisy : BaseManufacturer
{
    private static readonly Lazy<Daisy> lazy = new Lazy<Daisy>(() => new Daisy());

    private Daisy()
    {
    }

    public static Daisy Instance => lazy.Value;

    public override string Name => nameof(Daisy);
    public override Dictionary<(string[], Country), Dictionary<(int, int), string>>? AllModels => new()
    {
        {(Array.Empty<string>(), Country.KZ), Document1! },
    };

    #region Documents

    public Dictionary<(int, int), string> Document1 = new()
            {
                { (0, 2), "OR of all errors with *from bytes 0, 1, 2 – general error" },
                { (0, 3), "* Printing mechanism error" },
                { (0, 4), "No external display" },
                { (0, 5), "Date and time are not set" },
                { (0, 6), "* Invalid command" },
                { (0, 7), "* Syntax error" },

                { (1, 1), "Wrong password" },
                { (1, 2), "Error in cutter" },
                { (1, 5), "Reset memory" },
                { (1, 6), "* Prohibited command in current mode" },
                { (1, 7), "Overflow of sum fields" },

                { (2, 1), "Print of document is allowed" },
                { (2, 2), "Non-fiscal receipt is opened" },
                { (2, 3), "Insufficient free space in EJT" },
                { (2, 4), "Fiscal receipt is opened" },
                { (2, 5), "No EJT free space" },
                { (2, 6), "Not enough paper" },
                { (2, 7), "* No paper" },

                { (3, 1), "Error number 1" },
                { (3, 2), "Error number 2" },
                { (3, 3), "Error number 3" },
                { (3, 4), "Error number 4" },
                { (3, 5), "Error number 5" },
                { (3, 6), "Error number 6" },
                { (3, 7), "Error number 7" },

                { (4, 2), "OR of all errors with*from bytes 4 and 5– general error" },
                { (4, 3), "* Fiscal memory full" },
                { (4, 5), "Invalid record in fiscal memory" },
                { (4, 7), "* Error writing data to fiscal memory" },

                { (5, 2), "MRC is programmed" },
                { (5, 3), "Tax rates are programmed" },
                { (5, 4), "Fiscal device is activated" },
                { (5, 7), "* FM in read-only mode" },
    };
    public override Dictionary<(int, int), string>? DefaultDocument => new()
            {
                { (0, 2), "OR на всички грешки с * от байтове 0, 1, 2 – обща грешка" },
                { (0, 3), "* Грешка на печатащото устройство" },
                { (0, 4), "Няма външен дисплей" },
                { (0, 5), "Не са въведени дата и час" },
                { (0, 6), "* Невалидна команда" },
                { (0, 7), "* Синтактична грешка" },

                { (1, 1), "Грешна парола" },
                { (1, 2), "Грешка в cutter" },
                { (1, 5), "* Нулиран RAM" },
                { (1, 6), "* Неразрешена команда в текущия режим" },
                { (1, 7), "Препълване на някои полета в сумите" },

                { (2, 1), "Разрешен печат на документ" },
                { (2, 2), "Отворен е нефискален бон" },
                { (2, 3), "Малко хартия(контролна лента)" },
                { (2, 4), "Отворен е фискален бон" },
                { (2, 5), "Няма хартия (контролна лента)" },
                { (2, 6), "Малко хартия" },
                { (2, 7), "* Няма хартия" },

                { (3, 1), "Номер грешка на ФУ1" },
                { (3, 2), "Номер грешка на ФУ2" },
                { (3, 3), "Номер грешка на ФУ3" },
                { (3, 4), "Номер грешка на ФУ4" },
                { (3, 5), "Номер грешка на ФУ5" },
                { (3, 6), "Номер грешка на ФУ6" },
                { (3, 7), "Номер грешка на ФУ7" },

                { (4, 1), "Не се използва" },
                { (4, 2), "OR на всички грешки с * от байтове 4 и 5– обща грешка" },
                { (4, 3), "* Пълна ФП" },
                { (4, 4), "Място за по–малко от 50 записа във ФП" },
                { (4, 5), "Грешен запис във ФП" },
                { (4, 6), "Проблем в данъчния терминал" },
                { (4, 7), "* Грешка при запис във ФП" },

                { (5, 1), "Готова ФП" },
                { (5, 2), "Програмирани са инд. номер на ФУ и номер на ФП" },
                { (5, 3), "Зададени данъчни ставки" },
                { (5, 4), "ФУ е въведено в експлоатация" },
                { (5, 5), "* Не се използва" },
                { (5, 6), "Не се използва" },
                { (5, 7), "* Препълнена ФП" },
            };

    #endregion Documents
}