using OPC_DA_Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OpcUA_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OPC_UA_Client OPC_UA;
        public MainWindow()
        {
            InitializeComponent();
            ListOfItemsOPC listOfItemsOPC = new ListOfItemsOPC();
            OPC_UA = new OPC_UA_Client("192.168.8.227", 5000d, listOfItemsOPC.GetOPCitems());
            OPC_UA.ItemsChanged += OPC_UA_ItemsChanged;
        }
        private async Task Task()
        {                      
            await OPC_UA.SetChanel();
        }

        
        private void OPC_UA_ItemsChanged(Dictionary<string, string> itemDict)
        {
            //textBox.Text = itemDict["Application.PLC_PRG.val10"];
            Dispatcher.Invoke(() =>
            {
                textBox.Text = itemDict["Application.PLC_PRG.val10"];
            });
        }

        private async void Window_Loaded(object sender, EventArgs e)
        {
            
            
            
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            await Task();
        }
    }
}
