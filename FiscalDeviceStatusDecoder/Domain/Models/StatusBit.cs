namespace FiscalDeviceStatusDecoder.Domain;

internal class StatusBit
{
    internal StatusBit(int status, string name)
    {
        Name = name;
        Status = status;
    }

    public string Name { get; set; }
    public int Status { get; set; }
}