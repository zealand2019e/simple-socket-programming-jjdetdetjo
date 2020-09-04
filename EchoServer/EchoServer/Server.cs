using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace EchoServer
{
    class Server
    {
        public void Start()
        {
            TcpListener serverSocket = new TcpListener(IPAddress.Loopback, 7777);

            serverSocket.Start();
            TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            Console.WriteLine("server activated");


            Stream ns = connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);

            StreamWriter sw = new StreamWriter(ns);

            sw.AutoFlush = true; // enable automatic flushing 



            string message = sr.ReadLine();

            Console.WriteLine("received message: " + message);
            if (message != null)
            {
                sw.WriteLine(message.ToUpper());
            }
            ns.Close();
            Console.WriteLine("net stream closed");
            connectionSocket.Close();
            Console.WriteLine("connection socket closed");
            serverSocket.Stop();
            Console.WriteLine("server stopped");


        }
    }
}
