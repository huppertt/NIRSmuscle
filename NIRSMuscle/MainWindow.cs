using System;
using Gtk;
using System.Net.Sockets;
using System.Text;

public partial class MainWindow : Gtk.Window
{
    UdpClient udpClient;
    bool isrunning;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();

        udpClient = new UdpClient(2390);
        udpClient.Connect("10.0.0.1",2390);
        isrunning = false;



     //   Byte[] sendBytes = Encoding.ASCII.GetBytes("Is anybody there?");
     //   udpClient.Send(sendBytes, sendBytes.Length);
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void ClickedStart(object sender, EventArgs e)
    {

        if (!isrunning)
        {
            Byte[] sendBytes = Encoding.ASCII.GetBytes("Start");
            udpClient.Send(sendBytes, sendBytes.Length);
            isrunning = true;
            buttonStart.Label = "Stop";
        }
        else
        {
            Byte[] sendBytes = Encoding.ASCII.GetBytes("Stop");
            udpClient.Send(sendBytes, sendBytes.Length);
            isrunning = false;
            buttonStart.Label = "Start";
        }


    }

    protected void LED660changed(object sender, EventArgs e)
    {
        int val = (int)spinbutton1.Value;

        Byte[] sendBytes = Encoding.ASCII.GetBytes(String.Format("LED1 [0]",val));
        udpClient.Send(sendBytes, sendBytes.Length);
    }

    protected void LED850changed(object sender, EventArgs e)
    {
        int val = (int)spinbutton3.Value;

        Byte[] sendBytes = Encoding.ASCII.GetBytes(String.Format("LED2 [0]", val));
        udpClient.Send(sendBytes, sendBytes.Length);

    }
}
