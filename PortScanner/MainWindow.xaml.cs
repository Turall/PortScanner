using System.Collections.Generic;
using System.Windows;


namespace PortScanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Ports> portsInfo = Ports.GetPortInfo();
            ScanVieweer.ItemsSource = portsInfo;
        }
    }
}
