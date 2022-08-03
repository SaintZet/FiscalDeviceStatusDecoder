using FiscalDeviceStatusDecoder.Presentation;

namespace FiscalDeviceStatusDecoder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(new Presentation.Services.MessageBox());
        }
    }
}