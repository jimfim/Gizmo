using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Robot
{
    public class CommandServer : IHostedService
    {
        private readonly IMotorController _motorController;
        private readonly IPacketParser _packetParser;
        private const int listenPort = 11000;

        public CommandServer(IMotorController motorController, IPacketParser packetParser)
        {
            _motorController = motorController;
            _packetParser = packetParser;
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);

            try
            {
                Console.WriteLine("Waiting for broadcast");
                while (true)
                {
                    byte[] bytes = listener.Receive(ref groupEP);
                    var payload = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    var vector = _packetParser.Convert(payload);
                    _motorController.Move(vector);
                    //vector.Dump();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                listener.Close();
            }
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            return Task.CompletedTask;
        }
    }
}