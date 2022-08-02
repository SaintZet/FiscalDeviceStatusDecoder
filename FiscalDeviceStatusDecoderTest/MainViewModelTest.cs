using FiscalDeviceStatusDecoder.Domain;
using FiscalDeviceStatusDecoder.Presentation;

namespace FiscalDeviceStatusDecoderTest;

public class MainViewModelTest
{
    private MainViewModel target;

    [SetUp]
    public void Setup()
    {
        target = new();
    }

    [Test]
    [TestCase("04 80 80 C0 80 80 B8 05 FF")]
    [TestCase("048080C08080B805FF")]
    [TestCase("80 80 C0 80 80 B8 FF")]
    [TestCase("04H 80H 80H C0H 80H 80H B8H 05H FFH")]
    public void InitializeStatusDevices_Hex7Numbers_Nothing(string hex)
    {
        foreach (var devices in target.Devices)
        {
            target.InitializeStatusDevices(devices, hex);
        }
    }

    [Test]
    [TestCase("04 80 80 C0 80 80 B8 05 FF", "048080C08080B805FF")]
    [TestCase("04 80 80 C0 80 80 B8 05 FF", "80 80 C0 80 80 B8 FF")]
    [TestCase("04 80 80 C0 80 80 B8 05 FF", "04H 80H 80H C0H 80H 80H B8H 05H FFH")]
    public void InitializeStatusDevices_Hex7Numbers_EqualsStatusBit(string hex1, string hex2)
    {
        // arrange
        List<List<StatusBit>> statusBits1 = new();
        List<List<StatusBit>> statusBits2 = new();

        // act
        foreach (var devices in target.Devices)
        {
            statusBits1.Add(target.InitializeStatusDevices(devices, hex1));
        }
        foreach (var devices in target.Devices)
        {
            statusBits2.Add(target.InitializeStatusDevices(devices, hex2));
        }

        // assert
        for (int i = 0; i < target.Devices.Count; i++)
        {
            CollectionAssert.AreEquivalent(statusBits1[i], statusBits2[i]);
        }
    }
}