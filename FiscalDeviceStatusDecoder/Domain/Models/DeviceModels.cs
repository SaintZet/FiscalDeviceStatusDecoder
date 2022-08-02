namespace FiscalDeviceStatusDecoder.Domain;

/// <summary>
/// Basic information about the group of fiscal machines.
/// </summary>
internal class DeviceModels : IDeviceModels
{
    public DeviceModels(BaseManufacturer manufacturer, int quantityByte, Country country, string[]? models = null)
    {
        Manufacturer = manufacturer;
        Models = models ?? System.Array.Empty<string>();
        QuantityStatusByte = quantityByte;
        Country = country;

        DisplayInformation = $"{Manufacturer.Name} {string.Join("/", Models)} ({QuantityStatusByte} {Country})";
    }

    public BaseManufacturer Manufacturer { get; }
    public string[] Models { get; }
    public int QuantityStatusByte { get; }
    public Country Country { get; }
    public string DisplayInformation { get; }
}