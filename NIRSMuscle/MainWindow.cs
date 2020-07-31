using System;
using Gtk;
using System.Net.Sockets;
using System.Text;

public partial class MainWindow : Gtk.Window
{
    UdpClient udpClient;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();

        udpClient = new UdpClient(2390);
        udpClient.Connect("10.0.0.1",2390);


     //   Byte[] sendBytes = Encoding.ASCII.GetBytes("Is anybody there?");
     //   udpClient.Send(sendBytes, sendBytes.Length);
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
}
