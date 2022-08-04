using FiscalDeviceStatusDecoder.Application;
using FiscalDeviceStatusDecoder.Domain;
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
    public void DecodeToByte_Hex10Numbers_Hex8Numbers(string hex)
    {
        target.DecodeToByte(ref hex);
        Assert.That(hex, Is.EqualTo("80 80 C0 80 80 B8 FF FF"));
    }

    [Test]
    [TestCase("04 80 80 C0 80 80 B8 05 FF FF")]
    [TestCase("048080C08080B805FFFF")]
    [TestCase("80 80 C0 80 80 B8 FF FF")]
    [TestCase("04H 80H 80H C0H 80H 80H B8H 05H FFH FF")]
    public void InitializeStatusDevices_Hex8Numbers_Nothing(string hex)
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
    public void InitializeStatusDevices_Hex_MessagesAboutError(string hex)
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
}