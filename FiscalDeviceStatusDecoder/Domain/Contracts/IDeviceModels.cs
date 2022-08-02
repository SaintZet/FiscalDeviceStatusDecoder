namespace FiscalDeviceStatusDecoder.Domain;

/// <summary>
/// Basic information about the group of fiscal machines.
/// </summary>
public interface IDeviceModels
{
    BaseManufacturer Manufacturer { get; }
    string[] Models { get; }
    int QuantityStatusByte { get; }
    Country Country { get; }
    string DisplayInformation { get; }
}