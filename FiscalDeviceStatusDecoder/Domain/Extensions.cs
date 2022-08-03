namespace FiscalDeviceStatusDecoder.Domain;

internal static class Extensions
{
    public static void RemoveFrom<T>(this List<T> lst, int from)
    {
        lst.RemoveRange(from, lst.Count - from);
    }
}