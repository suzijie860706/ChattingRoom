using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
namespace ChattingRoom
{
    class ChatServer
    {
        List<ChatClient> clientList = new List<ChatClient>();
        public static void Main(string[] args)
        {
            ChatServer chatServer = new ChatServer();
            chatServer.Run();
            
        }
        public void Run()
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, ChatSetting.Port); //IpAddress.Any 所有本機網路卡上任何一個IP所對應的端口
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            s.Bind(ipep);
            s.Listen(10);
            while (true)
            {
                Socket socket = s.Accept();
                ChatClient Client = new ChatClient(socket);
                Client.newListener(BroadCast); //建立執行緒，偵聽客戶端訊息。
                Client.CloseException(RemoveClient); //客戶端離開，移除客戶端資料。
                
                clientList.Add(Client);
                Console.WriteLine("目前線上使用者共 ：" + clientList.Count + "個人!");
            }

        }
        public void BroadCast(string msg)
        {
            Console.WriteLine(msg);
            foreach (ChatClient client in clientList)
            {
                if (!client.isDead)
                {
                    client.Send(msg);
                }
            }
        }
        public void RemoveClient()
        {
            
            foreach (ChatClient Client in clientList)
            {
                if (Client.isDead)
                {
                    clientList.Remove(Client);
                    Client.Dispose();
                    Client.listenThread.Abort();
                }
            }
            
        }
    }
}
