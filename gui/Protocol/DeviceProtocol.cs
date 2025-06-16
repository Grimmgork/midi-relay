using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace gui.Protocol
{
    public class DeviceProtocol : IDisposable
    {
        private SerialPort serial;

        private DeviceProtocol(string port, int timeout)
        {
            serial = new SerialPort(port, 31250, Parity.None, 8, StopBits.One);
            serial.WriteTimeout = timeout;
            serial.ReadTimeout = timeout;
        }

        public static DeviceProtocol Connect(string port, int timeout = 1000)
        {
            DeviceProtocol connector = new DeviceProtocol(port, timeout);
            connector.serial.Open();
            return connector;
        }

        private void SendMessage(DeviceMessage message)
        {
            serial.Write(new byte[] { message.Command, (byte)message.Length }, 0, 2);
            serial.Write(message.Content, 0, message.Length);
        }

        private DeviceMessage ReadMessage()
        {
            byte cmd = (byte)serial.ReadByte();
            byte length = (byte)serial.ReadByte();
            byte[] buffer = new byte[length];
            for (int i = 0; i < length; i++)
            {
                buffer[i] = (byte)serial.ReadByte();
            }
            return new DeviceMessage(cmd, buffer);
        }

        private DeviceMessage Request(DeviceMessage request)
        {
            serial.DiscardInBuffer();
            SendMessage(request);
            return ReadMessage();
        }

        public void UpdateButtonSequence(byte index, params byte[] sequence)
        {
            byte[] content = (new byte[] { index }).Concat(sequence).ToArray();
            DeviceMessage res = Request(new DeviceMessage(0x30, content));
            if (res.Command != 0x06)
                throw new Exception();
        }

        public byte[] ReadButtonSequence(byte index)
        {
            DeviceMessage res = Request(new DeviceMessage(0x31, index));
            if (res.Command == 0x06)
                return res.Content;

            throw new Exception();
        }

        public IEnumerable<byte[]> ReadAllButtonSequences()
        {
            byte i = 0;
            List<byte[]> result = new List<byte[]>();
            while (true)
            {
                DeviceMessage res = Request(new DeviceMessage(0x31, i));
                if (res.Command != 0x06)
                    break;

                result.Add(res.Content);
                i++;
            }
            return result;
        }

        public void Ping()
        {
            DeviceMessage res = Request(new DeviceMessage(0x33));
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
