using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient1
{
    class Program
    {
        private static TcpClient _clientSocket;
        private static Stream _nStream;
        private static StreamWriter _sWriter;
        private static StreamReader _sReader;
        static void Main(string[] args)
        {

            
            try
            {

                //loopback IP is 127.0.0.1
                using (_clientSocket = new TcpClient("127.0.0.1", 6789))
                {
                    using (_nStream = _clientSocket.GetStream())
                    {
                        _sWriter = new StreamWriter(_nStream) {AutoFlush = true};
                        Console.WriteLine("Insert your first message: ");
                        var clientMsg = Console.ReadLine();
                        _sWriter.WriteLine(clientMsg);
                        _sReader = new StreamReader(_nStream);
                        var serverMsg = _sReader.ReadLine();
                        Console.WriteLine("Server message: " + serverMsg);
                        while (serverMsg != "End Chat")
                        {
                            clientMsg = Console.ReadLine();
                            _sWriter.WriteLine(clientMsg);
                            //foreach (_sWriter.WriteLine(clientMsg);)
                            //{

                            //}


                            serverMsg = _sReader.ReadLine();
                            Console.WriteLine("Server Message: " + serverMsg);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
