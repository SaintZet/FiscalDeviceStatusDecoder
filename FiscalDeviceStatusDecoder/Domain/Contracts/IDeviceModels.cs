namespace FiscalDeviceStatusDecoder.Domain
{
    public interface IDeviceModels
    {
        Manufacturer Manufacturer { get; }
        string[] Models { get; }
        int QuantityByte { get; }
        Country Country { get; }
        string DisplayInformation { get; }
    }
}