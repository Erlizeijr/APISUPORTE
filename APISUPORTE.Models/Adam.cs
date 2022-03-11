//using GLib;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Sockets;
//using System.Text;
//using System.Threading.Tasks;
//using VisioForge.MediaFramework.ONVIF;
//using System.Threading;
//using Thread = GLib.Thread;

//namespace APISUPORTE.Models
//{
//    public class Adam
//    {
//        private static readonly int TotalDigitalInputChannels = DigitalInput.GetChannelTotal(Adam6000Type.Adam6052);
//        private static readonly int TotalDigitalOutputChannels = DigitalOutput.GetChannelTotal(Adam6000Type.Adam6052);
//        private const int IdSartForInputChanel = 1;
//        private const int IdSartForOutputChannel = 17;
//        private bool m_bStart;
//        private int m_iDoTotal, m_iDiTotal;
//        private int m_iPort;
//        private string m_szIP;
//        private AdamSocket adamModbus;

//        private static readonly int TotalDigitalImputChannels = DigitalInput.GetChannelTotal(Adam6000Type.Adam6052);
//        public void initControl(string IpAdam, int Port)
//        {
//            m_bStart = false;  // the action stops at the beginning
//            m_szIP = IpAdam;   // modbus slave IP address
//            m_iPort = Port;               // modbus TCP port is 502
//            adamModbus = new AdamSocket();
//            adamModbus.SetTimeout(1000, 1000, 1000); // set timeout for TCP
//            m_iDoTotal = 7;
//            m_iDiTotal = 7;
//        }

//        public bool WriteOutputChannel(int channel, bool val)
//        {
//            var res = false;

//            if (adamModbus.Connect(m_szIP, ProtocolType.Tcp, m_iPort))
//            {
//                var modbus = adamModbus.Modbus();
//                res = modbus.ForceSingleCoil(IdSartForOutputChannel + channel, val);
//                adamModbus.Disconnect();
//                return res;
//            }
//            else
//            {
//                adamModbus.Disconnect();
//                // MessageBox.Show("Error al Escribir en la OUTPUT ADAM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//            return res;
//        }

//        public bool WriteOutputChannelWithCheck(string IpAdam, int Port, int channel, bool val)
//        {
//            IpAdam = IpAdam.Replace(" ", "");
//            initControl(IpAdam, Port);

//            var res = false;
//            bool[] digitalOutputChannels = null;
//            if (adamModbus.Connect(m_szIP, ProtocolType.Tcp, m_iPort))
//            {
//                var modbus = adamModbus.Modbus();
//                res = modbus.ForceSingleCoil(IdSartForOutputChannel + channel, val);
//                //await Task.Delay(5000); //pause de 2 segundos
//                Thread.Sleep(1500);
//                digitalOutputChannels = null;
//                digitalOutputChannels = ReadOutputChannels();

//                if (digitalOutputChannels[channel] == true)
//                {
//                    //MessageBox.Show("Si la ALARMA cambio para DESACTIVADO desconsidere está mensaje." +
//                    //    "Pero si la ALRMA no cambio para Desactivado, tuve algun error en la conexion con el Equipo ADAM. " +
//                    //    "Espere de 30 segundo y vuelva a intentarlo!!" +
//                    //    "(OBS PORTA DO ADAM NÃO MUDOU PARA FALSE)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    adamModbus.Disconnect();
//                    res = false;
//                    return res;
//                }

//                adamModbus.Disconnect();
//                return res;
//            }
//            else
//            {
//                adamModbus.Disconnect();
//                // MessageBox.Show("Error al Escribir en la OUTPUT ADAM. (Provavelmente error de conexao com ADAM.)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//            return res;
//        }

//        public bool[] ReadOutputChannels()
//        {
//            bool[] digitalOutputChannels = null;
//            //if (adamModbus.Connect(m_szIP, ProtocolType.Tcp, m_iPort))
//            //{
//            var modbus = adamModbus.Modbus();
//            modbus.ReadCoilStatus(IdSartForOutputChannel, TotalDigitalOutputChannels, out digitalOutputChannels);
//            //adamModbus.Disconnect();
//            return digitalOutputChannels;
//            //}
//            //else
//            //{
//            //    adamModbus.Disconnect();
//            //    MessageBox.Show("Error de Lectura de OUTPUT ADAM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            //}
//            //return digitalOutputChannels;
//        }
//        public bool[] ReadInputChannels()
//        {
//            bool[] digitalInputChannels = null;

//            if (adamModbus.Connect(m_szIP, ProtocolType.Tcp, m_iPort))
//            {
//                var modbus = adamModbus.Modbus();
//                modbus.ReadCoilStatus(IdSartForInputChanel, TotalDigitalInputChannels, out digitalInputChannels);
//                adamModbus.Disconnect();
//                return digitalInputChannels;
//            }
//            else
//            {
//                adamModbus.Disconnect();
//                // MessageBox.Show("Error de Lectura de INPUT ADAM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//            return digitalInputChannels;
//        }
//    }
//}
