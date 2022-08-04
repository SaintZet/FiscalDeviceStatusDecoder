using FiscalDeviceStatusDecoder.Domain;

namespace FiscalDeviceStatusDecoder.Presentation.Services
{
    internal class MessageBox : IMessageBox
    {
        public void ShowMessage(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            System.Windows.MessageBox.Show(messageBoxText, caption, button, icon);
        }
    }
}