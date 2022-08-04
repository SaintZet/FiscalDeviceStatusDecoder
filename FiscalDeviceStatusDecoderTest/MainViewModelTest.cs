using FiscalDeviceStatusDecoder.Application;
using FiscalDeviceStatusDecoder.Domain;
using NSubstitute;
using NUnit.Framework;
using System.Windows;

namespace FiscalDeviceStatusDecoderTest;

internal class MessageBox : IMessageBox
{
    internal int CountMessage;

    public void ShowMessage(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon)
    {
        CountMessage++;
    }
}

public class MainViewModelTest
{
    private MainViewModel target;
    private MessageBox messageBox;

    [SetUp]
    public void Setup()
    {
        messageBox = new();
        target = new(messageBox);
    }

    [Test]
    [TestCase("04 80 80 C0 80 80 B8 05 FF FF")]
    [TestCase("048080C08080B805FFFF")]
    [TestCase("04H 80H 80H C0H 80H 80H B8H 05H FFH FF")]
    public void DecodeToByte_VariousNumbers_OneFormar(string hex)
    {
        target.DecodeToByte(ref hex);
        Assert.That(hex, Is.EqualTo("80 80 C0 80 80 B8 FF FF"));
    }

    [Test]
    [TestCase("04 80 80 C0 80 80 B8 05 FF FF")]
    [TestCase("048080C08080B805FFFF")]
    [TestCase("04H 80H 80H C0H 80H 80H B8H 05H FFH FF")]
    public void InitializeStatusDevices_VariousHex_OneFormatHex(string hex)
    {
        target.InitializeStatusDevice(target.SelectedDevices, hex);

        Assert.That(target.DisplayHex, Is.EqualTo("80 80 C0 80 80 B8"));
    }

    [Test]
    [TestCase("04 80 80 C0 80 80 B8 05 FF FF")]
    [TestCase("048080C08080B805FFFF")]
    [TestCase("80 80 C0 80 80 B8 FF FF")]
    [TestCase("04H 80H 80H C0H 80H 80H B8H 05H FFH FF")]
    public void InitializeStatusDevices_HexALotOfNumbers_Nothing(string hex)
    {
        foreach (var devices in MainViewModel.Devices)
        {
            target.InitializeStatusDevice(devices, hex);
        }
    }

    [Test]
    [TestCase("04 80 80 C0 80 80 B8 05 FF FF", "048080C08080B805FFFF")]
    [TestCase("04 80 80 C0 80 80 B8 05 FF FF", "80 80 C0 80 80 B8 FF FF")]
    [TestCase("04 80 80 C0 80 80 B8 05 FF FF", "04H 80H 80H C0H 80H 80H B8H 05H FFH FF")]
    public void InitializeStatusDevices_Hex8Numbers_EqualsStatusBit(string hex1, string hex2)
    {
        // arrange
        List<List<StatusBit>> statusBits1 = new();
        List<List<StatusBit>> statusBits2 = new();

        // act
        foreach (var devices in MainViewModel.Devices)
        {
            statusBits1.Add(target.InitializeStatusDevice(devices, hex1)!);
        }
        foreach (var devices in MainViewModel.Devices)
        {
            statusBits2.Add(target.InitializeStatusDevice(devices, hex2)!);
        }

        // assert
        for (int i = 0; i < MainViewModel.Devices.Count; i++)
        {
            CollectionAssert.AreEquivalent(statusBits1[i], statusBits2[i]);
        }
    }

    [Test]
    [TestCase("80 ")]
    [TestCase("80 80")]
    [TestCase("80 80 80 80")]
    [TestCase("80 80 80 80 80 80 80 80")]
    [TestCase("80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80")]
    public void InitializeStatusDevices_HexLessNumber_MessagesAboutError(string hex)
    {
        // arrange
        int countErrorForInvalidHex = 0;

        // act
        foreach (var devices in MainViewModel.Devices)
        {
            string[] bytesArray = target.DecodeToByte(ref hex).Split(' ');
            countErrorForInvalidHex += bytesArray.Length < devices.QuantityStatusByte ? 1 : 0;

            target.InitializeStatusDevice(devices, hex);
        }
        // assert
        Assert.That(messageBox.CountMessage, Is.EqualTo(countErrorForInvalidHex));
    }

    [Test]
    [TestCase("04 80 80 C0 80 80 B8 05 FF FF")]
    [TestCase("048080C08080B805FFFF")]
    [TestCase("04H 80H 80H C0H 80H 80H B8H 05H FFH FF")]
    public void InitializeStatusDevices_HexAndInvalidModels_MessagesAboutError(string hex)
    {
        // arrange
        int countErrorForInvalidHex = 0;

        // act
        foreach (var devices in MainViewModel.Devices)
        {
            var mock = Substitute.For<DeviceModels>(devices.Manufacturer, devices.QuantityStatusByte, devices.Country, new string[] { "INVALID_MODELS" });
            countErrorForInvalidHex++;

            target.InitializeStatusDevice(mock, hex);
        }

        // assert
        Assert.That(messageBox.CountMessage, Is.EqualTo(countErrorForInvalidHex));
    }

    [Test]
    [TestCase("04 80 80 C0 80 80 B8 05 FF FF")]
    [TestCase("048080C08080B805FFFF")]
    [TestCase("04H 80H 80H C0H 80H 80H B8H 05H FFH FF")]
    public void SetStatusBytesAndHex_Hex10Numbers_CorrectQuantityBytes(string hex)
    {
        target.SetStatusBytesAndHex(target.SelectedDevices, hex);
        List<string> bytesArray = target.Bytes.Split(' ').ToList();

        Assert.That(bytesArray.Count, Is.EqualTo(target.SelectedDevices.QuantityStatusByte));
    }

    [Test]
    [TestCase("04 80 80 C0 80 80 B8 05 FF FF")]
    [TestCase("048080C08080B805FFFF")]
    [TestCase("04H 80H 80H C0H 80H 80H B8H 05H FFH FF")]
    public void SetStatusBytesAndHex_Hex10Numbers_CorrectDisplayStringBytes(string hex)
    {
        target.SetStatusBytesAndHex(target.SelectedDevices, hex);

        Assert.True(target.DisplayBytes.Contains(target.Bytes));
    }

    [Test]
    [TestCase("04 80 80 C0 80 80 B8 05 FF FF")]
    [TestCase("048080C08080B805FFFF")]
    [TestCase("04H 80H 80H C0H 80H 80H B8H 05H FFH FF")]
    public void SetStatusBytesAndHex_Hex10Numbers_CorrectQuantityHex(string hex)
    {
        target.SetStatusBytesAndHex(target.SelectedDevices, hex);
        List<string> bytesHex = target.Hex.Split(' ').ToList();

        Assert.That(bytesHex.Count, Is.EqualTo(target.SelectedDevices.QuantityStatusByte));
    }

    [Test]
    [TestCase("04 80 80 C0 80 80 B8 05 FF FF")]
    [TestCase("048080C08080B805FFFF")]
    [TestCase("04H 80H 80H C0H 80H 80H B8H 05H FFH FF")]
    public void SetStatusBytesAndHex_Hex10Numbers_CorrectDisplayStringHex(string hex)
    {
        int qttyByte = target.SelectedDevices.QuantityStatusByte;
        int qttyByteWithSeparator = (qttyByte * 2) + (qttyByte - 1);

        target.SetStatusBytesAndHex(target.SelectedDevices, hex);

        Assert.That(target.DisplayHex.Length, Is.EqualTo(qttyByteWithSeparator));
    }
}