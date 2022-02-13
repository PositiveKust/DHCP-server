using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;

namespace DHCP_Server_KP_Project
{
    public partial class MainForm : Form
    {
        public struct DHCPstruct
        {
            public byte D_op; //Op code: 1 = bootRequest, 2 = BootReply
            public byte D_htype; //Hardware Address Type: 1 = 10MB ethernet
            public byte D_hlen; //hardware address length: length of MACID
            public byte D_hops; //Hw options
            public byte[] D_xid; //transaction id (4)
            public byte[] D_secs; //elapsed time from trying to boot (2)
            public byte[] D_flags; //flags (2)
            public byte[] D_ciaddr; // client IP (4)
            public byte[] D_yiaddr; // your client IP (4)
            public byte[] D_siaddr; // Server IP (4)
            public byte[] D_giaddr; // relay agent IP (4)
            public byte[] D_chaddr; // Client HW address (16)
            public byte[] D_sname; // Optional server host name (64)
            public byte[] D_file; // Boot file name (128)
            public byte[] D_options; //options (rest)
            public int lenght;
        }
        public enum DHCPMsgType
        {
            DHCPDISCOVER = 0x01, //клиент передает данные для поиска серверов

            DHCPOFFER = 0x02, //сервер предлагает IP - адрес устройству

            DHCPREQUEST = 0x03, //клиент принимает предложения от DHCP-сервера

            DHCPDECLINE = 0x04, //клиент отклоняет предложение от этого DHCP-сервера

            DHCPACK = 0x05, //сервер клиенту + фиксированный IP-адрес

            DHCPNAK = 0x06, //сервер клиенту, чтобы указать неверный сетевой адрес

            DHCPRELEASE = 0x07, //плавное завершение работы от клиента к серверу

            DHCPINFORM = 0x08,   //клиент-сервер запрашивает локальную информацию

