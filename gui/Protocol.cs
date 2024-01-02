using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui
{
    public class Message
    {
        public byte Command { get; set; }
        public byte[] Content { get; set; }
        public Message(byte command, params byte[] content)
        {
            Command = command;
            Content = content;
        }
    }

    public class Protocol : IDisposable
    {
        private SerialPort serial;

        public Protocol(string port, int timeout = 1000)
        {
            serial = new SerialPort(port, 31250, Parity.None, 8, StopBits.One);
            serial.WriteTimeout = timeout;
            serial.ReadTimeout = timeout;
        }

        public void Start()
        {
            serial.Open();
        }

        private void SendRequest(Message message)
        {
            serial.Write(new byte[] { message.Command, (byte)message.Content.Length }, 0, 2);
            serial.Write(message.Content, 0, message.Content.Length);
        }

        private Message ReadResponse()
        {
            byte cmd = (byte)serial.ReadByte();
            byte length = (byte)serial.ReadByte();
            byte[] buffer = new byte[length];
            for (int i = 0; i < length; i++)
            {
                buffer[i] = (byte)serial.ReadByte();
            }
            return new Message(cmd, buffer);
        }

        public Message Command(Message request)
        {
            SendRequest(request);
            List<Message> responses = new List<Message>();
            while(true)
            {
                responses.Add(ReadResponse());
                if (serial.BytesToRead == 0)
                    break;
            }

            return responses.Last();
        }

        public void Ping()
        {
            Message res = Command(new Message(0x33));
            if (res.Command == 0x06)
                return;
            throw new Exception("invalid response!");
        }

        public void Dispose()
        {
            serial.Close();
        }
    }
}
