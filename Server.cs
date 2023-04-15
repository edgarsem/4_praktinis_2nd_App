using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _4_praktinis_2nd_App
{
    internal class Server
    {
        public static String startServer(String clientData)
        {

            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);

            Socket listener = new Socket(ipAddr.AddressFamily,
                         SocketType.Stream, ProtocolType.Tcp);

            string data = null;
            try
            {

                listener.Bind(localEndPoint);
                listener.Listen(10);

                while (true)
                {

                    Console.WriteLine("Waiting connection ... ");
                    Socket clientSocket = listener.Accept();

                    byte[] bytes = new Byte[1024];
                    
                    while (true)
                    {
                        int numByte = clientSocket.Receive(bytes);

                        data += Encoding.ASCII.GetString(bytes, 0, numByte);

                        if (data.IndexOf("<| EOM |>") > -1)
                            break;
                    }
                    Console.WriteLine("Text received -> {0} ", data);

                    byte[] message;


                    if (data == "<DATA_REQUEST><| EOM |>")
                    {
                        message = Encoding.ASCII.GetBytes(clientData);
                        data = clientData;
                    }
                    else
                    {
                        message = Encoding.ASCII.GetBytes("Message received!");
                        data = data.Substring(0, data.Length - 9);
                    }
                    clientSocket.Send(message);
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                    return data;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return "";
        }
    }
}
