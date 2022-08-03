namespace FiscalDeviceStatusDecoder.Domain;

public interface IMessageBox
{
    void ShowMessage(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon);
}