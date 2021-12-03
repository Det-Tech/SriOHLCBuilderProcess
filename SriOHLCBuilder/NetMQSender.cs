using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;
namespace SriOHLCBuilder
{
	public class NetMQSender
	{
        private const int DISCONNECTED = -1;

        private readonly PublisherSocket publisher;
        private int port;
        public NetMQSender()
        {
            publisher = new PublisherSocket();
            port = DISCONNECTED;
        }

        /// <summary>
        /// Start publisher on specified port
        /// </summary>
        /// <param name="port">Port to publish message</param>
        public void Start(string ip, int port)
        {
            try
			{
                this.port = port;
                publisher.Bind($"tcp://{ip}:{port}");
            }
            catch
			{

			}
        }

        /// <summary>
        /// Send broadcast message
        /// </summary>
        /// <param name="msg">message to be sent</param>
        public void SendMessage(string msg)
        {
            lock(this)
			{
                if (port == DISCONNECTED)
                    return;
                publisher.SendMoreFrame("OHLCBuilder").SendFrame(msg);
            }
        }

        /// <summary>
        /// Stop sending broadcast messsage
        /// </summary>
        public void Stop()
        {
            publisher.Close();
            port = DISCONNECTED;
        }

        /// <summary>
        /// Dispose and release all resource
        /// </summary>
        public void Dispose()
        {
            publisher?.Dispose();
        }
    }
}