            DHCPFORCERENEW = 0x09 // клиент просит сервер освободить IP-адресс до окончания времени

        }
        public enum DHCPOptionEnum
        {
            SubnetMask = 1,
            TimeOffset = 2,
            Router = 3,
            TimeServer = 4,
            NameServer = 5,
            DomainNameServer = 6,
            LogServer = 7,
            CookieServer = 8,
            LPRServer = 9,
            ImpressServer = 10,
            ResourceLocServer = 11,
            HostName = 12,
            BootFileSize = 13,
            MeritDump = 14,
            DomainName = 15,
            SwapServer = 16,
            RootPath = 17,
            ExtensionsPath = 18,
            IpForwarding = 19,
            NonLocalSourceRouting = 20,
            PolicyFilter = 21,
            MaximumDatagramReAssemblySize = 22,
            DefaultIPTimeToLive = 23,
            PathMTUAgingTimeout = 24,
            PathMTUPlateauTable = 25,
            InterfaceMTU = 26,
            AllSubnetsAreLocal = 27,
            BroadcastAddress = 28,
            PerformMaskDiscovery = 29,
            MaskSupplier = 30,
            PerformRouterDiscovery = 31,
            RouterSolicitationAddress = 32,
            StaticRoute = 33,
            TrailerEncapsulation = 34,
            ARPCacheTimeout = 35,
            EthernetEncapsulation = 36,
            TCPDefaultTTL = 37,
            TCPKeepaliveInterval = 38,
            TCPKeepaliveGarbage = 39,
            NetworkInformationServiceDomain = 40,
            NetworkInformationServers = 41,
            NetworkTimeProtocolServers = 42,
            VendorSpecificInformation = 43,
            NetBIOSoverTCPIPNameServer = 44,
            NetBIOSoverTCPIPDatagramDistributionServer = 45,
            NetBIOSoverTCPIPNodeType = 46,
            NetBIOSoverTCPIPScope = 47,
            XWindowSystemFontServer = 48,
            XWindowSystemDisplayManager = 49,
            RequestedIPAddress = 50,
            IPAddressLeaseTime = 51,
            OptionOverload = 52,
            DHCPMessageTYPE = 53,
            ServerIdentifier = 54,
            ParameterRequestList = 55,
            Message = 56,
            MaximumDHCPMessageSize = 57,
            RenewalTimeValue_T1 = 58,
            RebindingTimeValue_T2 = 59,
            Vendorclassidentifier = 60,
            ClientIdentifier = 61,
            NetworkInformationServicePlusDomain = 64,
            NetworkInformationServicePlusServers = 65,
            TFTPServerName = 66,
            BootfileName = 67,
            MobileIPHomeAgent = 68,
            SMTPServer = 69,
            POP3Server = 70,
            NNTPServer = 71,
            DefaultWWWServer = 72,
            DefaultFingerServer = 73,
            DefaultIRCServer = 74,
            StreetTalkServer = 75,
            STDAServer = 76,
            END_Option = 255
        }
        public async void AsyncMessageBox(string message)
        {
            await Task.Run(()=> {
                MessageBox.Show(message);
            });
        }
        public bool ReadDHCPStruct(byte[] Data, out DHCPstruct dStruct)
        {
            dStruct = new DHCPstruct();
            dStruct.lenght = 0;
            if (Data.Length > 237 && Data.Length < 576)
            {
                try
                { //read data

                    dStruct.D_op = Data[0];
                    dStruct.D_htype = Data[1];
                    dStruct.D_hlen = Data[2];
                    dStruct.D_hops = Data[3];
                    //
                    dStruct.D_xid = new byte[4];
                    for (int i = 0; i < 4; i++)
                        dStruct.D_xid[i] = Data[4 + i];
                    dStruct.D_secs = new byte[2];
                    for (int i = 0; i < 2; i++)
                        dStruct.D_secs[i] = Data[8 + i];
                    dStruct.D_flags = new byte[2];
                    for (int i = 0; i < 2; i++)
                        dStruct.D_flags[i] = Data[10 + i];
                    dStruct.D_ciaddr = new byte[4];
                    for (int i = 0; i < 4; i++)
                        dStruct.D_ciaddr[i] = Data[12 + i];
                    dStruct.D_yiaddr = new byte[4];
                    for (int i = 0; i < 4; i++)
                        dStruct.D_yiaddr[i] = Data[16 + i];
                    dStruct.D_siaddr = new byte[4];
                    for (int i = 0; i < 4; i++)
                        dStruct.D_siaddr[i] = Data[20 + i];
                    dStruct.D_giaddr = new byte[4];
                    for (int i = 0; i < 4; i++)
                        dStruct.D_giaddr[i] = Data[24 + i];
                    dStruct.D_chaddr = new byte[16];
                    for (int i = 0; i < 16; i++)
                        dStruct.D_chaddr[i] = Data[28 + i];
                    dStruct.D_sname = new byte[64];
                    for (int i = 0; i < 64; i++)
                        dStruct.D_sname[i] = Data[44 + i];
                    dStruct.D_file = new byte[128];
                    for (int i = 0; i < 128; i++)
                        dStruct.D_file[i] = Data[108 + i];
                    //read the rest of the data, which shall determine the dhcp
                    int temp = 0;
                    dStruct.lenght = 236;

                    dStruct.D_options = new byte[Data.Length - dStruct.lenght];
                    while (Data[236 + temp] != ((byte)DHCPOptionEnum.END_Option) && (236 + temp) < Data.Length + 1)
                    {
                        dStruct.D_options[temp] = Data[236 + temp];
                        dStruct.lenght = 236 + temp;
                        temp++;
                    }
                    dStruct.D_options[temp] = 255;
                    /*if (Data[Data.Length - 1] != ((byte)DHCPOptionEnum.END_Option)) {
                        dStruct.lenght = 0;
                        return false;
                    }*/
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return true;
            }
            else
                return false;
        }
        public bool MessagecreateDHCPStruct(DHCPstruct dStruct, out byte[] Data)
        {
            Data = new byte[dStruct.lenght+1];
            if (dStruct.lenght >= 236)
            {
                Data[0] = dStruct.D_op;
                Data[1] = dStruct.D_htype;
                Data[2] = dStruct.D_hlen;
                Data[3] = dStruct.D_hops;
                for (int i = 0; i < 4; i++)
                    Data[4 + i] = dStruct.D_xid[i];
                for (int i = 0; i < 2; i++)
                    Data[8 + i] = dStruct.D_secs[i];
                for (int i = 0; i < 2; i++)
                    Data[10 + i] = dStruct.D_flags[i];
                for (int i = 0; i < 4; i++)
                    Data[12 + i] = dStruct.D_ciaddr[i];
                for (int i = 0; i < 4; i++)
                    Data[16 + i] = dStruct.D_yiaddr[i];
                for (int i = 0; i < 4; i++)
                    Data[20 + i] = dStruct.D_siaddr[i];
                for (int i = 0; i < 4; i++)
                    Data[24 + i] = dStruct.D_giaddr[i];
                for (int i = 0; i < 16; i++)
                    Data[28 + i] = dStruct.D_chaddr[i];
                for (int i = 0; i < 64; i++)
                    Data[44 + i] = dStruct.D_sname[i];
                for (int i = 0; i < 128; i++)
                    Data[108 + i] = dStruct.D_file[i];
                if (dStruct.lenght == 236)
                    Data[236] = 255;
                else
                {
                    int temp = 0;
                    while (dStruct.D_options[temp] != ((byte)DHCPOptionEnum.END_Option) && (temp) < dStruct.D_options.Length)
                    {
                        Data[236 + temp] = dStruct.D_options[temp];
                        temp++;
                    }
                    if (Data[dStruct.lenght] != ((byte)DHCPOptionEnum.END_Option))
                        Data[dStruct.lenght] = ((byte)DHCPOptionEnum.END_Option);
                }
                return true;
            }
            else
                return false;

        }

        public enum StatusServerClient
        {
            StopAll = 0,
            StartServer = 1,
        }
        private int ipPortClient = 68, ipPortServer = 67,
            tempenumStatusServer = ((int)StatusServerClient.StopAll);
        private bool flagread = false; DHCPstruct dhcpmessage = new DHCPstruct();

        public bool AlreadyUsingIPAdress(string IpAdd, int time)
        {
            Ping pingSender = new Ping(); 
            IPAddress address; 
            PingReply reply;
            try
            {
                int ipAddtableidx = -1;
                for (int i = 0; i < iPTableForm.GetCountRow() - 1; i++)
                    if (iPTableForm.GetValue(i, 0) == IpAdd)
                        ipAddtableidx = i;
                if (ipAddtableidx == -1)
                    return false;
                address = IPAddress.Parse(IpAdd);//IPAddress.Loopback;

                reply = pingSender.Send(address, time);
                string y = MassivByteInMessage(dhcpmessage.D_chaddr), h = iPTableForm.GetValue(ipAddtableidx, 3);
                if (iPTableForm.GetValue(ipAddtableidx, 1) == "Свободен" ||(iPTableForm.GetValue(ipAddtableidx, 1) == "Занят"&& iPTableForm.GetValue(ipAddtableidx, 3) == MassivByteInMessage(dhcpmessage.D_chaddr)))//reply.Status == IPStatus.Success)
                {
                    /*AsyncMessageBox("Address: "+ reply.Address.ToString()+"\n"+
                        "RoundTrip time: "+ reply.RoundtripTime+"\n"+
                        "Time to live: "+ reply.Options.Ttl+"\n"+
                        "Don't fragment: "+ reply.Options.DontFragment+"\n"+
                        "Buffer size: "+ reply.Buffer.Length + "\n" +
                        "Address status: "+ reply.Status.ToString());*/
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(InvalidOperationException ex)
            {
                MessageBox.Show("Отсутствует сетевое подклчение!\n"+ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
                return false;
            }
            finally
            {
                if (pingSender != null) 
                    pingSender.Dispose(); 
                pingSender = null; 
                address = null;
                reply = null;
            }
        }
        string stripstart;
        TableRezervingIPForm iPTableForm = new TableRezervingIPForm();
        public MainForm()
        {
            InitializeComponent();
            Maintimer.Enabled = false;
            stripstart = textBoxIPUse.Text;
            iPTableForm.Show();
            iPTableForm.Visible = false;
            for (int i = 0; i < numericUpDownCountIPAddres.Value; i++)
            {
                iPTableForm.AddRowTable();
                byte[] tempmassbytes = IPAddress.Parse(textBoxIPUse.Text).GetAddressBytes(),
                    tempmassbytes2 = new byte[3] { tempmassbytes[0], tempmassbytes[1], tempmassbytes[2] };
                //if (AlreadyUsingIPAdress(MassivByteInMessage(tempmassbytes2) + "." + (((int)tempmassbytes[3]) + i).ToString(), 5)){
                    iPTableForm.AddValueTable( i,0, (MassivByteInMessage(tempmassbytes2) + "." + (((int)tempmassbytes[3]) + i)));
                    iPTableForm.AddValueTable( i,1, "Свободен");
                    iPTableForm.AddValueTable( i,2, "0");
                    iPTableForm.AddValueTable( i,3, "Нет");
                /*}
                else
                {
                    iPTableForm.AddValueTable(i, 0, (MassivByteInMessage(tempmassbytes2) + "." + (((int)tempmassbytes[3]) + i)));
                    iPTableForm.AddValueTable(i , 1, "Занят");
                    iPTableForm.AddValueTable(i , 2, "Неизвестно");
                    iPTableForm.AddValueTable(i , 3, "Нет");
                }*/
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iPTableForm.Close();
            this.Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tempstr = "Программный комплекс осуществляющий работу DHCP-сервера.\nОрганизация: СПбгТИ(ТУ)\nГруппа: 494\nАвтор: Казанцев Александр Михайлович\nСанкт-Петербург, 2022 г.";
            bool tempflag = false;
            if (Maintimer.Enabled == true)
            {
                tempflag = true;
                Maintimer.Stop();
            }
            MessageBox.Show(tempstr, "О программе");
            if(tempflag)
                Maintimer.Start();
        }
        private string MassivByteInMessage(byte[] bytes)
        {
            string str = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                if (i != bytes.Length - 1)
                    str += bytes[i].ToString() + ".";
                else
                    str += bytes[i].ToString();
            }
            return str;
        }
        private byte? TypeDHCPMessage(byte? messagetype)
        {
            if (dhcpmessage.lenght != 0)
            {
                for (int i = 4; i < dhcpmessage.D_options.Length; i++)
                {
                    if (dhcpmessage.D_options[i] == 53)// && dhcpmessage.D_options[i + 1] == 1)
                    {
                        if (messagetype == null)
                        {
                            byte? b = dhcpmessage.D_options[i + 2];
                            return b;
                        }
                        else
                        {
                            dhcpmessage.D_options[i + 2] = (byte)messagetype;
                            return messagetype;
                        }
                    }
                }
                return null;
            }
            else
                return null;
        }

        private byte[] OptionValue(byte numberoption)
        {
            if (dhcpmessage.D_options.Length > 4)
            {
                byte[] temp = null;
                for(int i = 4; i < dhcpmessage.D_options.Length; i++)
                {
                    if (dhcpmessage.D_options[i] != numberoption)
                    {
                        if (dhcpmessage.D_options[i] == 255)
                            break;
                        i += dhcpmessage.D_options[i + 1]+1;
                        continue;
                    }
                    else
                    {
                        temp = new byte[dhcpmessage.D_options[i + 1]];
                        for(int j = 2; j< dhcpmessage.D_options[i + 1] + 2; j++)
                        {
                            temp[j - 2] = dhcpmessage.D_options[i + j];
                        }
                    }
                }
                return temp;
            }
            return null ;
        }

        private void AddInDHCPOpption(byte[] addoption)
        {
            if (addoption[0] != 0 && addoption[1] != 0)
            {
                byte[] tempmass = new byte[addoption[1]+2+dhcpmessage.D_options.Length];
                if (OptionValue(addoption[0])==null)
                {
                    for(int i = 0; i < dhcpmessage.D_options.Length-1; i++)
                    {
                        tempmass[i] = dhcpmessage.D_options[i];
                    }
                    for(int j = 0; j < addoption.Length; j++)
                    {
                        tempmass[dhcpmessage.D_options.Length - 1 + j] = addoption[j];
                    }
                    tempmass[tempmass.Length - 1] = ((byte)DHCPOptionEnum.END_Option);
                    dhcpmessage.D_options = tempmass;
                    dhcpmessage.lenght += addoption[0] + 2;
                }
                else
                {
                    if (OptionValue(addoption[0])[1] < addoption[1])
                    {
                        tempmass = new byte[addoption[1] - OptionValue(addoption[0])[1] + dhcpmessage.D_options.Length];
                    }//Доделать
                }
            }
        }

        private async void Helpreadmessage(int ipread, byte[] bytes)
        {
            var intBytes = BitConverter.GetBytes((int)numericUpDownTimeRezervation.Value);
            Array.Reverse(intBytes);
            if (!flagread)
            {
                IPAddress[] ip = { IPAddress.Parse("192.168.0.1"), IPAddress.Broadcast, IPAddress.Any };
                IPEndPoint iep1 = new IPEndPoint(ip[1], ipread);
                IPEndPoint iep2 = new IPEndPoint(ip[2], ipread);
                UdpClient udpClient = new UdpClient();
                udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                flagread = true;
                try
                {
                    Maintimer.Stop();
                    await Task.Run(() =>
                    {
                        udpClient.Client.Bind(iep2);
                        //udpClient.Client.Connect(iep2);
                        //while (udpClient.Available>0)
                        bytes = udpClient.Receive(ref iep1);
                    });
                    udpClient.Close();
                    flagread = false;
                    int temptebleip = -1;
                    byte[] oneussemass = new byte[0];
                    if (bytes.Length != 0)
                    {
                        if (ReadDHCPStruct(bytes, out dhcpmessage))
                        {
                            byte[] tempbytes = new byte[0];
                            //MessageBox.Show("typemessage: " + dhcpmessage.D_op + "\n" + dhcpmessage.D_xid[0] + " " + dhcpmessage.D_xid[1] + " " + dhcpmessage.D_xid[2] + " " + dhcpmessage.D_xid[3]);
                            if (dhcpmessage.D_op == 0x01) {
                                bool flagip;
                                dhcpmessage.D_op = 0x02;
                                switch (TypeDHCPMessage(null)) {
                                    case ((byte?)DHCPMsgType.DHCPDISCOVER):
                                        flagip = false;
                                        for (int i = 0; i < numericUpDownCountIPAddres.Value; i++)
                                        {
                                            byte[] tempmassbytes = IPAddress.Parse(textBoxIPUse.Text).GetAddressBytes(),
                                                tempmassbytes2 = new byte[3] { tempmassbytes[0], tempmassbytes[1], tempmassbytes[2] };
                                            if (AlreadyUsingIPAdress(MassivByteInMessage(tempmassbytes2)+"." + (((int)tempmassbytes[3]) + i).ToString(), 100))
                                            {
                                                dhcpmessage.D_yiaddr = tempmassbytes;
                                                dhcpmessage.D_yiaddr[3] = (byte)(((int)tempmassbytes[3]) + i);
                                                oneussemass = new byte[6] { 54, 4, IPAddress.Any.GetAddressBytes()[0],
                                                IPAddress.Any.GetAddressBytes()[1],IPAddress.Any.GetAddressBytes()[2],
                                                IPAddress.Any.GetAddressBytes()[3]}; ;
                                                AddInDHCPOpption(oneussemass);
                                                oneussemass = new byte[6] {51,4,intBytes[0],intBytes[1],intBytes[2],intBytes[3] }; ;
                                                AddInDHCPOpption(oneussemass);
                                                //dhcpmessage.D_siaddr = IPAddress.Parse("192.168.0.1").GetAddressBytes();
                                                tempbytes = new byte[dhcpmessage.D_options.Length+1];
                                                bool typemessageedit = false;
                                                TypeDHCPMessage(((byte)DHCPMsgType.DHCPOFFER));
                                                for(int j=0; j < dhcpmessage.D_options.Length; j++)
                                                {
                                                    if (dhcpmessage.D_options[j] == ((byte)DHCPOptionEnum.DHCPMessageTYPE)&& dhcpmessage.D_options[j+1]==((byte)DHCPMsgType.DHCPOFFER))
                                                    {
                                                        tempbytes[j] = ((byte)DHCPOptionEnum.DHCPMessageTYPE);
                                                        tempbytes[j + 1] = 0x01;
                                                        typemessageedit = true;
                                                    }
                                                    else if (!typemessageedit)
                                                    {
                                                        tempbytes[j] = dhcpmessage.D_options[j];
                                                    }
                                                    else
                                                        tempbytes[j+1] = dhcpmessage.D_options[j];
                                                }
                                                flagip = true;
                                                break;
                                            }
                                        }
                                        if (flagip)
                                        {
                                            Helpwritemessage(ipPortServer, ipPortClient, ""); 
                                            //AsyncMessageBox("Mac-адресс клиента: " + MassivByteInMessage(dhcpmessage.D_chaddr) + "\nВыданный IP: " + MassivByteInMessage(dhcpmessage.D_yiaddr));
                                        }
                                        else
                                        {
                                            MessageBox.Show("В выбранном диапозоне нет свободных ip-адрессов!");
                                            numericUpDownTimeRezervation.ReadOnly = false;
                                            //numericUpDownMask.ReadOnly = false;
                                            numericUpDownCountIPAddres.ReadOnly = false;
                                            textBoxIPUse.ReadOnly = false;
                                            tempenumStatusServer = ((int)StatusServerClient.StopAll);
                                            ClearReadMessage(ipPortServer);
                                            Maintimer.Enabled = false;
                                            ButtonStrart.Text = "Запустить сервер";
                                            dhcpmessage.lenght = 0;
                                        }
                                        break;
                                    case ((byte)DHCPMsgType.DHCPREQUEST):
                                        flagip = false;
                                        tempbytes = new byte[dhcpmessage.D_options.Length + 1];
                                        if (dhcpmessage.D_ciaddr[0] == 0x00 && OptionValue(50) == null)
                                        {
                                            TypeDHCPMessage(((byte)DHCPMsgType.DHCPNAK));
                                            for (int j = 0; j < dhcpmessage.D_options.Length; j++)
                                            {
                                                if (dhcpmessage.D_options[j] == ((byte)DHCPOptionEnum.DHCPMessageTYPE) && dhcpmessage.D_options[j + 1] == ((byte)DHCPMsgType.DHCPOFFER))
                                                {
                                                    tempbytes[j] = ((byte)DHCPOptionEnum.DHCPMessageTYPE);
                                                }
                                                else
                                                {
                                                    tempbytes[j] = dhcpmessage.D_options[j];
                                                }
                                            }
                                            Helpwritemessage(ipPortServer, ipPortClient, "");
                                            break;
                                        }
                                        else if (OptionValue(50) != null)
                                        {
                                            byte[] b = OptionValue(50);
                                            temptebleip = -1;
                                            for (int i = 0; i < iPTableForm.GetCountRow()-1; i++)
                                            {
                                                if (iPTableForm.GetValue(i, 0) == MassivByteInMessage(OptionValue(50)))
                                                {
                                                    temptebleip = i;
                                                    break;
                                                }
                                            }
                                            if (temptebleip != -1)
                                            {
                                                if (AlreadyUsingIPAdress(MassivByteInMessage(OptionValue(50)), 100))
                                                {
                                                    if (OptionValue(51) == null)
                                                    {
                                                        oneussemass = new byte[6] { 51, 4, intBytes[0], intBytes[1], intBytes[2], intBytes[3] }; ;
                                                        AddInDHCPOpption(oneussemass);
                                                    }
                                                    tempbytes = new byte[dhcpmessage.D_options.Length + 1];
                                                    TypeDHCPMessage(((byte)DHCPMsgType.DHCPACK));
                                                    for (int j = 0; j < dhcpmessage.D_options.Length; j++)
                                                    {
                                                        if (dhcpmessage.D_options[j] == ((byte)DHCPOptionEnum.DHCPMessageTYPE) && dhcpmessage.D_options[j + 1] == ((byte)DHCPMsgType.DHCPOFFER))
                                                        {
                                                            tempbytes[j] = ((byte)DHCPOptionEnum.DHCPMessageTYPE);
                                                        }
                                                        else
                                                        {
                                                            tempbytes[j] = dhcpmessage.D_options[j];
                                                        }
                                                    }
                                                    Helpwritemessage(ipPortServer, ipPortClient, MassivByteInMessage(OptionValue(50)));
                                                    iPTableForm.AddValueTable(temptebleip, 1, "Занят");
                                                    iPTableForm.AddValueTable(temptebleip, 2, numericUpDownTimeRezervation.Value.ToString());
                                                    iPTableForm.AddValueTable(temptebleip, 3, MassivByteInMessage(dhcpmessage.D_chaddr));
                                                    break;
                                                }
                                                else
                                                {
                                                    if (OptionValue(51) != null)
                                                    {
                                                        oneussemass = new byte[6] { 51, 4, intBytes[0], intBytes[1], intBytes[2], intBytes[3] }; ;
                                                        AddInDHCPOpption(oneussemass);
                                                    }
                                                    TypeDHCPMessage(((byte)DHCPMsgType.DHCPFORCERENEW));
                                                    for (int j = 0; j < dhcpmessage.D_options.Length; j++)
                                                    {
                                                        if (dhcpmessage.D_options[j] == ((byte)DHCPOptionEnum.DHCPMessageTYPE) && dhcpmessage.D_options[j + 1] == ((byte)DHCPMsgType.DHCPOFFER))
                                                        {
                                                            tempbytes[j] = ((byte)DHCPOptionEnum.DHCPMessageTYPE);
                                                        }
                                                        else
                                                        {
                                                            tempbytes[j] = dhcpmessage.D_options[j];
                                                        }
                                                    }
                                                    iPTableForm.AddValueTable(temptebleip, 1, "Свободен");
                                                    iPTableForm.AddValueTable(temptebleip, 2, "0");
                                                    iPTableForm.AddValueTable(temptebleip, 3, "Нет");
                                                    Helpwritemessage(ipPortServer, ipPortClient, "");
                                                    break;
                                                }
                                            }
                                            else
                                                break;
                                        }
                                        else if (dhcpmessage.D_ciaddr[0] != 0x00)
                                        {
                                            temptebleip = -1;
                                            for (int i = 0; i < iPTableForm.GetCountRow() - 1; i++)
                                            {
                                                if (iPTableForm.GetValue(i, 0) == MassivByteInMessage(dhcpmessage.D_ciaddr))
                                                {
                                                    temptebleip = i;
                                                    break;
                                                }
                                            }
                                            if (temptebleip != -1)
                                            {
                                                if (AlreadyUsingIPAdress(MassivByteInMessage(dhcpmessage.D_ciaddr), 100))
                                                {
                                                    if (OptionValue(51) == null)
                                                    {
                                                        oneussemass = new byte[6] { 51, 4, intBytes[0], intBytes[1], intBytes[2], intBytes[3] }; ;
                                                        AddInDHCPOpption(oneussemass);
                                                    }
                                                    tempbytes = new byte[dhcpmessage.D_options.Length + 1];
                                                    TypeDHCPMessage(((byte)DHCPMsgType.DHCPACK));
                                                    for (int j = 0; j < dhcpmessage.D_options.Length; j++)
                                                    {
                                                        if (dhcpmessage.D_options[j] == ((byte)DHCPOptionEnum.DHCPMessageTYPE) && dhcpmessage.D_options[j + 1] == ((byte)DHCPMsgType.DHCPOFFER))
                                                        {
                                                            tempbytes[j] = ((byte)DHCPOptionEnum.DHCPMessageTYPE);
                                                        }
                                                        else
                                                        {
                                                            tempbytes[j] = dhcpmessage.D_options[j];
                                                        }
                                                    }
                                                    byte[] D_ciadrtempmass = dhcpmessage.D_ciaddr;
                                                    Array.Resize(ref D_ciadrtempmass, 6);
                                                    intBytes[0] = 50; intBytes[1] = 4;
                                                    AddInDHCPOpption(D_ciadrtempmass);
                                                    /*if (OptionValue(54) == null)
                                                        AddInDHCPOpption(IPAddress.Parse("54.4.192.168.0.1").GetAddressBytes());*/
                                                    Helpwritemessage(ipPortServer, ipPortClient, MassivByteInMessage(OptionValue(50)));
                                                    iPTableForm.AddValueTable(temptebleip, 1, "Занят");
                                                    iPTableForm.AddValueTable(temptebleip, 2, numericUpDownTimeRezervation.Value.ToString());
                                                    iPTableForm.AddValueTable(temptebleip, 3, MassivByteInMessage(dhcpmessage.D_chaddr));
                                                    break;
                                                }
                                                else
                                                {
                                                    TypeDHCPMessage(((byte)DHCPMsgType.DHCPNAK));
                                                    for (int j = 0; j < dhcpmessage.D_options.Length; j++)
                                                    {
                                                        if (dhcpmessage.D_options[j] == ((byte)DHCPOptionEnum.DHCPMessageTYPE) && dhcpmessage.D_options[j + 1] == ((byte)DHCPMsgType.DHCPOFFER))
                                                        {
                                                            tempbytes[j] = ((byte)DHCPOptionEnum.DHCPMessageTYPE);
                                                        }
                                                        else
                                                        {
                                                            tempbytes[j] = dhcpmessage.D_options[j];
                                                        }
                                                    }
                                                    Helpwritemessage(ipPortServer, ipPortClient, "");
                                                    break;
                                                }
                                            }
                                            else
                                                break;
                                        }
                                        else
                                        {
                                            TypeDHCPMessage(((byte)DHCPMsgType.DHCPNAK));
                                            for (int j = 0; j < dhcpmessage.D_options.Length; j++)
                                            {
                                                if (dhcpmessage.D_options[j] == ((byte)DHCPOptionEnum.DHCPMessageTYPE) && dhcpmessage.D_options[j + 1] == ((byte)DHCPMsgType.DHCPOFFER))
                                                {
                                                    tempbytes[j] = ((byte)DHCPOptionEnum.DHCPMessageTYPE);
                                                }
                                                else
                                                {
                                                    tempbytes[j] = dhcpmessage.D_options[j];
                                                }
                                            }
                                            Helpwritemessage(ipPortServer, ipPortClient, "");
                                        }
                                        break;
                                    case ((byte)DHCPMsgType.DHCPRELEASE):
                                        break;
                            }
                            }
                        }
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show("Некорректный номер порта.\n"+ex.ParamName+": "+ex.Message);
                }
                catch (SocketException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    udpClient.Close();
                    udpClient.Dispose();
                    Maintimer.Start();
                }
            }
        }
        private byte[] GetMACAddress()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                    return nic.GetPhysicalAddress().GetAddressBytes();
            }

            return null;
        }
        private void ClearReadMessage(int ipport)
        {
            UdpClient tempSocket = new UdpClient();
            byte[] bytes = {};
            tempSocket.Send(bytes, bytes.Length, new IPEndPoint( IPAddress.Broadcast , ipport));
            tempSocket.Close();
        }
        private void Helpwritemessage(int ipport, int ipportwrite, string fullipadressclient)
        {
            UdpClient serverSocketwrite = new UdpClient(67);//new IPEndPoint(IPAddress.Parse("192.168.0.1") ,67));
            if (ipportwrite == 68)
            {
                byte[] bytes = null;
                if (dhcpmessage.lenght != 0)
                {
                    MessagecreateDHCPStruct(dhcpmessage, out bytes);
                }
                else
                {
                    dhcpmessage.lenght = 0;
                    dhcpmessage.D_op = 1;
                    dhcpmessage.D_htype = 1;
                    dhcpmessage.D_hlen = (byte)GetMACAddress().Length;
                    dhcpmessage.D_hops = 0;
                    var rand = new Random();

                    // Generate and display 5 random byte (integer) values.
                    var byt = new byte[4];
                    rand.NextBytes(byt);
                    for (int i = 0; i < 4; i++)
                        dhcpmessage.D_xid[i] = byt[i];
                    for (int i = 0; i < 2; i++)
                        dhcpmessage.D_secs[i] = 0;
                    for (int i = 0; i < 2; i++)
                        dhcpmessage.D_flags[i] = 0;
                    for (int i = 0; i < 4; i++)
                        dhcpmessage.D_ciaddr[i] = 0;
                    for (int i = 0; i < 4; i++)
                        dhcpmessage.D_yiaddr[i] = 0;
                    for (int i = 0; i < 4; i++)
                        dhcpmessage.D_siaddr[i] = 0;
                    for (int i = 0; i < 4; i++)
                        dhcpmessage.D_giaddr[i] = 0;
                    for (int i = 0; i < 16; i++)
                        dhcpmessage.D_chaddr[i] = GetMACAddress()[i];
                    dhcpmessage.D_sname[0] = (byte)'\0';
                    for (int i = 1; i < 64; i++)
                        dhcpmessage.D_sname[i] = 0;
                    dhcpmessage.D_file[0] = (byte)'\0';
                    for (int i = 1; i < 128; i++)
                        dhcpmessage.D_file[i] = 0;
                    serverSocketwrite.Close();
                    return;
                }
                if (fullipadressclient == "")
                    serverSocketwrite.Send(bytes, bytes.Length, IPAddress.Broadcast.ToString(), ipportwrite);
                else
                    serverSocketwrite.Send(bytes, bytes.Length, fullipadressclient, ipportwrite);

            }
            else if (ipportwrite == 67)
            {
                byte[] bytes = { 45, 88, 77, 66, 22 };
                serverSocketwrite.Send(bytes, bytes.Length, IPAddress.Broadcast.ToString(), ipportwrite);
            }
            serverSocketwrite.Close();
        }

        private void таблицаАдрессовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iPTableForm.Visible = false;
            iPTableForm.Visible = true;
        }

        private void numericUpDownCountIPAddres_ValueChanged(object sender, EventArgs e)
        {
            if (iPTableForm.GetCountRow() < numericUpDownCountIPAddres.Value+1)
            {
                for (int i = iPTableForm.GetCountRow()-1; i < numericUpDownCountIPAddres.Value; i++)
                {
                    
                        iPTableForm.AddRowTable();
                        byte[] tempmassbytes = IPAddress.Parse(textBoxIPUse.Text).GetAddressBytes(),
                            tempmassbytes2 = new byte[3] { tempmassbytes[0], tempmassbytes[1], tempmassbytes[2] };
                    if ((((int)tempmassbytes[3]) + i) <= 255)
                    {
                        //if (AlreadyUsingIPAdress(MassivByteInMessage(tempmassbytes2) + "." + (((int)tempmassbytes[3]) + i).ToString(), 5)){
                        iPTableForm.AddValueTable(i, 0, (MassivByteInMessage(tempmassbytes2) + "." + (((int)tempmassbytes[3]) + i)));
                        iPTableForm.AddValueTable(i, 1, "Свободен");
                        iPTableForm.AddValueTable(i, 2, "0");
                        iPTableForm.AddValueTable(i, 3, "Нет");
                    }
                    else
                        break;
                    /*}
                    else
                    {
                        iPTableForm.AddValueTable(i , 0, (MassivByteInMessage(tempmassbytes2) + "." + (((int)tempmassbytes[3]) + i)));
                        iPTableForm.AddValueTable(i , 1, "Занят");
                        iPTableForm.AddValueTable(i , 2, "Неизвестно");
                        iPTableForm.AddValueTable(i , 3, "Нет");
                    }*/
                }
            }
            else if(iPTableForm.GetCountRow() > numericUpDownCountIPAddres.Value)
            {
                int j = iPTableForm.GetCountRow() ;
                int h = (int)numericUpDownCountIPAddres.Value;
                for (int i = iPTableForm.GetCountRow()-1; i > ((int)numericUpDownCountIPAddres.Value); i--)
                {
                    iPTableForm.DeleteRow(i-1);
                }
            }
        }

        private void textBoxIPUse_TextChanged(object sender, EventArgs e)
        {
            IPAddress tempip;
            if (IPAddress.TryParse(textBoxIPUse.Text, out tempip))
            {
                iPTableForm.ClearTable();
                for (int i = 0; i < numericUpDownCountIPAddres.Value; i++)
                {
                    iPTableForm.AddRowTable();
                    byte[] tempmassbytes = IPAddress.Parse(textBoxIPUse.Text).GetAddressBytes(),
                        tempmassbytes2 = new byte[3] { tempmassbytes[0], tempmassbytes[1], tempmassbytes[2] };
                    if ((((int)tempmassbytes[3]) + i) <= 255)
                    {
                        //if (AlreadyUsingIPAdress(MassivByteInMessage(tempmassbytes2) + "." + (((int)tempmassbytes[3]) + i).ToString(), 5)){
                        iPTableForm.AddValueTable(i, 0, (MassivByteInMessage(tempmassbytes2) + "." + (((int)tempmassbytes[3]) + i)));
                        iPTableForm.AddValueTable(i, 1, "Свободен");
                        iPTableForm.AddValueTable(i, 2, "0");
                        iPTableForm.AddValueTable(i, 3, "Нет");
                    }
                    else
                        break;
                        /*}
                        else
                        {
                            iPTableForm.AddValueTable(i , 0, (MassivByteInMessage(tempmassbytes2) + "." + (((int)tempmassbytes[3]) + i)));
                            iPTableForm.AddValueTable(i , 1, "Занят");
                            iPTableForm.AddValueTable(i , 2, "Неизвестно");
                            iPTableForm.AddValueTable(i , 3, "Нет");
                        }*/
                    }
                }
        }

        private void TimerRezervation_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < iPTableForm.GetCountRow() - 1; i++)
            {
                if (AlreadyUsingIPAdress(iPTableForm.GetValue(i, 0), 5)&& iPTableForm.GetValue(i, 3)=="Нет")
                {
                    if (iPTableForm.GetValue(i, 1) != "Свободен")
                    {
                        iPTableForm.AddValueTable(i , 1, "Свободен");
                        iPTableForm.AddValueTable(i , 2, "0");
                        iPTableForm.AddValueTable(i , 3, "Нет");
                    }
                }
                else
                {
                    if (iPTableForm.GetValue(i, 1) != "Занят")
                    {
                        iPTableForm.AddValueTable(i , 1, "Занят");
                        iPTableForm.AddValueTable(i , 2, "Неизвестно");
                        iPTableForm.AddValueTable(i , 3, "Нет");
                    }
                    else
                    {
                        int time;
                        if (Int32.TryParse(iPTableForm.GetValue(i , 2), out time))
                        {
                            if (time - 60 > 0)
                            {
                                iPTableForm.AddValueTable(i, 2, (time - 60).ToString());
                            }
                            else
                            {
                                /*TypeDHCPMessage(((byte)DHCPMsgType.DHCPFORCERENEW));
                                Helpwritemessage(ipPortServer, ipPortClient, iPTableForm.GetValue(i,0));*/
                                iPTableForm.AddValueTable(i, 1, "Свободен");
                                iPTableForm.AddValueTable(i, 2, "0");
                                iPTableForm.AddValueTable(i, 3, "Нет");
                            }
                        }
                    }
                }
            }
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "HelpOS.chm");
        }

