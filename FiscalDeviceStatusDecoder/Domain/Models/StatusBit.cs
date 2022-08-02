namespace FiscalDeviceStatusDecoder.Domain;

public record struct StatusBit
{
    public StatusBit(int status, string name)
    {
        Name = name;
        Status = status;
    }

    public string Name { get; set; }
    public int Status { get; set; }
}