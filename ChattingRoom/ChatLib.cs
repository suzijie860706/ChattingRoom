using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using FireSharp;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace ChattingRoom
{
    public class ChatSetting
    {
        public static string IP = "127.0.0.1";
        public static int Port = 25565;
    }

    public delegate void strHandler(string s);
    public delegate void OutHandler();

    public class ChatClient
    {
        public Socket socket;
        public NetworkStream stream;
        public StreamReader reader;
        public StreamWriter writer;
        public strHandler inhandler; //傳遞訊息時，呼叫委託
        public OutHandler outhandler; //當失去連結時，呼叫委託
        public Thread listenThread;
        public bool isDead = false;
        public ChatClient(Socket s)
        {
            socket = s;
            stream = new NetworkStream(socket);
            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);
        }
        public static ChatClient Connect(string ip)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ChatSetting.IP), ChatSetting.Port);

            Socket s = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            s.Connect(ipep);

            return new ChatClient(s) ;
        }
        //當客戶端傳送訊息時
        public void Send(string line)
        {
            writer.WriteLine(line);
            writer.Flush();
        }

        public void newListener(strHandler phandler)
        {
             inhandler = phandler;
            
             listenThread = new Thread(new ThreadStart(listen));
             listenThread.Start();
        }
        public void listen()
        {
            try
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    
                    inhandler(line);
                }
            }
            catch (Exception)
            {
                isDead = true;
                outhandler();
            }
        }
        public void CloseException(OutHandler phandler)
        {
            outhandler = phandler;
        }
        //關閉客戶端與伺服器端的資料流、套接字
        public void Dispose()
        {
            socket.Dispose();
            socket = null;
            stream.Dispose();
            writer.Dispose();
            reader.Dispose();
        }
    }
    public static class FireBase 
    {
        private static IFirebaseConfig config = new FirebaseConfig        
        {
            AuthSecret = "XC0iuclznQfRETQdoZ0kPDg6nJ3ws0YhhPwSFWM8",
            BasePath = "https://test1-5be08.firebaseio.com/"
        };
        private static FirebaseClient Client = new FirebaseClient(config);

        public static async Task<string> AsyncSetData(ClientData clientData, bool Annonymous)
        {

            try
            {
                //如果是匿名，則寫入匿名，否則寫入ID進資料庫
                if (!Annonymous)
                {
                    SetResponse response = await Client.SetAsync("Users/" + clientData.Name, clientData);
                }
                else
                {
                    SetResponse response = await Client.SetAsync("Users/" + "Anonymous", clientData);
                }
            }
            catch (Exception)
            {
                return "Error";
            }
            return "OK";
        }
        public static string SetData(ClientData clientData, bool Annonymous)
        {
            var task = Task.Run(() => AsyncSetData(clientData,Annonymous));
            Task.WaitAll(task);
            return task.Result;
        }
        private static async Task<string> AsyncGetData(ClientData clientData)//應該沒有ID相對應，只能找Name
        { 
            FirebaseResponse response = await Client.GetAsync("Users/" + clientData.Name);
            ClientData result = response.ResultAs<ClientData>();
            return result.Name;
        }
        public static string GetData(ClientData clientData)
        {//使用task.Run() 並使用Task.WaitAll(task)
          //即可等待非同步結束才進行下一步
            var task = Task.Run(() => AsyncGetData(clientData));
            Task.WaitAll(task);
            return task.Result;
        }
    }
    
    //儲存會員資料的Class
    public class ClientData
    {
        public string Name; //暫時不考慮安全性
    }
}
