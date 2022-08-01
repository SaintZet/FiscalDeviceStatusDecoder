namespace FiscalDeviceStatusDecoder.Domain;

internal interface IDeviceModels
{
    BaseManufacturer Manufacturer { get; }
    string[] Models { get; }
    int QuantityByte { get; }
    Country Country { get; }
    string DisplayInformation { get; }
}