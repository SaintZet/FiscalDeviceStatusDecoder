using FiscalDeviceStatusDecoder.Application.Services;
using FiscalDeviceStatusDecoder.Domain;
using FiscalDeviceStatusDecoder.Presentation;

namespace FiscalDeviceStatusDecoder.Application;

public class MainViewModel : INotifyPropertyChanged
{
    public const string ValidHexMessage = "Valid HEX";

    private string bytes = string.Empty;
    private string hex = string.Empty;
    private string displayStatusInput = string.Empty;
    private List<StatusBit>? statusDevices;

    public MainViewModel()
    {
        Devices = InitializeDevices();
        SelectedDevices = Devices[0];
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public static List<IDeviceModels> Devices { get; private set; } = new List<IDeviceModels>();
    public IDeviceModels SelectedDevices { get; set; }

    public List<StatusBit>? StatusDevices
    {
        get => statusDevices;
        set
        {
            statusDevices = value;
            OnPropertyChanged(nameof(StatusDevices));
        }
    }
    public string DisplayHex
    {
        get => Hex.ToUpper();
        set
        {
            hex = value;
        }
    }

    public string DisplayBytes
    {
        get => $"Status Bytes {Bytes}";
    }

    public string Hex
    {
        get => hex;
        set
        {
            hex = value;
            OnPropertyChanged(nameof(DisplayHex));
        }
    }

    public string Bytes
    {
        get => bytes;
        set
        {
            bytes = value;
            OnPropertyChanged(nameof(DisplayBytes));
        }
    }

    public string DisplayStatusInput
    {
        get => displayStatusInput;
        set
        {
            displayStatusInput = value;
            OnPropertyChanged(nameof(DisplayStatusInput));
        }
    }

    public ICommand DecodeCommand => new RelayCommand(execute: _ => StatusDevices = InitializeStatusDevice(SelectedDevices, hex), canExecute: _ => hex?.Length > 0);

    public string DecodeToByte(ref string hex)
    {
        Hex hexValue = new(hex);

        hexValue.ReduceRange(null, 127);

        hex = Regex.Replace(hexValue.ToString(), ".{2}", "$0 ").Trim();

        return Regex.Replace(hexValue.ConvertToBinary(), ".{8}", "$0 ").Trim();
    }

    public void OnPropertyChanged(string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    public List<StatusBit>? InitializeStatusDevice(IDeviceModels selectedDevices, string hex)
    {
        try
        {
            List<string> bytesArray = SetStatusBytesAndHex(selectedDevices, hex);
            var statusBits = SetStatusDevice(selectedDevices, bytesArray);

            DisplayStatusInput = ValidHexMessage;

            return statusBits;
        }
        catch (Exception ex)
        {
            DisplayStatusInput = ex.Message;

            return null;
        }
    }

    public List<string> SetStatusBytesAndHex(IDeviceModels selectedDevices, string hex)
    {
        string bytes = DecodeToByte(ref hex);

        List<string> hexArray = hex.Split(' ').ToList();
        List<string> bytesArray = bytes.Split(' ').ToList();

        if (bytesArray.Count < selectedDevices.QuantityStatusByte)
        {
            throw new ArgumentException($"For this group device quantity of byte must be minimum {selectedDevices.QuantityStatusByte}!");
        }
        else if (bytesArray.Count > selectedDevices.QuantityStatusByte)
        {
            bytesArray.RemoveFrom(selectedDevices.QuantityStatusByte);
            hexArray.RemoveFrom(selectedDevices.QuantityStatusByte);
        }

        Bytes = string.Join(" ", bytesArray);
        Hex = string.Join(" ", hexArray);

        return bytesArray;
    }

    public List<StatusBit> SetStatusDevice(IDeviceModels selectedDevices, List<string> bytesArray)
    {
        List<StatusBit> status = new();
        var manufacturer = selectedDevices.Manufacturer;
        var statusDocument = manufacturer.GetStatusDocument(selectedDevices.Models, selectedDevices.Country);

        foreach (var keyValuePair in statusDocument)
        {
            var statusByte = bytesArray[keyValuePair.Key.Item1];
            int statusBit = Convert.ToUInt16(char.GetNumericValue(statusByte, keyValuePair.Key.Item2));

            status.Add(new StatusBit(statusBit, keyValuePair.Value));
        }

        return status;
    }

    private static List<IDeviceModels> InitializeDevices() => new List<IDeviceModels>()
        {
            new DeviceModels(Datecs.Instance, 6 , Country.BG , new string[] { "DP-05", "DP-25", "DP-35", "WP-50", "DP-150" }),
            new DeviceModels(Datecs.Instance, 6, Country.BG, new string[] { "FP-800", "FP-2000", "FP-650", "SK1-21F", "SK1-31F", "FMP-10", "FP-700" }),
            new DeviceModels(Datecs.Instance, 8, Country.BG, new string[] { "DP-25X", "DP-05C", "WP-500X", "WP-50X", "FP-700X", "FP-700XR", "FMP-350Xv", "FMP-55X" }),
            new DeviceModels(Datecs.Instance, 8, Country.RO),
            new DeviceModels(Daisy.Instance, 6, Country.BG),
            new DeviceModels(Daisy.Instance, 6, Country.KZ),
            new DeviceModels(Eltrade.Instance, 6, Country.BG),
            new DeviceModels(Tremol.Instance, 7, Country.BG),
            new DeviceModels(Tremol.Instance, 6, Country.KE, new string[] { "CU", "M23" }),
            new DeviceModels(Incotext.Instance, 4, Country.KE),
            new DeviceModels(Port.Instance, 8, Country.RU, new string[] { "150", "600", "1000" }),
            new DeviceModels(Port.Instance, 6, Country.KZ, new string[] { "150" }),
        };
}