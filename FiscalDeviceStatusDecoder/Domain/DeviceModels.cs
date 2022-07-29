namespace FiscalDeviceStatusDecoder.Domain
{
    public class DeviceModels : IDeviceModels
    {
        public DeviceModels(Manufacturer manufacturer, int quantityByte, Country country, string[]? models = null)
        {
            Manufacturer = manufacturer;
            Models = models ?? System.Array.Empty<string>();
            QuantityByte = quantityByte;
            Country = country;

            DisplayInformation = $"{Manufacturer} {string.Join("/", Models)} ({QuantityByte} {Country})";
        }

        public Manufacturer Manufacturer { get; }
        public string[] Models { get; }
        public int QuantityByte { get; }
        public Country Country { get; }
        public string DisplayInformation { get; }
    }
}