        private void Maintimer_Tick(object sender, EventArgs e)
        {
            if (tempenumStatusServer == ((int)StatusServerClient.StopAll))
            {
                ClearReadMessage(ipPortServer);
                ClearReadMessage(ipPortClient);
                return;
            }
            else if (tempenumStatusServer == ((int)StatusServerClient.StartServer))
            {
                byte[] bytes = { };
                //Helpwritemessage(ipPortServer, ipPortClient);
                Helpreadmessage(ipPortServer, bytes);
                Maintimer.Enabled = false;
                Maintimer.Enabled = true;
            }
        }

        private void Strart_Click(object sender, EventArgs e)
        {
            if (ButtonStrart.Text == "Запустить сервер")
            {
                IPAddress tempip;
                if (IPAddress.TryParse(textBoxIPUse.Text, out tempip))
                {
                    numericUpDownCountIPAddres.Maximum = 250-((int)tempip.GetAddressBytes()[3]);
                }
                else
                {
                    AsyncMessageBox("Вы неправильно ввели ip-адрес!");
                    return;
                }
                bool flagfreeipadress = false;
                for(int i = 0; i < iPTableForm.GetCountRow(); i++)
                {
                    if (iPTableForm.GetValue(i, 1) == "Свободен")
                    {
                        flagfreeipadress = true;
                        break;
                    }
                }
                if (!flagfreeipadress)
                {
                    MessageBox.Show("В выбранном диапозоне нет свободных ip-адрессов!");
                    numericUpDownTimeRezervation.ReadOnly = false;
                    //numericUpDownMask.ReadOnly = false;
                    numericUpDownCountIPAddres.ReadOnly = false;
                    textBoxIPUse.ReadOnly = false;
                    tempenumStatusServer = ((int)StatusServerClient.StopAll);
                    ClearReadMessage(ipPortServer);
                    Maintimer.Enabled = false;
                    ButtonStrart.Text = "Запустить сервер";
                    dhcpmessage.lenght = 0;
                    return;
                }
                numericUpDownTimeRezervation.ReadOnly = true;
                //numericUpDownMask.ReadOnly = true;
                numericUpDownCountIPAddres.ReadOnly = true;
                textBoxIPUse.ReadOnly = true;
                dhcpmessage.lenght = 0;
                tempenumStatusServer = ((int)StatusServerClient.StartServer);
                ButtonStrart.Text = "Выключить сервер";
                byte[] bytes = { };
                TimerRezervation.Enabled = true;
                TimerRezervation.Start();
                Helpreadmessage(ipPortServer, bytes);
            }
            else if(ButtonStrart.Text == "Выключить сервер")
            {
                TimerRezervation.Stop();
                TimerRezervation.Enabled = false;
                numericUpDownTimeRezervation.ReadOnly = false;
                //numericUpDownMask.ReadOnly = false;
                numericUpDownCountIPAddres.ReadOnly = false;
                textBoxIPUse.ReadOnly = false;
                tempenumStatusServer = ((int)StatusServerClient.StopAll);
                ClearReadMessage(ipPortServer);
                Maintimer.Enabled = false;
                ButtonStrart.Text = "Запустить сервер";
                dhcpmessage.lenght = 0;
            }
        }
    }
}
