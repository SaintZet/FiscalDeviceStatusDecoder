namespace FiscalDeviceStatusDecoder.Domain;

internal class DeviceModels : IDeviceModels
{
    public DeviceModels(BaseManufacturer manufacturer, int quantityByte, Country country, string[]? models = null)
    {
        Manufacturer = manufacturer;
        Models = models ?? System.Array.Empty<string>();
        QuantityByte = quantityByte;
        Country = country;

        DisplayInformation = $"{Manufacturer.Name} {string.Join("/", Models)} ({QuantityByte} {Country})";
    }

    public BaseManufacturer Manufacturer { get; }
    public string[] Models { get; }
    public int QuantityByte { get; }
    public Country Country { get; }
    public string DisplayInformation { get; }
}