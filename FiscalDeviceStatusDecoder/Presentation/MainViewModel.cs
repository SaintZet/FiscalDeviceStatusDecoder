using FiscalDeviceStatusDecoder.Application;
using FiscalDeviceStatusDecoder.Domain;
using FiscalDeviceStatusDecoder.Presentation.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace FiscalDeviceStatusDecoder.Presentation;

internal class MainViewModel : INotifyPropertyChanged
{
    private string bytes = string.Empty;
    private string hex = string.Empty;

    private ObservableCollection<StatusBit> statusDevice = new();

    public MainViewModel()
    {
        Devices = InitializeDevices();
        SelectedDevices = Devices[0];
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<StatusBit> StatusDevice
    {
        get => statusDevice;
        set
        {
            statusDevice = value;
            OnPropertyChanged(nameof(StatusDevice));
        }
    }
    public ObservableCollection<DeviceModels> Devices { get; set; }

    public DeviceModels SelectedDevices { get; set; }
    public string HEX
    {
        get => hex;
        set
        {
            hex = value;
            OnPropertyChanged(nameof(HEX));
        }
    }
    public string Bytes
    {
        get => bytes;
        set
        {
            bytes = value;
            OnPropertyChanged(nameof(Bytes));
        }
    }

    public ICommand DecodeCommand => new RelayCommand(execute: Decode, canExecute: _ => HEX?.Length > 0);

    public void OnPropertyChanged(string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    private void Decode(object _)
    {
        Hex hexValue = new(hex);

        hexValue.ReduceRange(null, 127);
        bytes = hexValue.ConvertToBinary();

        HEX = Regex.Replace(hexValue.ToString(), ".{2}", "$0 ");
        Bytes = Regex.Replace(bytes, ".{8}", "$0 ");

        var manufacturer = SelectedDevices.Manufacturer;
        var statusDocument = manufacturer.GetStatusDocument(SelectedDevices.Models, SelectedDevices.Country);
        StatusDevice = InitializeStatusDevice(statusDocument);
    }

    private ObservableCollection<StatusBit> InitializeStatusDevice(Dictionary<(int, int), string> statusDocument)
    {
        ObservableCollection<StatusBit> status = new ObservableCollection<StatusBit>();

        string[] bytes = Bytes.Split(' ');

        foreach (var keyValuePair in statusDocument)
        {
            var statusByte = bytes[keyValuePair.Key.Item1];
            int statusBit = Convert.ToUInt16(char.GetNumericValue(statusByte, keyValuePair.Key.Item2));
            status.Add(new StatusBit(statusBit, keyValuePair.Value));
        }
        return status;
    }

    private ObservableCollection<DeviceModels> InitializeDevices() => new ObservableCollection<DeviceModels>()
        {
            new DeviceModels(Datecs.Instance, 6 , Country.BG , new string[] { "DP-05", "DP-25", "DP-35", "WP-50", "DP-150" }),
            new DeviceModels(Datecs.Instance, 6, Country.BG, new string[] { "FP-800", "FP-2000", "FP-650", "SK1-21F", "SK1-31F", "FMP-10", "FP-700" }),
            new DeviceModels(Datecs.Instance, 8, Country.BG, new string[] { "DP-25X", "DP-05C", "WP-500X", "WP-50X", "FP-700X", "FP-700XR", "FMP-350Xv", "FMP-55X" }),
            new DeviceModels(Datecs.Instance, 8, Country.RO),
            new DeviceModels(Daisy.Instance, 6, Country.BG),
            new DeviceModels(Eltrade.Instance, 6, Country.BG),
            new DeviceModels(Tremol.Instance, 2, Country.BG),
            new DeviceModels(Tremol.Instance, 2, Country.KE, new string[] { "CU", "M23" }),
            new DeviceModels(Incotext.Instance, 6, Country.KE),
            new DeviceModels(Port.Instance, 6, Country.RU, new string[] { "150", "600", "1000" }),
            new DeviceModels(Port.Instance, 8, Country.KZ, new string[] { "150" }),
        };
}