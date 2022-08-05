namespace FiscalDeviceStatusDecoder.Application.Services;

public class Hex
{
    private string Value;

    public Hex(string value)
    {
        value = value.Replace("  ", "");
        value = value.Replace(" ", "");
        value = new Regex("[^a-fA-F0-9 -]").Replace(value, "");

        Value = value;
    }

    /// <summary>
    /// </summary>
    /// <param name="separator"> Every 4 characters </param>
    /// <returns> </returns>
    public string ConvertToBinary(string separator = "") =>
        string.Join(separator, Value.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

    public void ReduceRange(int? lessThan = null, int? moreThan = null)
    {
        bool _ = Value.Length % 2 == 0 ? true : throw new ArgumentException($"You must write HEX number!");

        List<string> validHexNumbers = new List<string>();

        for (int i = 0; i < Value.Length; i += 2)
        {
            string hexNumber = Value[i].ToString() + Value[i + 1].ToString();

            int decNum = Convert.ToInt32(hexNumber, 16);

            if (lessThan != null && decNum < lessThan)
            {
                validHexNumbers.Add(hexNumber);
            }

            if (moreThan != null && decNum > moreThan)
            {
                validHexNumbers.Add(hexNumber);
            }
        }

        Value = string.Join("", validHexNumbers);
    }

    public override string ToString() => Value;
}