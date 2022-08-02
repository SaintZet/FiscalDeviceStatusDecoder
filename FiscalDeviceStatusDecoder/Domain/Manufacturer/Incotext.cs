namespace FiscalDeviceStatusDecoder.Domain;

/// <inheritdoc/>
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
                { (0, 2), "Обща грешка - това е OR на всички грешки, маркирани с ‘#’" },
                { (0, 5), "Часовникът не е установен" },
                { (0, 6), "# Кодът на получената команда е невалиден" },
                { (0, 7), "# В получените данни има синтактична грешка" },

                { (1, 2), "# Поредно въвеждане на 3 грешни пароли" },
                { (1, 4), "# Не е зададен диапазон на броене на брояча на фактурите" },
                { (1, 5), "# Оперативната памет е нулирана" },
                { (1, 6), "# Изпълнението на командата не е позволено" },

                { (2, 2), "Отворен служебен бон" },
                { (2, 4), "Oтворен фискален бон" },
                { (2, 7), "# Край на хартията" },

                { (3, 1), "Грешка на фискалното устройство 1" },
                { (3, 2), "Грешка на фискалното устройство 2" },
                { (3, 3), "Грешка на фискалното устройство 3" },
                { (3, 4), "Грешка на фискалното устройство 4" },
                { (3, 5), "Грешка на фискалното устройство 5" },
                { (3, 6), "Грешка на фискалното устройство 6" },
                { (3, 7), "Грешка на фискалното устройство 7" },
    };

    #endregion Documents
}