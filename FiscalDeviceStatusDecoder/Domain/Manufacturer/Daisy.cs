﻿namespace FiscalDeviceStatusDecoder.Domain;

/// <inheritdoc/>
public sealed class Daisy : BaseManufacturer
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