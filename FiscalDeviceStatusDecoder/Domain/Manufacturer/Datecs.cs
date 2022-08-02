namespace FiscalDeviceStatusDecoder.Domain;

/// <inheritdoc/>
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
                { (0,2), "Обща грешка - това е OR на всички грешки, маркирани с #" },
                { (0,4), "Не е свързан клиентски дисплей" },
                { (0,5), "Не е сверен часовника" },
                { (0,6), "# Кодът на получената команда е невалиден" },
                { (0,7), "# Получените данни имат синктактична грешка" },

                { (1,1), "Вграденият данъчен терминал не отговаря" },
                { (1,2), "Има неизпратени документи за повече от настроеното време за предупреждение" },
                { (1,5), "Не е сверен часовника" },
                { (1,6), "# Изпълнението на командата не е позволено в текущия фискален режим" },
                { (1,7), "При изпълнение на командата се е получило препълване на някои полета от сумите" },

                { (2,2), "Отворен е служебен бон" },
                { (2,3), "Близък край на КЛЕН (по-малко от 20 MB от КЛЕН свободни)" },
                { (2,4), "Отворен е фискален бон" },
                { (2,5), "Край на КЛЕН (по-малко от 2 MB от КЛЕН свободни)." },
                { (2,7), "# Свършила е хартията" },

                { (4,2), "OR на всички грешки, маркирани с ‘*’ от байтове 4 и 5" },
                { (4,3), "* ФП е пълна" },
                { (4,4), "Има място за по-малко от 50 записа във ФП" },
                { (4,5), "Зададени са индивидуален номер на ФУ и номер на ФП" },
                { (4,6), "Зададен е ЕИК" },
                { (4,7), "Грешка при запис във фискалната памет" },

                { (5,3), "Зададени са поне веднъж данъчните ставки" },
                { (5,4), "ФУ е във фискален режим" },
                { (5,6), "ФП е форматирана" },
            };
    public Dictionary<(int, int), string> Document2 = new()
            {
                { (0,1), "Отворен е капакът на принтера" },
                { (0,2), "Обща грешка - това е OR на всички грешки, маркирани с ‘#’" },
                { (0,3), "# Механизмът на печатащото устройство има неизправност" },
                { (0,4), "Не е свързан клиентски дисплей" },
                { (0,5), "Часовникът не е установен" },
                { (0,6), "# Кодът на получената команда е невалиден" },
                { (0,7), "# Получените данни имат синтактична грешка" },

                { (1,1), "Вграденият данъчен терминал не отговаря" },
                { (1,2), "Отворен е служебен бон за печат на завъртян на 90 градуса текст" },
                { (1,3), "Отворен сторно бон" },
                { (1,4), "# Слаба батерия (Часовникът за реално време е в състояние RESET)" },
                { (1,5), "# Извършено е зануляване на оперативната памет" },
                { (1,6), "# Изпълнението на командата не е позволено в текущия фискален режим" },
                { (1,7), "При изпълнение на командата се е получило препълване на някои полета от сумите.\n" +
                            "Статус 1.1 също ще се установи и командата няма да предизвика промяна на данните в принтера" },

                { (2,1), "Много близък край на КЛЕН (допускат се само определени бонове)" },
                { (2,2), "Отворен е служебен бон" },
                { (2,3), "Близък край на КЛЕН (по-малко от 10 MB от КЛЕН свободни)" },
                { (2,4), "Отворен е фискален бон" },
                { (2,5), "Край на КЛЕН (по-малко от 1 MB от КЛЕН свободни)" },
                { (2,6), "Останала е малко хартия" },
                { (2,7), "# Свършила е хартията. Ако се вдигне този флаг по време на команда, свързана с печат," +
                            "\n то командата е отхвърлена и не е променила състоянието на принтера" },

                { (3,1), "Състояние на Sw7" },
                { (3,2), "Състояние на Sw6" },
                { (3,3), "Състояние на Sw5" },
                { (3,4), "Състояние на Sw4" },
                { (3,5), "Състояние на Sw3" },
                { (3,6), "Състояние на Sw2" },
                { (3,7), "Състояние на Sw1" },

                { (4,1), "Печатащата глава е прегряла" },
                { (4,2), "OR на всички грешки, маркирани с ‘*’ от байтове 4 и 5" },
                { (4,3), "* Фискалната памет е пълна" },
                { (4,4), "Има място за по-малко от 50 записа във ФП" },
                { (4,5), "Зададени са индивидуален номер на принтера и номер на фискалната памет" },
                { (4,6), "Зададен е ЕИК по БУЛСТАТ" },
                { (4,7), "* Има грешка при запис във фискалната памет" },

                { (5,2), "Грешка при четене от фискалната памет" },
                { (5,3), "Зададени са поне веднъж данъчните ставки" },
                { (5,4), "Принтерът е във фискален режим" },
                { (5,5), "* Последният запис във фискалната памет не е успешен" },
                { (5,6), "Фискалната памет е форматирана" },
                { (5,7), "* Фискалната памет е установена в режим READONLY (заключена)" },
            };
    public Dictionary<(int, int), string> Document3 = new()
            {
                { (0,1), "# Cover is open" },
                { (0,2), "General error - this is OR of all errors marked with #" },
                { (0,3), "Failure in printing mechanism" },
                { (0,5), "The real time clock is not synchronized" },
                { (0,6), "# Command code is invalid" },
                { (0,7), "# Syntax error" },

                { (1,6), "# Command is not permitted" },
                { (1,7), "# Overflow during command execution" },

                { (2,2), "Overflow during command execution" },
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
    public override Dictionary<(int, int), string>? DefaultDocument => new()
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

                { (2,2), "Nonfiscal receipt is open" },
                { (2,3), "EJ nearly full" },
                { (2,4), "Fiscal receipt is open" },
                { (2,5), "EJ is full" },
                { (2,6), "Near paper end" },
                { (2,7), "# End of paper" },

                { (4,1), "Fiscal memory is not found or damaged" },
                { (4,2), "OR of all errors marked with ‘*’ from Bytes 4 и 5" },
                { (4,3), "* Fiscal memory is full." },
                { (4,4), "There is space for less then 60 reports in Fiscal memory" },
                { (4,5), "Serial number and number of FM are set" },
                { (4,6), "Tax number is set" },
                { (4,7), "Error when trying to access data stored in the FM" },

                { (5,3), "VAT are set at least once" },
                { (5,4), "Device is fiscalized" },
                { (5,6), "FM is formatted" },
            };

    #endregion Documents
}