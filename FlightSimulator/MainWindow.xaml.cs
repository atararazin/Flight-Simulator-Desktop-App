using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FlightSimulator.Model;
using FlightSimulator.Views.Windows;


namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Window settingsWin = new SettingsWindow();
            settingsWin.Show();
        }
        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            /*Task taskClient = new Task(() => {
                int port = Properties.Settings.Default.FlightCommandPort;
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5402);
                TcpClient client = new TcpClient();
                client.Connect(ep);
                Console.WriteLine("You are connected");
                NetworkStream stream = client.GetStream();
                BinaryWriter writer = new BinaryWriter(stream);
                writer.Write("set controls/flight/rudder 1");
                Console.Write("send to server");
                client.Close();
            });*/

            Task taskServer = new Task(() => {
                Console.WriteLine("in the second task.");
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5400);
                TcpListener listener = new TcpListener(ep);
                listener.Start();
                Console.WriteLine("Waiting for client connections...");
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Client connected");
                using (NetworkStream stream = client.GetStream())
                using (BinaryReader reader = new BinaryReader(stream))
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    Console.WriteLine("getting stuff from client");
                    string num = reader.ReadString();
                    Console.WriteLine(num);
                    writer.Flush();
                }
                client.Close();
                listener.Stop();
            });

            Console.WriteLine("Starting task 1...");
            //taskClient.Start();
            Console.WriteLine("Starting task 2...");
            taskServer.Start();

            Console.WriteLine("Waiting to complete task1...");
            // taskClient.Wait();
            Console.WriteLine("Waiting to complete task2...");
            taskServer.Wait();

            Console.WriteLine("Task 1 done.");
            Console.WriteLine("Task 2 done.");
        }
    }
}